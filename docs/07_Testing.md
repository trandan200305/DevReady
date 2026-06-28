# Kiểm thử (Testing)

Dự án sử dụng **xUnit** hoặc **NUnit** kết hợp với **Moq** để đảm bảo chất lượng phần mềm.

## 1. Chiến lược Kiểm thử (Testing Strategy)
Do PC Insight tương tác sâu với hệ điều hành và phần cứng, việc test cần được cô lập để có thể chạy trên bất kỳ máy nào (dù máy đó cấu hình thấp hay cao).

- **Unit Testing**: Dành cho các logic thuật toán (ví dụ: Thuật toán chấm điểm tương thích).
- **Mocking**: Giả lập các Windows API (WMI, Registry) và API của OpenAI để không bị phụ thuộc vào môi trường thực tế khi chạy test.
- **UI Testing**: Đảm bảo các bindings của WPF ViewModel hiển thị đúng dữ liệu lên View.

## 2. Các Kịch bản Test chính (Main Test Cases)
- **TC01 - Hardware Scanner**: Kiểm tra hàm lấy tổng dung lượng RAM có trả về đúng định dạng GB không.
- **TC02 - Runtime Detector**: Đọc giả lập Registry xem hàm kiểm tra .NET 8 SDK có nhận diện đúng là `Missing` khi không có key tương ứng hay không.
- **TC03 - Compatibility Score**: Đưa vào một máy ảo có cấu hình thấp (RAM 4GB), kiểm tra xem điểm tương thích với "Visual Studio 2022" có dưới 50% hay không.
- **TC04 - AI Error Handling**: Kiểm tra ứng dụng không bị crash khi mất kết nối mạng (API AI trả về Timeout/Lỗi 500).
