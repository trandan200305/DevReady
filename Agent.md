# PC Insight

# TÀI LIỆU TỔNG QUAN DỰ ÁN

Phiên bản: 1.0

---

## 1. Giới thiệu dự án

**PC Insight** là một ứng dụng Desktop được phát triển bằng C# và WPF, giúp người dùng phân tích toàn diện máy tính của mình.

Ứng dụng có khả năng quét phần cứng, phần mềm, môi trường chạy (Runtime), môi trường lập trình và đánh giá khả năng tương thích với các ứng dụng hoặc game.

Không chỉ hiển thị thông tin cấu hình, PC Insight còn sử dụng AI để phân tích kết quả và đưa ra những khuyến nghị giúp người dùng tối ưu hệ thống.

---

## 2. Mục tiêu dự án

Mục tiêu của dự án là:

- Quét cấu hình phần cứng máy tính.
- Quét các phần mềm đã cài đặt.
- Kiểm tra các Runtime và SDK.
- Đánh giá khả năng chạy ứng dụng hoặc game.
- Phân tích môi trường lập trình.
- Đưa ra khuyến nghị bằng AI.
- Xuất báo cáo hệ thống.

---

## 3. Đối tượng sử dụng

Dự án hướng đến các nhóm người dùng:

- Sinh viên CNTT.
- Lập trình viên.
- Game thủ.
- Kỹ thuật viên IT.
- Người dùng phổ thông muốn kiểm tra máy tính.

---

## 4. Công nghệ sử dụng

- **Ngôn ngữ lập trình**: C#
- **Framework**: .NET 8 (LTS)
- **Giao diện**: WPF
- **Kiến trúc**: MVVM
- **Cơ sở dữ liệu**: SQLite
- **ORM**: Entity Framework Core
- **AI**: OpenAI API hoặc Google Gemini API
- **Quản lý mã nguồn**: Git, GitHub

---

## 5. Kiến trúc tổng thể

Hệ thống được chia thành các Module độc lập.

```text
PC Insight
│
├── UI Module
├── Scanner Module
├── Analyzer Module
├── AI Module
├── Database Module
├── Report Module
└── Update Module
```

---

## 6. Luồng hoạt động tổng thể

Người dùng ➔ Nhấn nút "Quét" ➔ Quét phần cứng ➔ Quét phần mềm ➔ Quét Runtime ➔ Phân tích ➔ AI đưa ra khuyến nghị ➔ Hiển thị kết quả ➔ Xuất báo cáo

---

## 7. Mười luồng chính của hệ thống

### Luồng 1 - Quét phần cứng (Hardware Scan)
- **Chức năng**: Quét CPU, RAM, GPU, ổ cứng, Mainboard, BIOS, phiên bản Windows.
- **Kết quả**: Hiển thị đầy đủ cấu hình phần cứng.

### Luồng 2 - Quét phần mềm (Software Scan)
- **Chức năng**: Kiểm tra Visual Studio, Git, SQL Server, Docker, Office, Java, Python, NodeJS.
- **Kết quả**: Danh sách phần mềm đã cài.

### Luồng 3 - Quét Runtime (Runtime Scan)
- **Chức năng**: Kiểm tra .NET Runtime, .NET SDK, Java Runtime, Python, NodeJS, DirectX, Visual C++ Redistributable.
- **Kết quả**: Danh sách Runtime đang có.

### Luồng 4 - Phân tích khả năng tương thích (Compatibility Analysis)
- **Chức năng**: So sánh CPU, RAM, GPU, Runtime; Chấm điểm tương thích; Đưa ra kết luận.
- **Ví dụ**:
  - Visual Studio: 95%
  - Unity: 82%
  - Photoshop: 75%

### Luồng 5 - AI Advisor
- **Chức năng**: Phân tích kết quả quét, Giải thích nguyên nhân, Đề xuất nâng cấp, Đề xuất Runtime còn thiếu, Đề xuất tối ưu hệ thống.

### Luồng 6 - Project Analyzer
- **Chức năng**: Đọc Project (`.csproj`, `package.json`, `requirements.txt`, `pom.xml`).
- **Phát hiện**: Thiếu SDK, Thiếu Package, Thiếu Runtime.

### Luồng 7 - Driver Analyzer
- **Chức năng**: Kiểm tra Driver GPU, Audio, Network, Kiểm tra phiên bản Driver và Đề xuất cập nhật.

### Luồng 8 - Dự đoán hiệu năng
- **Chức năng**: Ước lượng CPU sử dụng, RAM sử dụng, FPS, Thời gian Build, Hiệu năng tổng thể.

### Luồng 9 - Xuất báo cáo
- **Cho phép xuất**: PDF, Excel.
- **Báo cáo gồm**: Phần cứng, Phần mềm, Runtime, Đánh giá, Khuyến nghị AI.

### Luồng 10 - Tự động khắc phục (Auto Fix)
- **Chức năng**: Cài Runtime còn thiếu, Cài SDK, Cài Dependencies, Kiểm tra lại sau khi cài.
- *(Đây là tính năng dự kiến của phiên bản 3.0)*

---

## 8. Bốn luồng cốt lõi

Phiên bản đầu tiên của PC Insight chỉ tập trung vào bốn luồng quan trọng nhất:

**Hardware Scan ➔ Software Scan ➔ Runtime Scan ➔ Compatibility Analysis**

Bốn luồng này là nền tảng của toàn bộ hệ thống.

---

## 9. Lộ trình phát triển

- **Phiên bản 1.0**: Hardware Scanner
- **Phiên bản 1.1**: Software Scanner
- **Phiên bản 1.2**: Runtime Scanner
- **Phiên bản 1.3**: Compatibility Analysis
- **Phiên bản 1.4**: AI Advisor
- **Phiên bản 1.5**: Report Generator
- **Phiên bản 2.0**: Project Analyzer
- **Phiên bản 2.1**: Driver Analyzer
- **Phiên bản 2.2**: Performance Prediction
- **Phiên bản 3.0**: Auto Fix

---

## 10. Mục tiêu cuối cùng

PC Insight hướng đến trở thành một công cụ giúp người dùng:

- Hiểu rõ cấu hình máy tính.
- Biết máy còn thiếu thành phần nào.
- Đánh giá khả năng chạy ứng dụng hoặc game.
- Phân tích môi trường lập trình.
- Đưa ra khuyến nghị thông minh bằng AI.
- Hỗ trợ tối ưu và nâng cấp hệ thống.
