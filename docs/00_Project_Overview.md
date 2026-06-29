# Tổng quan dự án (Project Overview)

## 1. Giới thiệu chung
**DevReady** là một ứng dụng Desktop thông minh dành cho hệ điều hành Windows, được xây dựng trên nền tảng .NET 8 và WPF (Windows Presentation Foundation). 
Mục tiêu cốt lõi của DevReady không chỉ là liệt kê thông số phần cứng như các phần mềm truyền thống (CPU-Z, dxdiag), mà là **"hiểu"** máy tính của bạn thông qua sức mạnh của AI, từ đó đưa ra đánh giá tương thích với các môi trường lập trình, game và phần mềm nặng.

## 2. Vấn đề giải quyết
- Người dùng không rành về kỹ thuật khó hiểu được các thông số phần cứng phức tạp.
- Lập trình viên mới thường gặp lỗi khi setup môi trường (thiếu SDK, Runtime, sai phiên bản).
- Game thủ không chắc chắn máy mình có chơi mượt một tựa game mới hay không.
- Kỹ thuật viên cần một công cụ tự động chẩn đoán nhanh lỗi phần cứng/phần mềm.

## 3. Các tính năng cốt lõi (Core Features)
Hệ thống xoay quanh 4 trụ cột chính trong phiên bản đầu tiên:
1. **Hardware Scan**: Quét sâu vào hệ thống để lấy dữ liệu phần cứng.
2. **Software Scan**: Lập danh sách các phần mềm, IDE, Database đã cài đặt.
3. **Runtime Scan**: Phát hiện các môi trường chạy ứng dụng (.NET, Java, C++ Redistributable...).
4. **Compatibility Analysis**: Đối chiếu cấu hình hiện tại với yêu cầu của các phần mềm khác để chấm điểm tương thích.

## 4. Tầm nhìn
Trở thành công cụ chẩn đoán và tư vấn nâng cấp PC số 1 dành cho cộng đồng IT và Game thủ, với khả năng tự động sửa lỗi (Auto Fix) trong các phiên bản tương lai.
