using Bunifu.Framework.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SmartEx3.Models;
using SmartEx3.Services;

namespace SmartEx3.Forms
{
    public partial class FormLoginAnimation : Form
    {
        #region Private Fields
        
        // Danh sách các hình ảnh animation
        private List<Image> images = new List<Image>();
        
        // Mảng lưu đường dẫn đến các file animation
        private string[] location = new string[25];
        
        // Quản lý các service của ứng dụng
        private ServiceManager _serviceManager;
        
        // Người dùng đã xác thực thành công
        private User _authenticatedUser;
        
        // Chế độ hiện tại: true = Đăng nhập, false = Đăng ký
        private bool _isLoginMode = true;
        
        #endregion

        #region Properties
        
        public User AuthenticatedUser => _authenticatedUser;
        
        #endregion

        #region Constructor
        
        public FormLoginAnimation(ServiceManager serviceManager)
        {
            InitializeComponent();
            _serviceManager = serviceManager ?? throw new ArgumentNullException(nameof(serviceManager));
            
            // Tải các hình ảnh animation
            LoadAnimationImages();
            
            // Thiết lập giao diện ban đầu
            SetupInitialUI();
            
            // Đặt bán kính bo góc của form = 0 (form vuông)
            this.bunifuElipse1.ElipseRadius = 0;
        }
        
        #endregion

        #region Initialization Methods
        
        private void LoadAnimationImages()
        {
            try
            {
                // Đường dẫn đúng đến thư mục animation
                string basePath = System.IO.Path.Combine(Application.StartupPath, "..", "..", "Resources", "animation");
                
                // Lặp qua 23 file animation
                for (int i = 0; i < 23; i++)
                {
                    string fileName = $"textbox_user_{i + 1}.jpg";
                    location[i] = System.IO.Path.Combine(basePath, fileName);
                }
                
                // Tải hình ảnh vào bộ nhớ
                for (int i = 0; i < 23; i++)
                {
                    if (System.IO.File.Exists(location[i]))
                    {
                        Bitmap bitmap = new Bitmap(location[i]);
                        images.Add(bitmap);
                    }
                    else
                    {
                        Console.WriteLine($"Warning: Animation file not found: {location[i]}");
                    }
                }
                
                if (images.Count > 0)
                {
                    Console.WriteLine($"Successfully loaded {images.Count} animation images");
                }
            }
            catch (Exception ex)
            {
                // Animation là tùy chọn, chỉ ghi log lỗi
                Console.WriteLine($"Could not load animation images: {ex.Message}");
            }
        }

        private void SetupInitialUI()
        {
            // Thiết lập chế độ đăng nhập ban đầu
            label1.Text = "Email :";
            label2.Text = "Mật khẩu :";
            textBox1.Text = "";
            textBox2.Text = "";
            textBox1.Focus();
            
            bunifuThinButton21.ButtonText = "Đăng nhập";
            linkLabel1.Text = "Chưa có tài khoản? Đăng ký ngay";
        }
        
        #endregion

        #region Form Events
        
        private void Form1_Load(object sender, EventArgs e)
        {
            // Thiết lập vùng hình tròn cho avatar
            pictureBox1.Region = new Region(new Rectangle(0, 0, pictureBox1.Width, pictureBox1.Height));
            pictureBox1.Image = Properties.Resources.debut;
            
            // Căn giữa avatar
            pictureBox1.Location = new Point(
                (this.ClientSize.Width - pictureBox1.Width) / 2,
                pictureBox1.Location.Y
            );
            
            textBox1.ForeColor = Color.Black;
            
            // Đặt placeholder text style
            SetPlaceholderText(textBox1, "Nhập email của bạn");
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            // Tùy chọn: Thêm custom painting cho panel bên trái
        }
        
        #endregion

        #region TextBox Events - Animation
        
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (images.Count == 0) return;
            
            try
            {
                // Nếu độ dài text từ 1-15 ký tự
                if (textBox1.Text.Length > 0 && textBox1.Text.Length <= 15)
                {
                    int index = Math.Min(textBox1.Text.Length - 1, images.Count - 1);
                    pictureBox1.Image = images[index];
                    pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
                }
                // Nếu text rỗng
                else if (textBox1.Text.Length <= 0)
                {
                    pictureBox1.Image = Properties.Resources.debut;
                }
                // Nếu text dài hơn 15 ký tự
                else if (textBox1.Text.Length > 15)
                {
                    pictureBox1.Image = images[Math.Min(22, images.Count - 1)];
                }
            }
            catch
            {
                // Fallback về hình mặc định nếu animation thất bại
                pictureBox1.Image = Properties.Resources.debut;
            }
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            if (images.Count > 0 && textBox1.Text.Length > 0)
            {
                int index = Math.Min(textBox1.Text.Length - 1, images.Count - 1);
                pictureBox1.Image = images[index];
            }
            else
            {
                pictureBox1.Image = Properties.Resources.debut;
            }
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            ShowPasswordCoverImage();
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            ShowPasswordCoverImage();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            // Giữ hình ảnh che mật khẩu trong khi typing
        }

