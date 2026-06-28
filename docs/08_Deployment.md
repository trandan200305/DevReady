# Triển khai (Deployment)

Tài liệu này hướng dẫn cách đóng gói và xuất bản ứng dụng PC Insight cho người dùng cuối.

## 1. Mục tiêu Đóng gói
- Ứng dụng phải chạy được độc lập (Self-contained) hoặc đảm bảo máy khách có cài sẵn .NET 8 Desktop Runtime.
- Định dạng xuất xưởng: Tệp cài đặt `.msi`, `.exe` hoặc gói `MSIX` (dành cho Windows Store).

## 2. Quy trình Build
Sử dụng tính năng Publish của Visual Studio hoặc .NET CLI:
```bash
# Lệnh build ứng dụng WPF ở chế độ Release, đóng gói toàn bộ thư viện (Self-contained) thành 1 file .exe duy nhất
dotnet publish -c Release -r win-x64 --self-contained true -p:PublishSingleFile=true -p:IncludeNativeLibrariesForSelfExtract=true
```

## 3. Các lưu ý khi triển khai
- **Quyền Quản trị viên (Admin Rights)**: Để quét được một số thông tin sâu của phần cứng và hệ điều hành, file manifest của ứng dụng (app.manifest) cần yêu cầu cấp quyền `requireAdministrator`.
- **Cơ sở dữ liệu SQLite**: File database `pcinsight.db` sẽ được sinh ra ở thư mục `AppData/Local/PCInsight/` để đảm bảo có quyền đọc ghi, không lưu trữ trong thư mục cài đặt `Program Files`.
