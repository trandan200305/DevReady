# Nguyên lý SOLID trong Thiết kế Phần mềm

SOLID là viết tắt của 5 nguyên lý thiết kế hướng đối tượng được đưa ra bởi Robert C. Martin (Uncle Bob). Các nguyên lý này giúp mã nguồn dễ hiểu, linh hoạt, dễ bảo trì và dễ mở rộng hơn.

---

## 1. Single Responsibility Principle (SRP) - Nguyên lý Đơn nhiệm
> **Định nghĩa:** Một class chỉ nên giữ một trách nhiệm duy nhất (chỉ có một lý do duy nhất để thay đổi).

### Vi phạm (Bad):
Lớp `UserManager` dưới đây vừa thực hiện logic lưu trữ người dùng, vừa gửi email chào mừng, vừa ghi log ra file.
```csharp
public class UserManager {
    public void RegisterUser(string username, string email) {
        // Đăng ký người dùng
        Console.WriteLine($"Đăng ký tài khoản: {username}");
        
        // Gửi email chào mừng (Trách nhiệm của EmailService)
        SendWelcomeEmail(email);
        
        // Ghi log vào file (Trách nhiệm của Logger)
        File.WriteAllText("log.txt", $"User {username} registered.");
    }
    
    private void SendWelcomeEmail(string email) {
        // Gửi email logic...
    }
}
```

### Đúng chuẩn (Good):
Tách biệt thành các class có nhiệm vụ chuyên biệt, giúp code dễ đọc, dễ viết test và dễ tái sử dụng.
```csharp
public class UserRepository {
    public void Save(string username) {
        // Logic lưu DB
    }
}

public class EmailService {
    public void SendWelcomeEmail(string email) {
        // Logic gửi Email
    }
}

public class Logger {
    public void Log(string message) {
        // Logic ghi log (file, db, cloud...)
    }
}

public class UserService {
    private readonly UserRepository _repository;
    private readonly EmailService _emailService;
    private readonly Logger _logger;

    public UserService(UserRepository repository, EmailService emailService, Logger logger) {
        _repository = repository;
        _emailService = emailService;
        _logger = logger;
    }

    public void RegisterUser(string username, string email) {
        _repository.Save(username);
        _emailService.SendWelcomeEmail(email);
        _logger.Log($"Đăng ký tài khoản thành công cho {username}");
    }
}
```

---

## 2. Open/Closed Principle (OCP) - Nguyên lý Đóng/Mở
> **Định nghĩa:** Đối tượng hoặc thực thể (class, module, function) nên thoải mái cho việc mở rộng (Open for extension), nhưng hạn chế sửa đổi trực tiếp cấu trúc bên trong (Closed for modification).

### Vi phạm (Bad):
Mỗi khi cần thêm một kênh thông báo mới (như Zalo, Slack), ta bắt buộc phải sửa trực tiếp lớp `NotificationSender` bằng cấu trúc `switch-case` hoặc `if-else`. Điều này dễ gây ra lỗi cho phần code cũ đang hoạt động ổn định.
```csharp
public class NotificationSender {
    public void SendNotification(string message, string type) {
        if (type == "Email") {
            // Gửi email
        } else if (type == "SMS") {
            // Gửi SMS
        }
    }
}
```

### Đúng chuẩn (Good):
Sử dụng Interface để trừu tượng hóa phương thức gửi. Khi cần thêm một kênh gửi mới (Zalo), ta chỉ cần tạo class mới thực thi `INotificationChannel` mà không cần đụng vào code cũ.
```csharp
public interface INotificationChannel {
    void Send(string message);
}

public class EmailChannel : INotificationChannel {
    public void Send(string message) { /* Logic gửi Email */ }
}

public class SmsChannel : INotificationChannel {
    public void Send(string message) { /* Logic gửi SMS */ }
}

// Khi cần mở rộng thêm Slack, chỉ cần viết class mới:
public class SlackChannel : INotificationChannel {
    public void Send(string message) { /* Logic gửi Slack */ }
}

public class NotificationService {
    public void Broadcast(string message, IEnumerable<INotificationChannel> channels) {
        foreach (var channel in channels) {
            channel.Send(message);
        }
    }
}
```

---

## 3. Liskov Substitution Principle (LSP) - Nguyên lý Thay thế Liskov
> **Định nghĩa:** Các đối tượng thuộc lớp con có thể thay thế lớp cha của nó mà không làm thay đổi tính đúng đắn và logic của chương trình.

### Vi phạm (Bad):
Lớp con `Square` (Hình vuông) kế thừa từ `Rectangle` (Hình chữ nhật) nhưng ghi đè các thuộc tính chiều rộng và chiều cao để chúng luôn bằng nhau. Điều này phá vỡ kỳ vọng của người dùng khi sử dụng lớp cha `Rectangle`.
```csharp
public class Rectangle {
    public virtual int Width { get; set; }
    public virtual int Height { get; set; }
    public int GetArea() => Width * Height;
}

public class Square : Rectangle {
    public override int Width {
        set { base.Width = value; base.Height = value; }
    }
    public override int Height {
        set { base.Height = value; base.Width = value; }
    }
}

// Lỗi logic xảy ra ở đây:
Rectangle rect = new Square();
rect.Width = 5;
rect.Height = 10;
// Kỳ vọng diện tích là 50 (5 * 10), nhưng thực tế nó lại trả về 100 (10 * 10).
```

