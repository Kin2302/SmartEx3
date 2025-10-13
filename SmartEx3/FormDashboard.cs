using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;
using SmartEx3.Models;
using SmartEx3.Services;
using SmartEx3.Forms;

namespace SmartEx3
{
    public partial class FormDashboard : Form
    {
        #region Private Fields

        // Tham chiếu đến module hiện tại đang được load
        private UserControl currentModule;
        
        // Service manager để thực hiện các thao tác dữ liệu
        private ServiceManager _serviceManager;
        
        // Người dùng hiện tại đã đăng nhập
        private User _currentUser;

        #endregion

        #region Constructor and Initialization

        // Constructor: Khởi tạo form dashboard với thông tin người dùng
        public FormDashboard(User user = null)
        {
            _currentUser = user;
            
            InitializeComponent();
            InitializeServices();
            InitializeLogic();
        }

        // InitializeServices: Khởi tạo service manager để quản lý các service
        private void InitializeServices()
        {
            // Khởi tạo service manager
            _serviceManager = new ServiceManager();
        }

        // InitializeLogic: Đăng ký các event handler cho form
        private void InitializeLogic()
        {
            // Đăng ký event handler cho form load
            this.Load += FormDashboard_Load;
        }

        #endregion

        #region Form Load and Authentication

        // FormDashboard_Load: Xử lý khi form được load lần đầu
        private void FormDashboard_Load(object sender, EventArgs e)
        {
            // Nếu đã có user (được truyền từ Program.cs sau khi login), không cần authenticate lại
            if (_currentUser == null)
            {
                // Trường hợp này chỉ xảy ra khi FormDashboard được mở trực tiếp mà không qua login
                MessageBox.Show("Vui lòng đăng nhập lại!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
                return;
            }

            // Cập nhật thông báo chào mừng
            UpdateWelcomeMessage();
            
            // Tải module Overview mặc định
            LoadModule(ucOverview, "Dashboard - Tổng quan chi tiêu");
            LoadOverviewData();
        }

        // AuthenticateUser: Hiển thị form đăng nhập để xác thực người dùng
        private bool AuthenticateUser()
        {
            // Hiển thị form đăng nhập và lấy thông tin user đã xác thực
            using (var loginForm = new Forms.FormLoginAnimation(_serviceManager))
            {
                if (loginForm.ShowDialog() == DialogResult.OK)
                {
                    _currentUser = loginForm.AuthenticatedUser;
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region Module Loading

        // LoadModule: Tải một module (UserControl) vào panel chính
        private void LoadModule(UserControl module, string headerTitle)
        {
            try
            {
                // Xóa tất cả controls hiện tại trong panel
                panelMainContent.Controls.Clear();

                // Dispose module cũ nếu khác module mới để giải phóng bộ nhớ
                if (currentModule != null && currentModule != module)
                {
                    currentModule.Dispose();
                }

                // Gán module mới
                currentModule = module;
                module.Dock = DockStyle.Fill;
                module.BackColor = Color.FromArgb(241, 244, 254);

                // Cấu hình module với dữ liệu người dùng
                ConfigureModuleWithUserData(module);

                // Thêm module vào panel
                panelMainContent.Controls.Add(module);

                // Cập nhật tiêu đề header với lời chào theo thời gian
                string timeGreeting = GetTimeBasedGreeting();
                lblHeaderTitle.Text = $"{timeGreeting} - {headerTitle}";

                // Đưa module lên foreground và refresh
                module.BringToFront();
                panelMainContent.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải module: {ex.Message}", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ConfigureModuleWithUserData: Cấu hình module với dữ liệu người dùng hiện tại
        private void ConfigureModuleWithUserData(UserControl module)
        {
            if (_currentUser == null) return;

            // Cấu hình cho module Giao dịch
            if (module is SmartEx3.UserControls.UC_Transaction transactionModule)
            {
                transactionModule.CurrentUserId = _currentUser.UserId;
            }
            
            // Cấu hình cho module Báo cáo
            if (module is SmartEx3.UserControls.UC_Reports reportsModule)
            {
                reportsModule.Initialize(_serviceManager, _currentUser.UserId);
            }

            // Cấu hình cho module AI Assistant
            if (module is SmartEx3.UserControls.UC_AIAssistant aiModule)
            {
                aiModule.Initialize(_serviceManager, _currentUser.UserId);
            }
        }

        // LoadModuleByType: Tạo và tải module dựa trên tên type
        private void LoadModuleByType(string moduleTypeName, string headerTitle)
        {
            try
            {
                // Lấy type của module từ namespace SmartEx3.UserControls
                Type moduleType = Type.GetType($"SmartEx3.UserControls.{moduleTypeName}");
                
                if (moduleType != null)
                {
                    // Tạo instance mới của module
                    UserControl module = (UserControl)Activator.CreateInstance(moduleType);
                    LoadModule(module, headerTitle);
                }
                else
                {
                    MessageBox.Show($"Không tìm thấy module: {moduleTypeName}", "Thông báo", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tạo module {moduleTypeName}: {ex.Message}", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Data Loading

        // LoadOverviewData: Tải và hiển thị dữ liệu tổng quan tài chính
        private void LoadOverviewData()
        {
            if (currentModule is SmartEx3.UserControls.UC_Overview overviewModule && _currentUser != null)
            {
                try
                {
                    // Lấy tất cả giao dịch của user
                    var transactions = _serviceManager.TransactionService.GetTransactionsByUserId(_currentUser.UserId);
                    
                    // Tính tổng thu nhập (Amount > 0)
                    var totalIncome = transactions.Where(t => t.Amount > 0).Sum(t => t.Amount);
                    
                    // Tính tổng chi tiêu (Amount < 0, lấy giá trị tuyệt đối)
                    var totalExpense = Math.Abs(transactions.Where(t => t.Amount < 0).Sum(t => t.Amount));
                    
                    // Tính số dư = Thu nhập - Chi tiêu
                    var balance = totalIncome - totalExpense;

                    // Cập nhật dữ liệu tài chính lên UI
                    overviewModule.UpdateFinancialData(
                        balance: balance,
                        income: totalIncome,
                        expense: totalExpense
                    );

                    // Tải dữ liệu cho biểu đồ danh mục
                    LoadCategoryChartData(overviewModule);
                    
                    // Tải dữ liệu cho biểu đồ xu hướng
                    LoadTrendChartData(overviewModule);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi tải dữ liệu tổng quan: {ex.Message}", "Lỗi", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // LoadCategoryChartData: Tải dữ liệu biểu đồ phân loại chi tiêu theo danh mục
        private void LoadCategoryChartData(SmartEx3.UserControls.UC_Overview overviewModule)
        {
            try 
            {
                DateTime endDate = DateTime.Now.Date;
                DateTime startDate = endDate.AddDays(-6);
                // Lấy tổng chi tiêu theo từng danh mục
                var categorySummary = _serviceManager.TransactionService.GetCategorySummaryByDateRange(_currentUser.UserId, startDate , endDate);
               

                
                if (categorySummary != null && categorySummary.Count > 0)
                {
                    // Cập nhật biểu đồ danh mục
                    overviewModule.UpdateCategoryChart(categorySummary);
                }
                else
                {
                    // Hiển thị placeholder nếu chưa có dữ liệu
                    overviewModule.SetChart1PlaceholderText("📊 Chưa có dữ liệu chi tiêu");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu biểu đồ danh mục: {ex.Message}", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // LoadTrendChartData: Tải dữ liệu biểu đồ xu hướng chi tiêu 7 ngày gần nhất
        private void LoadTrendChartData(SmartEx3.UserControls.UC_Overview overviewModule)
        {
            try
            {
                // Lấy khoảng thời gian 7 ngày gần nhất
                DateTime endDate = DateTime.Now.Date;
                DateTime startDate = endDate.AddDays(-6);

                // Lấy dữ liệu tổng hợp theo ngày
                var dailySummary = _serviceManager.TransactionService.GetDailySummary(_currentUser.UserId, startDate, endDate);
                
                var dailyExpense = new Dictionary<DateTime, decimal>();
                var dailyIncome = new Dictionary<DateTime, decimal>();

                // Lặp qua 7 ngày
                for (int i = 0; i < 7; i++)
                {
                    DateTime date = startDate.AddDays(i);
                    
                    if (dailySummary.ContainsKey(date))
                    {
                        // Lấy giao dịch trong ngày
                        var transactionsOnDate = _serviceManager.TransactionService
                            .GetTransactionsByDateRange(date, date)
                            .Where(t => t.UserId == _currentUser.UserId);
                        
                        // Tính thu nhập và chi tiêu trong ngày
                        decimal incomeTotal = transactionsOnDate.Where(t => t.Amount > 0).Sum(t => t.Amount);
                        decimal expenseTotal = Math.Abs(transactionsOnDate.Where(t => t.Amount < 0).Sum(t => t.Amount));
                        
                        dailyIncome[date] = incomeTotal;
                        dailyExpense[date] = expenseTotal;
                    }
                    else
                    {
                        // Không có giao dịch trong ngày, đặt giá trị = 0
                        dailyIncome[date] = 0;
                        dailyExpense[date] = 0;
                    }
                }

                // Cập nhật biểu đồ xu hướng
                overviewModule.UpdateTrendChartSimple(dailyExpense, dailyIncome);
                
                if (!dailySummary.Any())
                {
                    // Hiển thị placeholder nếu chưa có dữ liệu
                    overviewModule.SetChart2PlaceholderText("📈 Chưa có dữ liệu giao dịch trong 7 ngày qua");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu biểu đồ xu hướng: {ex.Message}", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region UI Updates

        // UpdateWelcomeMessage: Cập nhật lời chào mừng dựa trên thời gian trong ngày
        private void UpdateWelcomeMessage()
        {
            // Lấy lời chào theo thời gian
            string timeGreeting = GetTimeBasedGreeting();
            string userName = _currentUser?.Name ?? "Người dùng";
            lblHeaderTitle.Text = $"{timeGreeting} \n Dashboard Tổng quan";
        }

        // GetTimeBasedGreeting: Lấy lời chào phù hợp dựa trên thời gian trong ngày
        private string GetTimeBasedGreeting()
        {
            int hour = DateTime.Now.Hour;

            // 5:00 - 11:59: Buổi sáng
            if (hour >= 5 && hour < 12)
                return "🌅 Chào buổi sáng " + _currentUser.Name;
            // 12:00 - 16:59: Buổi chiều
            else if (hour >= 12 && hour < 17)
                return "☀️ Chào buổi chiều " + _currentUser.Name;
            // 17:00 - 21:59: Buổi tối
            else if (hour >= 17 && hour < 22)
                return "🌆 Chào buổi tối " + _currentUser.Name;
            // 22:00 - 4:59: Buổi đêm
            else
                return "🌙 Chào buổi đêm " + _currentUser.Name;
        }

        #endregion

        #region Navigation Event Handlers

        // btnOverview_Click: Xử lý khi click nút Overview - Chuyển đến trang tổng quan
        private void btnOverview_Click(object sender, EventArgs e)
        {
            // Reset style của các nút
            ResetButtonStyles();
            btnOverview.BackColor = Color.FromArgb(241, 244, 254);
            
            // Tải module Overview
            LoadModule(currentModule is SmartEx3.UserControls.UC_Overview ? currentModule : new SmartEx3.UserControls.UC_Overview(), "Dashboard - Tổng quan chi tiêu");
            LoadOverviewData();
        }

        // btnTransactions_Click: Xử lý khi click nút Transactions - Chuyển đến trang quản lý giao dịch
        private void btnTransactions_Click(object sender, EventArgs e)
        {
            // Reset style và highlight nút được chọn
            ResetButtonStyles();
            btnTransactions.BackColor = Color.FromArgb(241, 244, 254);
            
            // Tải module Giao dịch
            LoadModuleByType("UC_Transaction", "Quản lý giao dịch");
        }

        // btnReports_Click: Xử lý khi click nút Reports - Chuyển đến trang phân tích và báo cáo
        private void btnReports_Click(object sender, EventArgs e)
        {
            // Reset style và highlight nút được chọn
            ResetButtonStyles();
            btnReports.BackColor = Color.FromArgb(241, 244, 254);
            
            // Tải module Báo cáo
            LoadReportsModule();
        }

        // btnAIAssistant_Click: Xử lý khi click nút AI Assistant - Chuyển đến trang trợ lý AI
        private void btnAIAssistant_Click(object sender, EventArgs e)
        {
            // Reset style và highlight nút được chọn
            ResetButtonStyles();
            btnAIAssistant.BackColor = Color.FromArgb(241, 244, 254);
            
            // Tải module AI Assistant
            LoadAIAssistantModule();
        }

        // btnSettings_Click: Xử lý khi click nút Settings - Chuyển đến trang cài đặt
        private void btnSettings_Click(object sender, EventArgs e)
        {
            // Reset style và highlight nút được chọn
            ResetButtonStyles();
            btnSettings.BackColor = Color.FromArgb(241, 244, 254);
            
            // Tải module Cài đặt
            LoadModuleByType("UC_Settings", "Cài đặt & Cá nhân hóa");
        }

        // lblHeaderTitle_Click: Event handler rỗng do Designer yêu cầu
        private void lblHeaderTitle_Click(object sender, EventArgs e)
        {
            // Empty event handler required by Designer
        }

        #endregion

        #region User Menu Actions

        // btnQuickSettings_Click: Hiển thị menu context với các tùy chọn người dùng
        private void btnQuickSettings_Click(object sender, EventArgs e)
        {
            // Tạo context menu
            var contextMenu = new ContextMenuStrip();
            
            // Thêm các menu item
            var profileItem = new ToolStripMenuItem("Thông tin cá nhân", null, (s, ev) => ShowUserProfile());
            var changePasswordItem = new ToolStripMenuItem("Đổi mật khẩu", null, (s, ev) => ChangePassword());
            var logoutItem = new ToolStripMenuItem("Đăng xuất", null, (s, ev) => Logout());
            var exitItem = new ToolStripMenuItem("Thoát ứng dụng", null, (s, ev) => ExitApplication());
            
            contextMenu.Items.AddRange(new ToolStripItem[] { profileItem, changePasswordItem, new ToolStripSeparator(), logoutItem, exitItem });
            
            // Hiển thị menu tại vị trí nút
            var buttonLocation = btnQuickSettings.PointToScreen(new Point(0, btnQuickSettings.Height));
            contextMenu.Show(buttonLocation);
        }

        // pictureBoxAvatar_Click: Hiển thị thông tin người dùng khi click vào avatar
        private void pictureBoxAvatar_Click(object sender, EventArgs e)
        {
            // Hiển thị thông tin người dùng khi click vào avatar
            ShowUserProfile();
        }

        // ShowUserProfile: Hiển thị dialog chứa thông tin chi tiết người dùng
        private void ShowUserProfile()
        {
            if (_currentUser != null)
            {
                // Tạo chuỗi hiển thị thông tin user
                string userInfo = $"Thông tin người dùng:\n\n" +
                                 $"Tên: {_currentUser.Name}\n" +
                                 $"Email: {_currentUser.Email}\n" +
                                 $"Thu nhập: {(_currentUser.Income?.ToString("N0") ?? "Chưa cập nhật")} ₫\n" +
                                 $"Mục tiêu: {(_currentUser.Goal?.ToString("N0") ?? "Chưa cập nhật")} ₫\n" +
                                 $"Ngày tạo: {_currentUser.CreatedAt?.ToString("dd/MM/yyyy") ?? "N/A"}";
                
                MessageBox.Show(userInfo, "Thông tin cá nhân", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // ChangePassword: Hiển thị form đổi mật khẩu (chức năng đang phát triển)
        private void ChangePassword()
        {
            // Chức năng đổi mật khẩu sẽ được phát triển sau
            MessageBox.Show("Chức năng đổi mật khẩu đang được phát triển!", "Thông báo", 
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Logout: Đăng xuất khỏi tài khoản hiện tại và quay về màn hình đăng nhập
        private void Logout()
        {
            // Xác nhận đăng xuất
            var result = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất?", "Xác nhận đăng xuất", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            
            if (result == DialogResult.Yes)
            {
                // Xóa thông tin user hiện tại
                _currentUser = null;
                this.Hide();
                
                // Hiển thị form đăng nhập
                if (AuthenticateUser())
                {
                    // Nếu đăng nhập thành công, cập nhật UI
                    UpdateWelcomeMessage();
                    RefreshCurrentModule();
                    this.Show();
                }
                else
                {
                    // Nếu hủy đăng nhập, đóng form
                    this.Close();
                }
            }
        }

        // ExitApplication: Thoát hoàn toàn khỏi ứng dụng
        private void ExitApplication()
        {
            // Xác nhận thoát ứng dụng
            var result = MessageBox.Show("Bạn có chắc chắn muốn thoát ứng dụng?", "Xác nhận thoát", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            
            if (result == DialogResult.Yes)
            {
                // Thoát hoàn toàn ứng dụng
                Application.Exit();
            }
        }

        #endregion

        #region Helper Methods

        // LoadReportsModule: Tải module báo cáo với khởi tạo đúng cách
        private void LoadReportsModule()
        {
            try
            {
                // Tái sử dụng module nếu đã tồn tại, nếu không thì tạo mới
                var reportsModule = currentModule is SmartEx3.UserControls.UC_Reports 
                    ? currentModule as SmartEx3.UserControls.UC_Reports
                    : new SmartEx3.UserControls.UC_Reports();

                // Khởi tạo module với service manager và user ID
                reportsModule.Initialize(_serviceManager, _currentUser.UserId);

                // Tải module vào panel
                LoadModule(reportsModule, "Phân tích & Báo cáo");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải module Phân tích: {ex.Message}\n\nChi tiết: {ex.StackTrace}", 
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // LoadAIAssistantModule: T tải module AI Assistant với khởi tạo đúng cách
        private void LoadAIAssistantModule()
        {
            try
            {
                // Tái sử dụng module nếu đã tồn tại, nếu không thì tạo mới
                var aiModule = currentModule is SmartEx3.UserControls.UC_AIAssistant 
                    ? currentModule as SmartEx3.UserControls.UC_AIAssistant
                    : new SmartEx3.UserControls.UC_AIAssistant();

                // Khởi tạo module với service manager và user ID
                aiModule.Initialize(_serviceManager, _currentUser.UserId);

                // Tải module vào panel
                LoadModule(aiModule, "Trợ lý AI thông minh");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải module AI: {ex.Message}\n\nChi tiết: {ex.StackTrace}", 
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // RefreshCurrentModule: Làm mới dữ liệu của module hiện tại
        private void RefreshCurrentModule()
        {
            // Làm mới dữ liệu module hiện tại dựa trên type
            if (currentModule is SmartEx3.UserControls.UC_Overview)
            {
                LoadOverviewData();
            }
            else if (currentModule is SmartEx3.UserControls.UC_Transaction transactionModule)
            {
                transactionModule.CurrentUserId = _currentUser?.UserId ?? 0;
                transactionModule.RefreshTransactions();
            }
            else if (currentModule is SmartEx3.UserControls.UC_Reports reportsModule)
            {
                reportsModule.RefreshData();
            }
            else if (currentModule is SmartEx3.UserControls.UC_AIAssistant aiModule)
            {
                aiModule.Initialize(_serviceManager, _currentUser?.UserId ?? 0);
            }
        }

        // ResetButtonStyles: Reset màu nền của tất cả các nút navigation về màu trắng
        private void ResetButtonStyles()
        {
            // Đặt lại màu nền tất cả các nút navigation về trắng
            btnOverview.BackColor = Color.White;
            btnTransactions.BackColor = Color.White;
            btnReports.BackColor = Color.White;
            btnAIAssistant.BackColor = Color.White;
            btnSettings.BackColor = Color.White;
        }

        #endregion

        #region Public Methods

        // RefreshOverviewData: Public method để làm mới dữ liệu trang Overview
        public void RefreshOverviewData()
        {
            // Public method để làm mới dữ liệu overview từ bên ngoài
            LoadOverviewData();
        }

        // NavigateToModule: Điều hướng đến một module cụ thể theo tên
        public void NavigateToModule(string moduleName)
        {
            // Điều hướng đến module cụ thể theo tên
            switch (moduleName.ToLower())
            {
                case "overview":
                    btnOverview_Click(null, null);
                    break;
                case "transactions":
                    btnTransactions_Click(null, null);
                    break;
                case "reports":
                    btnReports_Click(null, null);
                    break;
                case "aiassistant":
                    btnAIAssistant_Click(null, null);
                    break;
                case "settings":
                    btnSettings_Click(null, null);
                    break;
                default:
                    // Mặc định load overview
                    btnOverview_Click(null, null);
                    break;
            }
        }

        #endregion

        #region IDisposable Implementation

        // Dispose: Giải phóng tài nguyên khi form bị đóng
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                // Giải phóng service manager
                _serviceManager?.Dispose();
                // Giải phóng module hiện tại
                currentModule?.Dispose();
            }
            base.Dispose(disposing);
        }
        

        #endregion
    }
}
