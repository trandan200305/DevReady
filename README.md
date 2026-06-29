# DevReady

## 📖 Tổng quan dự án (Project Overview)
**DevReady** là một ứng dụng Desktop dành cho hệ điều hành Windows, được phát triển bằng ngôn ngữ C# và nền tảng WPF (Windows Presentation Foundation). Ứng dụng cung cấp giải pháp phân tích toàn diện về phần cứng, phần mềm và đặc biệt là môi trường phát triển (Development Environment) trên máy tính của người dùng.

Khác với các công cụ kiểm tra thông tin hệ thống truyền thống (chỉ hiển thị thông số khô khan), DevReady tiến xa hơn bằng cách:
- Quét và kiểm tra sự đáp ứng yêu cầu cấu hình của các ứng dụng, phần mềm, game hay công cụ lập trình.
- Phát hiện các thư viện runtime, SDK, hoặc các dependency phần mềm đang bị thiếu.
- **Tích hợp Trí tuệ Nhân tạo (AI)** để giải thích các thông số một cách dễ hiểu, đồng thời đưa ra những lời khuyên nâng cấp, khắc phục lỗi tối ưu nhất bằng ngôn ngữ tự nhiên.

---

## 🎯 Mục tiêu dự án (Project Goals)
Dự án được xây dựng với các mục tiêu cốt lõi:
- Phân tích chi tiết phần cứng máy tính.
- Quét và thống kê các phần mềm đã cài đặt.
- Phát hiện các Runtime / SDK còn thiếu trong hệ thống.
- Kiểm tra tính tương thích của máy tính đối với các phần mềm, game, hoặc môi trường lập trình cụ thể.
- Đánh giá mức độ sẵn sàng của môi trường phát triển (Development Environment).
- Cung cấp các đề xuất, tư vấn thông minh dựa trên AI.
- Trích xuất và tạo báo cáo hệ thống chi tiết.

---

## 💻 Nền tảng hỗ trợ (Target Platform)
- Windows 10
- Windows 11

---

## 🛠 Công nghệ sử dụng (Technologies)
- **Ngôn ngữ lập trình**: C#
- **Framework**: .NET 8 (LTS)
- **Giao diện người dùng (Desktop UI)**: WPF (Windows Presentation Foundation)
- **Kiến trúc phần mềm**: MVVM (Model - View - ViewModel)
- **Cơ sở dữ liệu**: SQLite
- **ORM**: Entity Framework Core
- **Tích hợp AI**: OpenAI API hoặc Google Gemini API
- **Định dạng dữ liệu**: JSON
- **Quản lý mã nguồn**: Git & GitHub

---

## 📂 Cấu trúc thư mục (Project Structure)
Dự án được tổ chức theo cấu trúc chuẩn của MVVM:
```
PCInsight
│
├── Models        # Định nghĩa các cấu trúc dữ liệu, Entity cho Database
├── Views         # Giao diện người dùng (XAML)
├── ViewModels    # Logic liên kết giữa View và Model, xử lý các sự kiện
├── Services      # Chứa các service xử lý quét phần cứng, phần mềm, gọi API
├── Helpers       # Các hàm tiện ích, định dạng dữ liệu, chuyển đổi
├── Data          # Cấu hình Entity Framework, DbContext cho SQLite
├── Resources     # Tài nguyên như ngôn ngữ, style, template
├── Assets        # Hình ảnh, icon, font chữ
└── AI            # Module giao tiếp và xử lý dữ liệu với OpenAI / Gemini
```

---

## 🚀 Các tính năng chính (Main Features)

### 1. Hardware Scanner (Quét phần cứng)
Ứng dụng tự động quét và thu thập thông tin chi tiết về:
- CPU (Bộ vi xử lý)
- RAM (Bộ nhớ trong)
- GPU (Card đồ họa)
- Storage (Ổ cứng lưu trữ)
- Motherboard (Bo mạch chủ)
- Phiên bản hệ điều hành Windows

### 2. Software Scanner (Quét phần mềm)
Phát hiện các phần mềm quan trọng đã được cài đặt, đặc biệt là các công cụ dành cho lập trình viên:
- Visual Studio
- SQL Server
- Git
- Docker
- Python, Java, NodeJS...

### 3. Runtime Scanner (Kiểm tra Runtime)
Kiểm tra xem hệ thống đã có sẵn các thư viện nền tảng thiết yếu hay chưa:
- .NET Runtime / .NET SDK
- Java Runtime Environment (JRE)
- Python Environment
- Visual C++ Redistributable
- DirectX

### 4. Compatibility Checker (Kiểm tra tính tương thích)
Đánh giá khả năng chạy mượt mà của máy tính đối với:
- Ứng dụng Desktop nặng.
- Công cụ phát triển (Development Tools).
- Các tựa game phổ biến.
- **Thang điểm tương thích**: Từ 0% đến 100%.

### 5. Development Environment Analyzer (Phân tích môi trường lập trình)
Kiểm tra xem máy tính đã sẵn sàng để code hay chưa.
*Ví dụ kết quả phân tích:*
- ✔ Visual Studio
- ✔ Git
- ✔ SQL Server
- ✖ Docker (Thiếu)
- ✖ NodeJS (Thiếu)

