# HƯỚNG DẪN THỰC HÀNH - SMARTEX3 UI SKELETON

## 📋 Tổng quan
Project này chứa các giao diện (UI skeleton) được copy từ SmartEx3. 
Tất cả các chức năng nghiệp vụ đã được loại bỏ, chỉ giữ lại cấu trúc giao diện để bạn tự thực hành.

## 📁 Cấu trúc đã tạo

```
ThucHanhLaiProjectt/
├── Forms/
│   ├── FormLoginAnimation.cs           [SKELETON] - Form đăng nhập với animation
│   └── FormLoginAnimation.Designer.cs  [COMPLETE] - Giao diện login
│
├── UserControls/
│   ├── UC_Overview.cs                  [SKELETON] - Màn hình tổng quan
│   ├── UC_Overview.Designer.cs         [COMPLETE] - Giao diện overview
│   ├── UC_Transaction.cs               [SKELETON] - Quản lý giao dịch
│   └── UC_Transaction.Designer.cs      [COMPLETE] - Giao diện transaction
│
└── THUC_HANH_GUIDE.md                  [THIS FILE]
```

## 🎨 Các giao diện đã tạo

### 1. FormLoginAnimation
**Giao diện:** ✅ Hoàn chỉnh
**Chức năng cần thực hiện:**
- [ ] LoadAnimationImages() - Load ảnh animation khi typing
- [ ] PerformLogin() - Xử lý đăng nhập
- [ ] PerformRegister() - Xử lý đăng ký
- [ ] ValidateLoginInput() - Validate form đăng nhập
- [ ] ValidateRegisterInput() - Validate form đăng ký
- [ ] ToggleLoginRegisterMode() - Chuyển đổi login/register
- [ ] ShowPasswordCoverImage() - Hiển thị avatar che mắt khi nhập password

### 2. UC_Overview
**Giao diện:** ✅ Hoàn chỉnh  
**Các thẻ hiển thị:**
- 💳 SỐ DƯ (Balance Card)
- 💰 THU NHẬP (Income Card)
- 💸 CHI TIÊU (Expense Card)
- 📊 Biểu đồ phân loại chi tiêu (Chart Panel 1)
- 📈 Biểu đồ xu hướng (Chart Panel 2)

**Chức năng cần thực hiện:**
- [ ] LoadOverviewData() - Load dữ liệu tổng quan
- [ ] UpdateBalanceCard() - Cập nhật số dư
- [ ] UpdateIncomeCard() - Cập nhật thu nhập
- [ ] UpdateExpenseCard() - Cập nhật chi tiêu
- [ ] LoadCategoryChart() - Vẽ biểu đồ phân loại (Pie Chart)
- [ ] LoadTrendChart() - Vẽ biểu đồ xu hướng (Line/Bar Chart)

### 3. UC_Transaction
**Giao diện:** ✅ Hoàn chỉnh  
**Các thành phần:**
- ➕ Button Thêm
- ✏️ Button Sửa
- 🗑️ Button Xóa
- DataGridView với các cột: Ngày, Danh mục, Số tiền, Ghi chú

**Chức năng cần thực hiện:**
- [ ] BtnAdd_Click - Mở form thêm giao dịch
- [ ] BtnEdit_Click - Mở form sửa giao dịch
- [ ] BtnDelete_Click - Xóa giao dịch (có confirm)
- [ ] LoadTransactions() - Load danh sách giao dịch
- [ ] RefreshData() - Refresh lại DataGridView
- [ ] FormatTransactionData() - Format tiền tệ, màu sắc
- [ ] DgvTransactions_CellDoubleClick - Double click để edit
- [ ] DgvTransactions_SelectionChanged - Enable/disable buttons

## 🎯 Gợi ý thứ tự thực hành

### Bước 1: Setup cơ bản
1. Tạo Models (User, Transaction, Category)
2. Setup Entity Framework (nếu dùng database)
3. Tạo các Service interfaces (IUserService, ITransactionService)

### Bước 2: Xây dựng Login
1. Implement PerformLogin()
2. Implement ValidateLoginInput()
3. Test login flow
4. (Optional) Implement animation

