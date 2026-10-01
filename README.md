# 🛒 eShop - Clean Architecture & Blazor Server

## 👩🎓 Thông tin sinh viên


| **Tác giả** | Trần Thị Hương Giang |
|---|---|
| **Mã sinh viên** | 23K4080055 |
| **Lớp** | K57 Tin học kinh tế |
| **Trường** | Trường Đại học Kinh tế - Đại học Huế |
| **Môn học** | Lập trình ứng dụng Web |

---

# 📌 Giới thiệu dự án

## 1. Tổng quan dự án
**eShop** là nền tảng website thương mại điện tử chuyên ngành **bán lẻ mỹ phẩm, mỹ phẩm trang điểm và sản phẩm làm đẹp** (Beauty & Cosmetics Store), kinh doanh các dòng sản phẩm tiêu biểu như: *kem nền (Foundation), phấn má (Blush), phấn mắt (Eye Shadow), tạo khối (Contour Kit),...*
Ứng dụng được thiết kế nhằm mang lại trải nghiệm mua sắm trực tuyến trực quan, mượt mà cho khách hàng, đồng thời cung cấp công cụ quản lý, phê duyệt đơn hàng chuẩn xác cho người quản trị. Dự án được xây dựng dựa trên công nghệ hiện đại **.NET 6**, **C#**, giao diện thời gian thực **Blazor Server** và tuân thủ chặt chẽ nguyên lý **Clean Architecture** (Onion Architecture) kết hợp **Plugin Architecture**.

## 2. Đối tượng sử dụng (Target Users)
Hệ thống được thiết kế hướng tới 2 nhóm người dùng chính với quyền hạn và không gian làm việc tách biệt:
| Nhóm người dùng | Mô tả vai trò | Nhu cầu chính |
|---|---|---|
| **Khách hàng (Customer / End-User)** | Người tiêu dùng truy cập website qua phân hệ *Customer Portal*. Không yêu cầu thủ tục đăng ký tài khoản phức tạp. | Tìm kiếm, xem chi tiết sản phẩm, quản lý giỏ hàng và đặt hàng trực tuyến nhanh chóng. |
| **Quản trị viên (Admin / Store Manager)** | Nhân sự vận hành cửa hàng, được cấp quyền truy cập phân hệ *Admin Portal* thông qua cơ chế xác thực bảo mật (*Cookie Authentication*). | Theo dõi các đơn đặt hàng mới, kiểm tra thông tin chi tiết người mua, duyệt xử lý đơn và tra cứu lịch sử đơn hàng. |
---

# 🏗️ Kiến trúc & Cấu trúc thư mục dự án

Hệ thống được tổ chức phân tầng rõ ràng theo nguyên tắc **Dependency Inversion** của Clean Architecture:

```text
eShop
│
├── 📂 eShop.CoreBussiness                  # [Tầng Core] Chứa thực thể và quy tắc nghiệp vụ lõi (Enterprise Business Rules)
│   ├── Models                             # Các thực thể nghiệp vụ: Product, Order, OrderLineItem
│   └── Services                           # Dịch vụ nghiệp vụ độc lập: OrderService, IOrderService
│
├── 📂 eShop.UseCases                       # [Tầng Application] Chứa các ca sử dụng của hệ thống (Application Business Rules)
│   ├── PluginInterfaces                   # Định nghĩa các cổng trừu tượng (Interfaces / Ports)
│   │   ├── DataStore                      # IProductRepository, IOrderRepository
│   │   ├── StateStore                     # IShoppingCartStateStore
│   │   └── UI                             # IShoppingCart
│   ├── SearchProductScreen                # Ca sử dụng: Tìm kiếm sản phẩm
│   ├── ViewProductScreen                  # Ca sử dụng: Xem sản phẩm, thêm vào giỏ hàng
│   ├── ShoppingCartScreen                 # Ca sử dụng: Xem giỏ hàng, cập nhật số lượng, xóa, đặt hàng
│   ├── OrderConfirmationScreen           # Ca sử dụng: Xem trang xác nhận đơn hàng
│   └── AdminPortal                        # Nhóm Use Case cho người quản trị
│       ├── OutstandingOrdersScreen        # Xem danh sách đơn hàng chờ xử lý
│       ├── OrderDetailScreen              # Xem chi tiết đơn hàng, duyệt đơn (ProcessOrder)
│       └── ProcessedOrdersScreen          # Xem danh sách đơn hàng đã xử lý
│
├── 📂 Plugins                              # [Tầng Infrastructure / Adapters] Triển khai chi tiết kỹ thuật bên ngoài
│   ├── eShop.DataStore.HardCode           # Plugin lưu trữ dữ liệu mẫu trong RAM (In-memory Dictionary)
│   ├── eShop.DataStore.SQL.Dapper         # Plugin truy xuất CSDL SQL Server sử dụng Micro-ORM Dapper
│   │   ├── Helpers                        # IDataAccess, DataAccess
│   │   ├── ProductRepository.cs
│   │   └── OrderRepository.cs
│   ├── eShop.ShoppingCart.Local           # Plugin quản lý giỏ hàng phía Client qua LocalStorage (IJSRuntime)
│   └── eShop.StateStore.DI                # Plugin đồng bộ trạng thái giỏ hàng qua Dependency Injection & C# Actions
│
├── 📂 eShop.Web.Modules                    # [Tầng UI Modules] Các Razor Class Libraries (RCL) giao diện tách rời
│   ├── eShop.Web.Common                   # Component dùng chung: LoginComponent, SearchBarComponent, ViewModels
│   ├── eShop.Web.CustomerPortal           # Giao diện Khách hàng: Trang sản phẩm, Giỏ hàng, Đặt hàng (PlaceOrderComponent)
│   └── eShop.Web.AdminPortal              # Giao diện Quản trị: Quản lý đơn hàng, duyệt đơn, chi tiết đơn
│
└── 📂 eShop.Web                            # [Tầng Presentation Host] Dự án Blazor Server chính để khởi chạy ứng dụng
    ├── Controllers                        # Controller xử lý xác thực đăng nhập (Cookie Authentication)
    ├── Pages                              # Host pages: _Host.cshtml, _Layout.cshtml
    ├── Shared                             # Bố cục giao diện chung: MainLayout.razor, NavMenu.razor
    ├── wwwroot                            # Tài nguyên tĩnh: CSS, Bootstrap, Open Iconic fonts
    ├── appsettings.json                   # Cấu hình ConnectionStrings và App Settings
    └── Program.cs                         # Cấu hình nạp DI container, Authentication, Routing và Middleware