### 6. AI Advisor (Cố vấn AI)
Phân tích kết quả quét hệ thống và tạo ra những lời khuyên thông minh.
*Ví dụ các câu hỏi AI có thể giải đáp:*
- "Tại sao Visual Studio trên máy tôi lại chạy chậm?"
- "Vì sao tôi không thể mở ứng dụng này?"
- "Tôi nên ưu tiên nâng cấp phần cứng nào trước?"
- "Hệ thống của tôi đang thiếu Runtime nào để chạy dự án?"

### 7. Report Generator (Xuất báo cáo)
Hỗ trợ xuất kết quả quét máy tính ra các định dạng tài liệu:
- PDF
- Excel

---

## 🧠 Tích hợp AI (AI Functions)
**Lưu ý quan trọng**: AI *không* trực tiếp đảm nhận việc quét máy tính.
Quy trình hoạt động:
1. Ứng dụng (C# / WPF) thực hiện việc quét và lấy thông số phần cứng, phần mềm.
2. Dữ liệu thô sau khi quét sẽ được hệ thống đóng gói và gửi cho AI.
3. AI phân tích dữ liệu này và trả về các đề xuất ngôn ngữ tự nhiên.

**Ví dụ thực tế**:
*Dữ liệu đầu vào (Từ Scanner):*
```
CPU: Intel i5-9300H
RAM: 8GB
GPU: GTX1650
.NET SDK: Missing
```
*Kết quả AI phân tích (AI Output):*
> "Máy tính của bạn có đủ cấu hình để chạy Visual Studio một cách mượt mà. Tuy nhiên, hệ thống hiện đang thiếu .NET 8 SDK để phát triển ứng dụng. Bạn nên cài đặt thêm SDK này. Ngoài ra, để tăng cường hiệu năng đa nhiệm khi code, việc nâng cấp RAM lên 16GB là điều rất đáng cân nhắc."

---

## 📊 Hệ thống chấm điểm (Compatibility Score)
Dựa trên mức độ đáp ứng cấu hình, ứng dụng đưa ra các mức xếp hạng:
- **Tuyệt vời (Excellent)**: 90 - 100%
- **Tốt (Good)**: 75 - 89%
- **Trung bình (Average)**: 50 - 74%
- **Kém (Poor)**: Dưới 50%

---

## 📦 Các tính năng dự kiến trong tương lai (Future Features)
- **Tự động cài đặt (Auto Install)**: Hỗ trợ tải và cài đặt tự động các thư viện Runtime còn thiếu.
- **Gợi ý cập nhật Driver**: Phát hiện và đề xuất phiên bản Driver mới nhất.
- **Project Dependency Scanner**: Quét mã nguồn một dự án và cho biết máy tính có đủ môi trường để build dự án đó không.
- **Đánh giá hiệu năng Game**: Ước tính mức FPS khi chơi các tựa game cụ thể.
- **Benchmark Module**: Đo đạc và chấm điểm sức mạnh phần cứng thực tế.
- **AI Chat Assistant**: Trợ lý ảo dạng chat giúp giải đáp các thắc mắc về máy tính.
- **Đồng bộ Đám mây (Cloud Sync)**: Lưu trữ cấu hình và báo cáo máy tính lên Cloud.
- **Cơ sở dữ liệu trực tuyến**: Liên tục cập nhật cấu hình yêu cầu của các phần mềm mới nhất.

---

## 📈 Lộ trình phát triển (Development Roadmap)
- **Phiên bản 1.0**: Hoàn thiện Hardware Scanner.
- **Phiên bản 1.1**: Ra mắt Software Scanner.
- **Phiên bản 1.2**: Tích hợp Runtime Scanner.
- **Phiên bản 1.3**: Xây dựng Compatibility Checker.
- **Phiên bản 1.4**: Tích hợp AI (AI Integration).
- **Phiên bản 1.5**: Bổ sung Report Generator.
- **Phiên bản 2.0**: Tính năng Auto Fix (Tự động sửa lỗi và cài đặt).

---

## 🎯 Đối tượng người dùng (Target Users)
- **Lập trình viên (Software Developers)**: Kiểm tra môi trường Dev và dependency nhanh chóng.
- **Sinh viên IT (Students)**: Chuẩn bị máy tính để học tập các môn chuyên ngành.
- **Game thủ (Gamers)**: Đánh giá xem máy có "cân" được tựa game mới hay không.
- **IT Support / Kỹ thuật viên (Computer Technicians)**: Sử dụng làm công cụ chuẩn đoán lỗi nhanh cho khách hàng.

---

## 📚 Mục tiêu học tập & Nghiên cứu (Learning Objectives)
Dự án này là cơ hội để thực hành và ứng dụng các kiến thức:
- C# & WPF (Thiết kế Desktop App chuyên nghiệp).
- Kiến trúc MVVM & Lập trình Hướng đối tượng (OOP).
- Entity Framework Core & SQLite (Quản lý dữ liệu nội bộ).
- Giao tiếp với Windows (Windows APIs, Registry, WMI).
- Giao tiếp với Web (REST API, JSON).
- Tích hợp Trí tuệ nhân tạo (OpenAI / Gemini).
- Thiết kế phần mềm (Software Architecture).
- Sử dụng Git & GitHub trong quản lý mã nguồn.

---

## 📄 Giấy phép (License)
Dự án được phân phối dưới giấy phép **MIT License**.

---

## 👨‍💻 Thông tin Tác giả (Developer)
**Phát triển bởi**: Trần Dần
- **Vai trò**: Sinh viên Kỹ thuật phần mềm (Software Engineering Student) | Lập trình viên .NET (.NET Developer)
- **GitHub**: [trandan200305](https://github.com/trandan200305)
