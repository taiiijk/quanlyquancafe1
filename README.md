# PHẦN MỀM QUẢN LÝ QUÁN CAFE

WinForms + Guna UI + SQL Server

---

## 1. Công nghệ sử dụng

- Ngôn ngữ: C#
- Giao diện: Windows Forms, Guna UI2
- Cơ sở dữ liệu: SQL Server
- Quản lý thư viện: NuGet (PackageReference)
- Kiến trúc: DAO – DTO

---

## 2. Cơ sở dữ liệu

Hệ thống sử dụng các bảng sau:

- account – Quản lý tài khoản đăng nhập
- bill – Hóa đơn
- billinfo – Chi tiết hóa đơn
- food – Món ăn / đồ uống
- foodcategory – Danh mục món
- CongThuc – Công thức món
- NguyenLieu – Nguyên liệu
- PhieuNhapKho – Phiếu nhập kho
- ChiTietPN – Chi tiết phiếu nhập
- tablefood – Bàn

---

## 3. Chức năng hệ thống

### 3.1. Chức năng cho Thu ngân (Staff)

- Đăng nhập hệ thống
- Quản lý bàn:
  - Mở bàn
  - Chuyển bàn
  - Gộp bàn
- Gọi món:
  - Thêm món vào hóa đơn
  - Món có tùy chọn (ghi chú)
- Thanh toán:
  - Áp dụng giảm giá
  - Xem hóa đơn trước khi thanh toán
  - Thanh toán hóa đơn

---

### 3.2. Chức năng cho Admin

- Trang điều khiển (Dashboard)
- Trang thống kê – báo cáo
- Quản lý kho:
  - Nhập kho
  - Quản lý nguyên liệu
- Quản lý món:
  - Thêm / sửa / xóa món
  - Khai báo công thức món
- Quản lý danh mục món
- Quản lý số lượng bàn
- Quản lý tài khoản nhân viên

---

## 4. Tài khoản đăng nhập mặc định

| Quyền | Tài khoản | Mật khẩu |
| ----- | --------- | -------- |
| Admin | admin     | admin    |
| Staff | staff     | 1        |

---

## 5. Cấu trúc project

- QuanLyQuanCafe:
- DAO
- DTO
- Forms
- Resources
- Database
- App.config
- quanlyquancafe.csproj
- quanlyquancafe.sln

---

## 6. Hướng dẫn tải code và chạy chương trình

### Bước 1: Clone source code

---

### Bước 2: Tạo cơ sở dữ liệu

1. Mở SQL Server Management Studio
2. Mở file Database/cafe.sql
3. Execute để tạo database và dữ liệu mẫu

---

### Bước 3: Cấu hình kết nối

Mở file App.config và chỉnh lại connection string nếu cần:

Data Source="Datasource của bạn";
Initial Catalog=phanmemquanly;
Integrated Security=True

### Bước 4: Restore thư viện

1. Mở file quanlyquancafe.sln
2. Chuột phải Solution
3. Chọn Restore NuGet Packages

(Guna UI sẽ được tải tự động)

---

### Bước 5: Chạy chương trình

- Nhấn Start (F5) để chạy ứng dụng

---

## 7. Sinh viên thực hiện

- 22520294 Vũ Quang Dũng
- 24521562 Võ Ngọc Tài
- 22520831 Nguyễn Ngạn Lực

## ⚠️ Lỗi build MSB3821 (.resx bị chặn – Mark of the Web)

## Cách khắc phục (bắt buộc làm 1 lần)

1. **Đóng Visual Studio**
2. Mở thư mục chứa project
3. Mở **PowerShell / Terminal** tại thư mục đó
4. Chạy lệnh sau để gỡ chặn toàn bộ file:

```powershell
Get-ChildItem -Recurse | Unblock-File
Get-ChildItem -Recurse | Unblock-File


```