### Bước 3: Xây dựng Transaction Management
1. Tạo form thêm/sửa giao dịch (FormTransactionEdit)
2. Implement BtnAdd_Click
3. Implement LoadTransactions()
4. Implement BtnEdit_Click
5. Implement BtnDelete_Click

### Bước 4: Xây dựng Overview
1. Implement UpdateBalanceCard()
2. Implement UpdateIncomeCard()
3. Implement UpdateExpenseCard()
4. (Optional) Implement charts với LiveCharts hoặc Chart control

## 💡 Tips & Best Practices

### Về Service Layer
```csharp
// Tạo interface cho services
public interface ITransactionService
{
    List<Transaction> GetAllTransactions(int userId);
    Transaction GetById(int id);
    bool Add(Transaction transaction);
    bool Update(Transaction transaction);
    bool Delete(int id);
}
```

### Về Data Validation
```csharp
// Validate trước khi save
private bool ValidateTransaction()
{
    if (string.IsNullOrWhiteSpace(txtCategory.Text))
    {
        MessageBox.Show("Vui lòng nhập danh mục!");
        return false;
    }
    
    if (numAmount.Value == 0)
    {
        MessageBox.Show("Số tiền phải khác 0!");
        return false;
    }
    
    return true;
}
```

### Về DataGridView Formatting
```csharp
// Format tiền tệ và màu sắc
private void FormatDataGridView()
{
    dgvTransactions.Columns["Amount"].DefaultCellStyle.Format = "N0";
    
    foreach (DataGridViewRow row in dgvTransactions.Rows)
    {
        decimal amount = Convert.ToDecimal(row.Cells["Amount"].Value);
        if (amount > 0)
            row.DefaultCellStyle.ForeColor = Color.Green;
        else
            row.DefaultCellStyle.ForeColor = Color.Red;
    }
}
```

## 📚 Tài nguyên cần thiết

### NuGet Packages nên cài
- EntityFramework (hoặc Dapper) - Nếu dùng database
- LiveCharts.WinForms - Nếu muốn vẽ biểu đồ đẹp
- Bunifu.UI.WinForms - UI controls (đã có trong SmartEx3)

### Animation Resources
Nếu muốn thực hiện animation cho login:
- Copy thư mục `Resources/animation/` từ SmartEx3
- Bao gồm: textbox_user_1.jpg -> textbox_user_23.jpg
- textbox_password.png

## ❓ Câu hỏi thường gặp

**Q: Tôi có cần implement hết tất cả chức năng không?**
A: Không, bạn có thể bắt đầu với các chức năng cơ bản (CRUD Transaction) rồi mở rộng dần.

**Q: Database nào nên dùng?**
A: SQL Server Express (như SmartEx3) hoặc SQLite cho đơn giản.

**Q: Animation có bắt buộc không?**
A: Không, đó chỉ là feature thêm. Tập trung vào logic nghiệp vụ trước.

**Q: Tôi có thể thay đổi giao diện không?**
A: Có, bạn hoàn toàn có thể customize, đây chỉ là template tham khảo.

## 📝 Checklist hoàn thành

### Core Features (Bắt buộc)
- [ ] Login/Logout functionality
- [ ] Add Transaction
- [ ] Edit Transaction
- [ ] Delete Transaction
- [ ] View Transaction List
- [ ] Display Balance/Income/Expense

### Advanced Features (Tùy chọn)
- [ ] User Registration
- [ ] Login Animation
- [ ] Category Management
- [ ] Charts & Visualization
- [ ] Reports
- [ ] AI Assistant (Advanced)
- [ ] Export to Excel/PDF

## 🎓 Học từ SmartEx3

Bạn luôn có thể tham khảo code từ SmartEx3 project gốc để:
- Xem cách implement các chức năng
- Hiểu cách kết nối database
- Học cách tổ chức code
- Tham khảo UI/UX patterns

**Nhưng hãy cố gắng tự code trước khi xem đáp án!**

---

Chúc bạn thực hành vui vẻ! 💪
Nếu gặp khó khăn, hãy tham khảo code gốc từ SmartEx3 hoặc tìm kiếm tài liệu online.
