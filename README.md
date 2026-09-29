# 🛒 eShop - Clean Architecture & Blazor

## 👩‍🎓 Thông tin sinh viên

| Thông tin | Nội dung |
|---|---|
| **Họ và tên** | Trần Thị Hương Giang |
| **Khóa** | K57 |
| **Ngành** | Tin học kinh tế |
| **Trường** | Trường Đại học Kinh tế - Đại học Huế |
| **Môn học / Nội dung học tập** | Lập trình Web với C#, Blazor và Clean Architecture |

---

# 📌 Giới thiệu dự án

**eShop** là dự án ứng dụng Web bán hàng được xây dựng trong quá trình học tập và thực hành lập trình Web với **C# / .NET / Blazor**.

Dự án được phát triển dựa trên mô hình **Clean Architecture**, nhằm tách biệt các thành phần của hệ thống thành các lớp riêng biệt như:

- Core Business
- Use Cases
- Data Store
- Web / Presentation

Dự án ban đầu sử dụng dữ liệu hard-coded để minh họa cách tổ chức kiến trúc, sau đó được mở rộng để thực hành truy cập cơ sở dữ liệu bằng **SQL Server**, **Dapper** và quản lý trạng thái giỏ hàng.

---

# 🏗️ Kiến trúc dự án

Dự án được tổ chức theo nguyên tắc **Clean Architecture**.

```text
eShop
│
├── eShop.CoreBusiness
│   └── Entities / Business Models
│
├── eShop.UseCases
│   ├── Interfaces
│   ├── Search Product
│   ├── View Product
│   ├── Shopping Cart
│   └── Order
│
├── Plugins
│   │
│   ├── eShop.DataStore.HardCode
│   │
│   ├── eShop.DataStore.SQL.Dapper
│   │
│   ├── eShop.ShoppingCartLocalStorage
│   │
│   └── eShop.StateStore.DI
│
└── eShop.Web
    ├── Components
    ├── Pages
    ├── Layout
    └── Authentication
