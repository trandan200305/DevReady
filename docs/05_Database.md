# Thiết kế Cơ sở dữ liệu (Database Design)

Cơ sở dữ liệu sử dụng **SQLite** kết hợp với **Entity Framework Core (Code-First)**.

## 1. Chi tiết cấu trúc Bảng (Tables)

### Bảng `ScanSessions`
- `Id` (int, PK, Auto-increment)
- `ScanDate` (datetime): Ngày giờ thực hiện quét.
- `WindowsVersion` (string): Phiên bản OS (VD: Windows 11 23H2).
- `OverallScore` (float): Điểm đánh giá sức mạnh tổng thể.

### Bảng `HardwareInfos`
- `Id` (int, PK)
- `ScanId` (int, FK) -> `ScanSessions.Id`
- `ComponentType` (string): CPU, RAM, GPU, Disk, Motherboard.
- `Name` (string): VD: "Intel Core i5-12400F".
- `Specifications` (string/JSON): Tốc độ, dung lượng, nhiệt độ (nếu có).

### Bảng `SoftwareInfos` & `RuntimeInfos`
- `Id` (int, PK)
- `ScanId` (int, FK) -> `ScanSessions.Id`
- `Name` (string): Tên phần mềm/runtime.
- `Version` (string): Phiên bản cài đặt.
- `IsMissing` (bool): (Dành riêng cho Runtime) Đánh dấu `true` nếu máy tính cần thư viện này nhưng chưa cài đặt.

### Bảng `AiRecommendations`
- `Id` (int, PK)
- `ScanId` (int, FK) -> `ScanSessions.Id`
- `Category` (string): Nâng cấp phần cứng / Cài đặt phần mềm / Tối ưu OS.
- `Message` (string): Nội dung chi tiết lời khuyên từ AI.
- `Priority` (int): 1 (Low), 2 (Medium), 3 (High).
