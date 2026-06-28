# Luồng hệ thống (System Flows)

Tài liệu này mô tả chi tiết các luồng hoạt động chính của hệ thống PC Insight.

## 1. Luồng hoạt động tổng thể (Main Flow)

```mermaid
graph TD
    A[Người dùng] -->|Nhấn nút Quét| B(Quét phần cứng)
    B --> C(Quét phần mềm)
    C --> D(Quét Runtime)
    D --> E(Phân tích tính tương thích)
    E --> F(AI phân tích & đưa ra lời khuyên)
    F --> G[Hiển thị kết quả lên UI]
    G --> H[Xuất báo cáo PDF/Excel]
```

## 2. Luồng phân tích dự án (Project Analyzer - V2.0)
Hệ thống đọc các file cấu hình của project để tìm ra các Dependency còn thiếu trên máy tính hiện tại.

```mermaid
sequenceDiagram
    participant User as Người dùng
    participant App as PC Insight
    participant File as Project Files (.csproj, package.json)
    
    User->>App: Chọn thư mục dự án
    App->>File: Phân tích file cấu hình
    File-->>App: Trả về danh sách package, SDK yêu cầu
    App->>App: So sánh với Runtime hiện tại của PC
    App-->>User: Hiển thị các SDK/Runtime còn thiếu
```

## 3. Luồng AI Advisor
1. Đóng gói dữ liệu quét (JSON)
2. Gửi request tới OpenAI API / Gemini API
3. Nhận phản hồi dạng văn bản tự nhiên
4. Parse và hiển thị lên giao diện theo từng danh mục (Lỗi, Cảnh báo, Đề xuất nâng cấp).
