using System;
using System.Drawing;
using System.Windows.Forms;

namespace ThucHanhLaiProjectt.Forms
{
    public partial class FormLoginAnimation : Form
    {
        #region Fields
        
        private bool _isLoginMode = true; // true = Login, false = Register
        
        #endregion

        #region Constructor
        
        public FormLoginAnimation()
        {
            InitializeComponent();
            
            // Enable form dragging
            this.MouseDown += FormLoginAnimation_MouseDown;
            panelMain.MouseDown += FormLoginAnimation_MouseDown;
        }
        
        #endregion

        #region Form Events
        
        private void FormLoginAnimation_Load(object sender, EventArgs e)
        {
            // TODO: Setup initial UI
            // - Load default avatar image
            // - Setup placeholder text for textboxes
            // - Initialize animation images (optional)
            
            // Make avatar circular (optional)
            MakeCircularPictureBox(pictureBoxAvatar);
            
            // Set focus to email textbox
            txtEmail.Focus();
        }
        
        #endregion

        #region Button Events
        
        private void BtnLogin_Click(object sender, EventArgs e)
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

        private void BtnClose_Click(object sender, EventArgs e)
        {
            // TODO: Close the application or return to previous form
            Application.Exit();
        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // TODO: Toggle between Login and Register mode
            ToggleLoginRegisterMode();
        }
        
        #endregion

        #region TextBox Events
        
        private void TxtEmail_TextChanged(object sender, EventArgs e)
        {
            // TODO: Implement animation based on text length
            // - Change avatar image as user types
            // - Example: Load animation frames based on txtEmail.Text.Length
        }

        private void TxtPassword_Enter(object sender, EventArgs e)
        {
            // TODO: Show password cover image when entering password field
            // - Change avatar to "covering eyes" image
        }
        
        #endregion

        #region Button Hover Effects
        
        private void BtnLogin_MouseEnter(object sender, EventArgs e)
        {
            btnLogin.BackColor = Color.FromArgb(41, 128, 185); // Darker blue
        }

        private void BtnLogin_MouseLeave(object sender, EventArgs e)
        {
            btnLogin.BackColor = Color.SteelBlue; // Original blue
        }

        private void BtnClose_MouseEnter(object sender, EventArgs e)
        {
            btnClose.BackColor = Color.Crimson;
            btnClose.ForeColor = Color.White;
        }

        private void BtnClose_MouseLeave(object sender, EventArgs e)
        {
            btnClose.BackColor = Color.White;
            btnClose.ForeColor = Color.Gray;
        }
        
        #endregion

        #region Login/Register Logic (TODO: Implement)
        
        private void PerformLogin()
        {
            // TODO: Implement login logic
            // 1. Validate input
            // 2. Check credentials against database/service
            // 3. If successful, open main dashboard
            // 4. If failed, show error message
            
            MessageBox.Show(
                "TODO: Implement PerformLogin()\n\n" +
                "C?n làm:\n" +
                "1. Validate email và password\n" +
                "2. K?t n?i service ?? xác th?c\n" +
                "3. M? FormDashboard n?u thành công\n" +
                "4. Hi?n th? l?i n?u th?t b?i",
                "Ch?c n?ng ch?a hoàn thi?n",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        private void PerformRegister()
        {
            // TODO: Implement register logic
            // 1. Validate input
            // 2. Check if email already exists
            // 3. Get user name via input dialog
            // 4. Create new user account
            // 5. Switch to login mode
            
            MessageBox.Show(
                "TODO: Implement PerformRegister()\n\n" +
                "C?n làm:\n" +
                "1. Validate email và password\n" +
                "2. Ki?m tra email ?ã t?n t?i ch?a\n" +
                "3. Hi?n th? dialog nh?p tên\n" +
                "4. T?o tài kho?n m?i\n" +
                "5. Chuy?n v? ch? ?? ??ng nh?p",
                "Ch?c n?ng ch?a hoàn thi?n",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        private void ToggleLoginRegisterMode()
        {
            // TODO: Implement mode toggle
            _isLoginMode = !_isLoginMode;

            if (_isLoginMode)
            {
                // Switch to Login mode
                btnLogin.Text = "??ng nh?p";
                linkLabel1.Text = "Ch?a có tài kho?n? ??ng ký ngay";
                this.Text = "??ng nh?p - SmartEx3";
            }
            else
            {
                // Switch to Register mode
                btnLogin.Text = "??ng ký";
                linkLabel1.Text = "?ã có tài kho?n? ??ng nh?p";
                this.Text = "??ng ký - SmartEx3";
            }

            // Clear inputs
            txtEmail.Clear();
            txtPassword.Clear();
            txtEmail.Focus();
        }
        
        #endregion

        #region Helper Methods
        
        private void MakeCircularPictureBox(PictureBox pictureBox)
        {
            // Make the picture box circular
            System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();
            gp.AddEllipse(0, 0, pictureBox.Width - 1, pictureBox.Height - 1);
            pictureBox.Region = new Region(gp);
        }

        // Enable form dragging
        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool ReleaseCapture();

        private void FormLoginAnimation_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        
        #endregion
    }
}
