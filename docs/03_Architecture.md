# Kiến trúc hệ thống (Architecture)

## 1. Kiến trúc MVVM (Model - View - ViewModel)
DevReady sử dụng kiến trúc chuẩn của WPF để tách biệt hoàn toàn giao diện và logic xử lý.

- **Views (`/Views`)**: Chỉ chứa mã XAML. Định nghĩa giao diện, layout, data binding.
- **ViewModels (`/ViewModels`)**: Xử lý logic, gọi đến Services. Sử dụng `INotifyPropertyChanged` hoặc CommunityToolkit.Mvvm để binding dữ liệu 2 chiều.
- **Models (`/Models`)**: Chứa các Entity class cho Database (Ví dụ: `HardwareInfo`, `ScanSession`).

## 2. Tổ chức Module hệ thống
Dự án được chia làm 7 module chính để dễ dàng bảo trì và mở rộng:

1. **UI Module**: Quản lý giao diện, Navigation, Animations, Themes (Dark/Light).
2. **Scanner Module**: Gọi các API của Windows (WMI, Registry) để thu thập thông tin.
3. **Analyzer Module**: Đối chiếu dữ liệu quét với cơ sở dữ liệu yêu cầu hệ thống.
4. **AI Module**: Tích hợp SDK của OpenAI/Gemini, cấu hình Prompt, xử lý Rate Limit và phân tích phản hồi.
5. **Database Module**: Chứa SQLite DbContext, Repository Pattern để truy xuất dữ liệu lịch sử.
6. **Report Module**: Sử dụng các thư viện như iTextSharp/QuestPDF để xuất PDF, EPPlus để xuất Excel.
7. **Update Module**: (Về sau) Quản lý việc tự động tải và cài đặt Runtime còn thiếu.