### Đúng chuẩn (Good):
Nếu mối quan hệ kế thừa IS-A (Là một) không đáp ứng đúng về mặt hành vi/logic toán học, hãy tách chúng ra hoặc đưa về cùng một interface cơ sở chung.
```csharp
public interface IShape {
    int GetArea();
}

public class Rectangle : IShape {
    public int Width { get; set; }
    public int Height { get; set; }
    public int GetArea() => Width * Height;
}

public class Square : IShape {
    public int SideLength { get; set; }
    public int GetArea() => SideLength * SideLength;
}
```

---

## 4. Interface Segregation Principle (ISP) - Nguyên lý Phân tách Interface
> **Định nghĩa:** Thay vì dùng một interface lớn chứa nhiều phương thức, ta nên phân tách thành nhiều interface nhỏ chuyên biệt. Client không nên bị ép buộc phụ thuộc vào các phương thức mà họ không sử dụng.

### Vi phạm (Bad):
Interface `IPrinter` quá lớn (Fat Interface). Máy in phổ thông (`BasicPrinter`) chỉ có chức năng in nhưng bị ép phải triển khai cả phương thức `Scan` và `Fax`.
```csharp
public interface IPrinter {
    void Print(string document);
    void Scan(string document);
    void Fax(string document);
}

public class BasicPrinter : IPrinter {
    public void Print(string document) { /* In tài liệu */ }
    public void Scan(string document) => throw new NotImplementedException(); // Không cần dùng nhưng vẫn phải viết
    public void Fax(string document) => throw new NotImplementedException(); // Không cần dùng nhưng vẫn phải viết
}
```

### Đúng chuẩn (Good):
Tách interface lớn thành các interface chuyên biệt nhỏ hơn.
```csharp
public interface IPrint {
    void Print(string document);
}

public interface IScan {
    void Scan(string document);
}

public interface IFax {
    void Fax(string document);
}

// Máy in cơ bản chỉ kế thừa interface in ấn
public class BasicPrinter : IPrint {
    public void Print(string document) { /* In tài liệu */ }
}

// Máy in đa năng đa nhiệm kế thừa tất cả interface cần thiết
public class AllInOnePrinter : IPrint, IScan, IFax {
    public void Print(string document) { /* In */ }
    public void Scan(string document) { /* Scan */ }
    public void Fax(string document) { /* Fax */ }
}
```

---

## 5. Dependency Inversion Principle (DIP) - Nguyên lý Đảo ngược Phụ thuộc
> **Định nghĩa:** 
> 1. Các module cấp cao không nên phụ thuộc vào các module cấp thấp. Cả hai nên phụ thuộc vào sự trừu tượng (Abstraction).
> 2. Sự trừu tượng (Interface) không nên phụ thuộc vào chi tiết, mà chi tiết nên phụ thuộc vào sự trừu tượng.

### Vi phạm (Bad):
Lớp cấp cao `Car` phụ thuộc trực tiếp và cứng nhắc (Hardcode) vào lớp cấp thấp `GasolineEngine`. Khi muốn thay thế sang động cơ điện (`ElectricEngine`), ta buộc phải mở class `Car` ra và sửa lại code.
```csharp
public class GasolineEngine {
    public void Start() { /* Khởi động động cơ xăng */ }
}

public class Car {
    private readonly GasolineEngine _engine;
    
    public Car() {
        _engine = new GasolineEngine(); // Phụ thuộc trực tiếp vào class cụ thể
    }
    
    public void Drive() {
        _engine.Start();
    }
}
```

### Đúng chuẩn (Good):
Lớp `Car` phụ thuộc vào interface `IEngine` (sự trừu tượng). Việc sử dụng động cơ nào sẽ được truyền vào từ bên ngoài (thông qua Dependency Injection).
```csharp
public interface IEngine {
    void Start();
}

public class GasolineEngine : IEngine {
    public void Start() { /* Khởi động động cơ xăng */ }
}

public class ElectricEngine : IEngine {
    public void Start() { /* Khởi động động cơ điện */ }
}

public class Car {
    private readonly IEngine _engine;

    // Inject engine thông qua Constructor
    public Car(IEngine engine) {
        _engine = engine;
    }

    public void Drive() {
        _engine.Start();
    }
}
```

---

## Lợi ích khi áp dụng SOLID
* **Dễ bảo trì (Maintainability):** Các thành phần được tách biệt rõ ràng, thay đổi ở một nơi ít gây ảnh hưởng lan truyền đến các module khác.
* **Dễ mở rộng (Extensibility):** Cho phép mở rộng hệ thống bằng cách thêm lớp mới, hạn chế tối đa việc chỉnh sửa code cũ.
* **Dễ viết Unit Test:** Nhờ lập trình hướng giao diện (programming to interfaces), chúng ta dễ dàng thay thế các phụ thuộc thật bằng các Mock Object để kiểm thử độc lập từng phương thức.

---
*Tài liệu tìm hiểu về SOLID - DevReady Learning Docs*
