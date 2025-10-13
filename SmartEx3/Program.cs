using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using SmartEx3.Forms;
using SmartEx3.Services;

namespace SmartEx3
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            // Bật Visual Styles cho Windows Forms
            Application.EnableVisualStyles();
            
            // Đặt chế độ render text mặc định
            Application.SetCompatibleTextRenderingDefault(false);
            
            // Tạo ServiceManager để quản lý các service trong ứng dụng
            using (var serviceManager = new ServiceManager())
            {
                // Hiển thị form đăng nhập với animation
                var loginForm = new FormLoginAnimation(serviceManager);
                
                // Kiểm tra kết quả đăng nhập
                if (loginForm.ShowDialog() == DialogResult.OK)
                {
                    // Nếu đăng nhập thành công, mở FormDashboard với thông tin user đã xác thực
                    var dashboard = new FormDashboard(loginForm.AuthenticatedUser);
                    Application.Run(dashboard);
                }
                else
                {
                    // Nếu user hủy đăng nhập, thoát ứng dụng
                    Application.Exit();
                }
            }
        }
    }
}
