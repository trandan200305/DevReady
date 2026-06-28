# Các ca sử dụng (Use Cases)

## 1. Các Tác nhân (Actors)
- **Sinh viên IT / Lập trình viên**: Cần setup môi trường, cài đặt IDE, kiểm tra lỗi build do thiếu thư viện.
- **Game thủ**: Cần kiểm tra cấu hình chơi game.
- **Kỹ thuật viên IT**: Cần công cụ chẩn đoán nhanh, xuất báo cáo tình trạng máy cho khách.

## 2. Biểu đồ Use Case

```mermaid
usecaseDiagram
    actor "Người dùng" as User
    actor "Hệ thống AI" as AI
    
    usecase "Quét phần cứng & phần mềm" as UC1
    usecase "Kiểm tra tương thích (Game/App)" as UC2
    usecase "Nhận tư vấn nâng cấp" as UC3
    usecase "Tự động cài đặt Runtime (V3.0)" as UC4
    usecase "Xuất báo cáo (PDF/Excel)" as UC5
    
    User --> UC1
    User --> UC2
    User --> UC3
    User --> UC5
    
    UC3 <-- AI : "Phân tích và Sinh lời khuyên"
    User --> UC4
```

## 3. Chi tiết Use Case
- **Kiểm tra tương thích**: Người dùng chọn một phần mềm/game từ danh sách (ví dụ: Visual Studio 2022). Hệ thống sẽ so sánh yêu cầu cấu hình tối thiểu/đề nghị với cấu hình máy và đưa ra điểm số (0-100%).
- **Tư vấn nâng cấp**: Dựa vào điểm nghẽn (Bottleneck) phát hiện được (ví dụ: RAM luôn đầy khi mở 3 tab), AI sẽ đề xuất mua thêm RAM thay vì mua CPU mới.