        private void ShowPasswordCoverImage()
        {
            try
            {
                string passwordImagePath = System.IO.Path.Combine(
                    Application.StartupPath, "..", "..", "Resources", "animation", "textbox_password.png");
                
                if (System.IO.File.Exists(passwordImagePath))
                {
                    Bitmap bmpass = new Bitmap(passwordImagePath);
                    pictureBox1.Image = bmpass;
                }
                else
                {
                    Console.WriteLine($"Warning: Password cover image not found: {passwordImagePath}");
                }
            }
            catch (Exception ex)
            {
                // Nếu không tìm thấy hình mật khẩu, giữ nguyên hình hiện tại
                Console.WriteLine($"Could not load password cover image: {ex.Message}");
            }
        }
        
        #endregion

        #region Button Events
        
        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            if (_isLoginMode)
            {
                PerformLogin();
            }
            else
            {
                PerformRegister();
            }
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            // Nút đóng - hủy đăng nhập
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ToggleLoginRegisterMode();
        }
        
        #endregion

        #region Login/Register Logic
        
        private void PerformLogin()
        {
            // Kiểm tra dữ liệu đầu vào
            if (!ValidateLoginInput())
                return;

            string email = textBox1.Text.Trim();
            string password = textBox2.Text;

            try
            {
                // Xác thực thông tin đăng nhập
                if (_serviceManager.UserService.ValidateUser(email, password))
                {
                    // Lấy thông tin người dùng
                    _authenticatedUser = _serviceManager.UserService.GetUserByEmail(email);
                    
                    if (_authenticatedUser != null)
                    {
                        MessageBox.Show(
                            $"Đăng nhập thành công!\n\nChào mừng {_authenticatedUser.Name}!",
                            "Thành công",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );
                        
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        ShowError("Không thể tải thông tin người dùng!");
                    }
                }
                else
                {
                    ShowError("Email hoặc mật khẩu không đúng!");
                    textBox2.Clear();
                    textBox2.Focus();
                }
            }
            catch (Exception ex)
            {
                ShowError($"Lỗi khi đăng nhập: {ex.Message}");
            }
        }

        private void PerformRegister()
        {
            // Kiểm tra dữ liệu đầu vào
            if (!ValidateRegisterInput())
                return;

            string email = textBox1.Text.Trim();
            string password = textBox2.Text;

            // Hiển thị dialog nhập tên
            string userName = ShowNameInputDialog();
            
            if (string.IsNullOrWhiteSpace(userName))
            {
                ShowError("Vui lòng nhập tên!");
                return;
            }

            try
            {
                // Kiểm tra email đã tồn tại chưa
                if (_serviceManager.UserService.EmailExists(email))
                {
                    ShowError("Email này đã được đăng ký!");
                    return;
                }

                // Tạo người dùng mới
                var newUser = new User
                {
                    Name = userName,
                    Email = email,
                    PasswordHash = password, // Sẽ được hash bởi UserService
                    CreatedAt = DateTime.Now
                };

                var createdUser = _serviceManager.UserService.CreateUser(newUser);

                if (createdUser != null)
                {
                    MessageBox.Show(
                        $"Đăng ký thành công!\n\nChào mừng {createdUser.Name}!\n\nBạn có thể đăng nhập ngay bây giờ.",
                        "Thành công",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    // Chuyển sang chế độ đăng nhập
                    ToggleLoginRegisterMode();
                    
                    // Điền sẵn email
                    textBox1.Text = email;
                    textBox2.Clear();
                    textBox2.Focus();
                }
                else
                {
                    ShowError("Không thể tạo tài khoản!");
                }
            }
            catch (Exception ex)
            {
                ShowError($"Lỗi khi đăng ký: {ex.Message}");
            }
        }

        private void ToggleLoginRegisterMode()
        {
            _isLoginMode = !_isLoginMode;

            if (_isLoginMode)
            {
                // Chuyển sang chế độ Đăng nhập
                label1.Text = "Email :";
                label2.Text = "Mật khẩu :";
                bunifuThinButton21.ButtonText = "Đăng nhập";
                linkLabel1.Text = "Chưa có tài khoản? Đăng ký ngay";
                this.Text = "Đăng nhập - SmartEx3";
            }
            else
            {
                // Chuyển sang chế độ Đăng ký
                label1.Text = "Email :";
                label2.Text = "Mật khẩu :";
                bunifuThinButton21.ButtonText = "Đăng ký";
                linkLabel1.Text = "Đã có tài khoản? Đăng nhập";
                this.Text = "Đăng ký - SmartEx3";
            }

            // Xóa dữ liệu đầu vào
            textBox1.Clear();
            textBox2.Clear();
            textBox1.Focus();
            
            // Reset avatar về hình mặc định
            pictureBox1.Image = Properties.Resources.debut;
        }
        
        #endregion

        #region Validation Methods
        
        private bool ValidateLoginInput()
        {
            // Kiểm tra email không được rỗng
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                ShowError("Vui lòng nhập email!");
                textBox1.Focus();
                return false;
            }

            // Kiểm tra định dạng email
            if (!IsValidEmail(textBox1.Text.Trim()))
            {
                ShowError("Email không hợp lệ!");
                textBox1.Focus();
                return false;
            }

            // Kiểm tra mật khẩu không được rỗng
            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                ShowError("Vui lòng nhập mật khẩu!");
                textBox2.Focus();
                return false;
            }

            return true;
        }

        private bool ValidateRegisterInput()
        {
            // Kiểm tra email không được rỗng
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                ShowError("Vui lòng nhập email!");
                textBox1.Focus();
                return false;
            }

            // Kiểm tra định dạng email
            if (!IsValidEmail(textBox1.Text.Trim()))
            {
                ShowError("Email không hợp lệ!");
                textBox1.Focus();
                return false;
            }

            // Kiểm tra mật khẩu không được rỗng
            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                ShowError("Vui lòng nhập mật khẩu!");
                textBox2.Focus();
                return false;
            }

            // Kiểm tra độ dài mật khẩu tối thiểu
            if (textBox2.Text.Length < 6)
            {
                ShowError("Mật khẩu phải có ít nhất 6 ký tự!");
                textBox2.Focus();
                return false;
            }

            return true;
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
        
        #endregion

        #region Helper Methods
        
        private void ShowError(string message)
        {
            MessageBox.Show(
                message,
                "Lỗi",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            );
        }

        private string ShowNameInputDialog()
        {
            // Tạo form input đơn giản
            Form prompt = new Form()
            {
                Width = 400,
                Height = 180,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = "Đăng ký tài khoản",
                StartPosition = FormStartPosition.CenterParent,
                MaximizeBox = false,
                MinimizeBox = false
            };

            // Label hướng dẫn
            Label textLabel = new Label() 
            { 
                Left = 30, 
                Top = 20, 
                Text = "Nhập tên của bạn:",
                AutoSize = true,
                Font = new Font("Century Gothic", 10F)
            };

            // TextBox nhập tên
            TextBox textBox = new TextBox() 
            { 
                Left = 30, 
                Top = 50, 
                Width = 320,
                Font = new Font("Century Gothic", 10F)
            };

            // Nút OK
            Button confirmation = new Button() 
            { 
                Text = "OK", 
                Left = 190, 
                Width = 80, 
                Top = 90, 
                DialogResult = DialogResult.OK,
                Font = new Font("Century Gothic", 9F),
                BackColor = Color.SteelBlue,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            confirmation.FlatAppearance.BorderSize = 0;

            // Nút Hủy
            Button cancel = new Button() 
            { 
                Text = "Hủy", 
                Left = 280, 
                Width = 70, 
                Top = 90, 
                DialogResult = DialogResult.Cancel,
                Font = new Font("Century Gothic", 9F),
                BackColor = Color.Gray,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            cancel.FlatAppearance.BorderSize = 0;

            // Gắn sự kiện click
            confirmation.Click += (sender, e) => { prompt.Close(); };
            cancel.Click += (sender, e) => { prompt.Close(); };

            // Thêm controls vào form
            prompt.Controls.Add(textLabel);
            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(cancel);
            prompt.AcceptButton = confirmation;

            // Trả về giá trị nhập hoặc chuỗi rỗng
            return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : "";
        }

        private void SetPlaceholderText(TextBox textBox, string placeholder)
        {
            // Đây là implementation đơn giản
            if (string.IsNullOrEmpty(textBox.Text))
            {
                textBox.ForeColor = Color.Gray;
                textBox.Text = placeholder;
            }

            // Xóa placeholder khi focus
            textBox.Enter += (s, e) =>
            {
                if (textBox.Text == placeholder)
                {
                    textBox.Text = "";
                    textBox.ForeColor = Color.Black;
                }
            };

            // Hiển thị lại placeholder khi rời khỏi và không có text
            textBox.Leave += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    textBox.ForeColor = Color.Gray;
                    textBox.Text = placeholder;
                }
            };
        }

        #endregion

        #region Cleanup

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                // Giải phóng các hình ảnh animation
                foreach (var image in images)
                {
                    image?.Dispose();
                }
                images.Clear();
            }
            base.Dispose(disposing);
        }

        #endregion
    }
}
