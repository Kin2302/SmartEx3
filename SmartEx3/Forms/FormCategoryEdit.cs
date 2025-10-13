using System;
using System.Drawing;
using System.Windows.Forms;
using SmartEx3.Models;
using SmartEx3.Services;

namespace SmartEx3.Forms
{
    public partial class FormCategoryEdit : Form
    {
        private readonly ServiceManager _serviceManager;
        private readonly Category _category;
        private readonly bool _isEditMode;

        // Form controls
        private Panel panelMain;
        private Label lblTitle;
        private Label lblName;
        private TextBox txtName;
        private Button btnSave;
        private Button btnCancel;

        public string CategoryName { get; private set; }

        public FormCategoryEdit(ServiceManager serviceManager, Category category = null)
        {
            _serviceManager = serviceManager ?? throw new ArgumentNullException(nameof(serviceManager));
            _category = category;
            _isEditMode = category != null;

            InitializeComponent();
            InitializeCustomControls();
            
            // Set form title after InitializeComponent
            this.Text = _isEditMode ? "Chỉnh sửa danh mục" : "Thêm danh mục mới";
            
            if (_isEditMode)
            {
                LoadCategoryData();
            }
            else
            {
                SetPlaceholderText();
            }
        }

        private void InitializeCustomControls()
        {
            // Main panel
            panelMain = new Panel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(20),
                BackColor = Color.White,
                Location = new Point(10, 10),
                Size = new Size(this.Width - 20, this.Height - 20)
            };
            this.Controls.Add(panelMain);

            // Title
            lblTitle = new Label
            {
                Text = _isEditMode ? "CHỈNH SỬA DANH MỤC" : "THÊM DANH MỤC MỚI",
                Font = new Font("Century Gothic", 12F, FontStyle.Bold),
                ForeColor = Color.FromArgb(52, 152, 219),
                AutoSize = true,
                Location = new Point(20, 20)
            };
            panelMain.Controls.Add(lblTitle);

            // Name
            lblName = new Label
            {
                Text = "Tên danh mục *",
                Font = new Font("Century Gothic", 10F, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(20, 60)
            };
            panelMain.Controls.Add(lblName);

            txtName = new TextBox
            {
                Font = new Font("Century Gothic", 10F),
                Size = new Size(320, 23),
                Location = new Point(20, 85)
            };
            txtName.Enter += (s, e) => { if (txtName.Text == "Nhập tên danh mục (VD: Ăn uống, Di chuyển...)") { txtName.Text = ""; txtName.ForeColor = Color.Black; } };
            txtName.Leave += (s, e) => { if (string.IsNullOrEmpty(txtName.Text)) { txtName.Text = "Nhập tên danh mục (VD: Ăn uống, Di chuyển...)"; txtName.ForeColor = Color.Gray; } };
            panelMain.Controls.Add(txtName);

            // Buttons
            btnSave = new Button
            {
                Text = _isEditMode ? "Cập nhật" : "Thêm mới",
                Font = new Font("Century Gothic", 10F, FontStyle.Bold),
                Size = new Size(100, 30),
                Location = new Point(140, 125),
                BackColor = Color.FromArgb(46, 204, 113),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.Click += BtnSave_Click;
            panelMain.Controls.Add(btnSave);

            btnCancel = new Button
            {
                Text = "Hủy",
                Font = new Font("Century Gothic", 10F, FontStyle.Bold),
                Size = new Size(100, 30),
                Location = new Point(250, 125),
                BackColor = Color.FromArgb(231, 76, 60),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.Click += BtnCancel_Click;
            panelMain.Controls.Add(btnCancel);
        }

        private void SetPlaceholderText()
        {
            txtName.Text = "Nhập tên danh mục (VD: Ăn uống, Di chuyển...)";
            txtName.ForeColor = Color.Gray;
        }

        private void LoadCategoryData()
        {
            if (_category != null)
            {
                txtName.Text = _category.Name;
                txtName.ForeColor = Color.Black;
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                try
                {
                    string categoryName = txtName.Text == "Nhập tên danh mục (VD: Ăn uống, Di chuyển...)" ? "" : txtName.Text.Trim();

                    if (_isEditMode)
                    {
                        // Update existing category
                        _category.Name = categoryName;
                        _serviceManager.CategoryService.UpdateCategory(_category);
                        MessageBox.Show("Cập nhật danh mục thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        // Create new category
                        var newCategory = new Category
                        {
                            Name = categoryName
                        };

                        _serviceManager.CategoryService.CreateCategory(newCategory);
                        MessageBox.Show("Thêm danh mục thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    CategoryName = categoryName;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (InvalidOperationException ex) when (ex.Message.Contains("already exists"))
                {
                    MessageBox.Show("Tên danh mục đã tồn tại! Vui lòng chọn tên khác.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtName.Focus();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi lưu danh mục: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private bool ValidateInput()
        {
            string categoryName = txtName.Text == "Nhập tên danh mục (VD: Ăn uống, Di chuyển...)" ? "" : txtName.Text.Trim();
            
            if (string.IsNullOrWhiteSpace(categoryName))
            {
                MessageBox.Show("Vui lòng nhập tên danh mục!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return false;
            }

            if (categoryName.Length < 2)
            {
                MessageBox.Show("Tên danh mục phải có ít nhất 2 ký tự!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return false;
            }

            return true;
        }
    }
}