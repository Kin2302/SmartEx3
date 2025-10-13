using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using SmartEx3.Models;
using SmartEx3.Services;

namespace SmartEx3.Forms
{
    /// <summary>
    /// Form for adding or editing transactions
    /// </summary>
    public partial class FormTransactionEdit : Form
    {
        #region Private Fields

        private readonly ServiceManager _serviceManager;
        private readonly Transaction _transaction;
        private readonly bool _isEditMode;
        private readonly int _currentUserId;

        #endregion

        #region Constructor

        /// <summary>
        /// Initialize FormTransactionEdit
        /// </summary>
        /// <param name="userId">Current user ID</param>
        /// <param name="serviceManager">Service manager instance</param>
        /// <param name="transaction">Transaction to edit (null for new transaction)</param>
        public FormTransactionEdit(int userId, ServiceManager serviceManager, Transaction transaction = null)
        {
            _serviceManager = serviceManager ?? throw new ArgumentNullException(nameof(serviceManager));
            _currentUserId = userId;
            _transaction = transaction;
            _isEditMode = transaction != null;

            InitializeComponent();
            InitializeFormSettings();
            LoadCategories();
            
            if (_isEditMode)
            {
                LoadTransactionData();
            }
            else
            {
                SetDefaultValues();
            }

            UpdateCategoryVisibility();
        }

        #endregion

        #region Initialization

        /// <summary>
        /// Initialize form settings based on mode
        /// </summary>
        private void InitializeFormSettings()
        {
            // Update title and button text based on mode
            if (_isEditMode)
            {
                this.Text = "Chỉnh sửa giao dịch";
                lblTitle.Text = "CHỈNH SỬA GIAO DỊCH";
                btnSave.Text = "Cập nhật";
            }
            else
            {
                this.Text = "Thêm giao dịch mới";
                lblTitle.Text = "THÊM GIAO DỊCH MỚI";
                btnSave.Text = "Thêm mới";
            }
        }

        /// <summary>
        /// Load categories from database
        /// </summary>
        private void LoadCategories()
        {
            try
            {
                var categories = _serviceManager.CategoryService.GetAllCategories();
                cmbCategory.Items.Clear();
                
                foreach (var category in categories)
                {
                    cmbCategory.Items.Add(category.Name);
                }

                // Add default categories if none exist
                if (cmbCategory.Items.Count == 0)
                {
                    CreateDefaultCategories();
                }
            }
            catch (Exception ex)
            {
                ShowErrorMessage($"Lỗi khi tải danh mục: {ex.Message}");
            }
        }

        /// <summary>
        /// Create default categories
        /// </summary>
        private void CreateDefaultCategories()
        {
            string[] defaultCategories = { 
                "Ăn uống", "Di chuyển", "Mua sắm", "Y tế", 
                "Giải trí", "Nhà cửa", "Học tập", "Viễn thông" 
            };
            
            foreach (var cat in defaultCategories)
            {
                try
                {
                    _serviceManager.CategoryService.CreateCategory(new Category { Name = cat });
                    cmbCategory.Items.Add(cat);
                }
                catch 
                { 
                    // Category might already exist, ignore
                }
            }
        }

        /// <summary>
        /// Load transaction data for editing
        /// </summary>
        private void LoadTransactionData()
        {
            if (_transaction != null)
            {
                txtAmount.Text = Math.Abs(_transaction.Amount).ToString("N0");
                txtAmount.ForeColor = Color.Black;
                
                chkIsExpense.Checked = _transaction.Amount < 0;
                
                // Only set category if it's an expense and has a category
                if (_transaction.Amount < 0 && !string.IsNullOrEmpty(_transaction.Category))
                {
                    cmbCategory.Text = _transaction.Category;
                }
                
                if (!string.IsNullOrEmpty(_transaction.Note))
                {
                    txtNote.Text = _transaction.Note;
                    txtNote.ForeColor = Color.Black;
                }
                
                dtpDate.Value = _transaction.Date;
            }
        }

        /// <summary>
        /// Set default values for new transaction
        /// </summary>
        private void SetDefaultValues()
        {
            dtpDate.Value = DateTime.Now;
            chkIsExpense.Checked = true;
        }

        #endregion

        #region UI Updates

        /// <summary>
        /// Update category visibility based on expense/income
        /// </summary>
        private void UpdateCategoryVisibility()
        {
            bool showCategory = chkIsExpense.Checked;

            lblCategory.Visible = showCategory;
            cmbCategory.Visible = showCategory;
            btnAddCategory.Visible = showCategory;

            if (showCategory)
            {
                lblCategory.Text = "Danh mục *";
            }
            else
            {
                cmbCategory.Text = "";
            }

            // Adjust control positions
            int categoryHeight = showCategory ? 45 : 0;
            int baseY = 130 + categoryHeight;

            lblDate.Location = new Point(20, baseY + 30);
            dtpDate.Location = new Point(20, baseY + 55);
            lblNote.Location = new Point(20, baseY + 90);
            txtNote.Location = new Point(20, baseY + 115);
            btnSave.Location = new Point(170, baseY + 190);
            btnCancel.Location = new Point(280, baseY + 190);

            // Adjust form height
            int formHeight = baseY + 260;
            this.Size = new Size(450, formHeight);
        }

        #endregion

        #region Event Handlers - Placeholder Management

        private void TxtAmount_Enter(object sender, EventArgs e)
        {
            if (txtAmount.Text == "Nhập số tiền (VD: 50000)")
            {
                txtAmount.Text = "";
                txtAmount.ForeColor = Color.Black;
            }
        }

        private void TxtAmount_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAmount.Text))
            {
                txtAmount.Text = "Nhập số tiền (VD: 50000)";
                txtAmount.ForeColor = Color.Gray;
            }
        }

        private void TxtNote_Enter(object sender, EventArgs e)
        {
            if (txtNote.Text == "Nhập ghi chú (tùy chọn)")
            {
                txtNote.Text = "";
                txtNote.ForeColor = Color.Black;
            }
        }

        private void TxtNote_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNote.Text))
            {
                txtNote.Text = "Nhập ghi chú (tùy chọn)";
                txtNote.ForeColor = Color.Gray;
            }
        }

        #endregion

        #region Event Handlers - User Actions

        private void ChkIsExpense_CheckedChanged(object sender, EventArgs e)
        {
            UpdateCategoryVisibility();
        }

        private void TxtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Only allow digits, backspace, and decimal separator
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // Only allow one decimal point
            if (e.KeyChar == '.' && ((TextBox)sender).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void BtnAddCategory_Click(object sender, EventArgs e)
        {
            using (var categoryForm = new FormCategoryEdit(_serviceManager))
            {
                if (categoryForm.ShowDialog() == DialogResult.OK)
                {
                    LoadCategories();
                    if (!string.IsNullOrEmpty(categoryForm.CategoryName))
                    {
                        cmbCategory.Text = categoryForm.CategoryName;
                    }
                }
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                SaveTransaction();
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        #endregion

        #region Validation

        /// <summary>
        /// Validate user input
        /// </summary>
        private bool ValidateInput()
        {
            string amountText = txtAmount.Text == "Nhập số tiền (VD: 50000)" ? "" : txtAmount.Text;
            
            if (string.IsNullOrWhiteSpace(amountText))
            {
                ShowWarningMessage("Vui lòng nhập số tiền!");
                txtAmount.Focus();
                return false;
            }

            if (!decimal.TryParse(amountText.Replace(",", ""), out decimal amount) || amount <= 0)
            {
                ShowWarningMessage("Số tiền không hợp lệ!");
                txtAmount.Focus();
                return false;
            }

            // Only validate category for expenses
            if (chkIsExpense.Checked && string.IsNullOrWhiteSpace(cmbCategory.Text))
            {
                ShowWarningMessage("Vui lòng chọn danh mục cho khoản chi!");
                cmbCategory.Focus();
                return false;
            }

            return true;
        }

        #endregion

        #region Data Operations

        /// <summary>
        /// Save transaction (create or update)
        /// </summary>
        private void SaveTransaction()
        {
            try
            {
                string amountText = txtAmount.Text == "Nhập số tiền (VD: 50000)" ? "" : txtAmount.Text.Replace(",", "");
                decimal amount = decimal.Parse(amountText);
                
                if (chkIsExpense.Checked)
                    amount = -amount;

                string noteText = (txtNote.Text == "Nhập ghi chú (tùy chọn)" || string.IsNullOrWhiteSpace(txtNote.Text)) 
                    ? null 
                    : txtNote.Text.Trim();
                
                string categoryText = chkIsExpense.Checked ? cmbCategory.Text.Trim() : null;

                if (_isEditMode)
                {
                    UpdateExistingTransaction(amount, categoryText, noteText);
                }
                else
                {
                    CreateNewTransaction(amount, categoryText, noteText);
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
            {
                ShowValidationErrors(dbEx);
            }
            catch (Exception ex)
            {
                ShowDetailedError(ex);
            }
        }

        /// <summary>
        /// Update existing transaction
        /// </summary>
        private void UpdateExistingTransaction(decimal amount, string category, string note)
        {
            _transaction.Amount = amount;
            _transaction.Category = category;
            _transaction.Note = note;
            _transaction.Date = dtpDate.Value;

            _serviceManager.TransactionService.UpdateTransaction(_transaction);
            ShowSuccessMessage("Cập nhật giao dịch thành công!");
        }

        /// <summary>
        /// Create new transaction
        /// </summary>
        private void CreateNewTransaction(decimal amount, string category, string note)
        {
            var newTransaction = new Transaction
            {
                UserId = _currentUserId,
                Amount = amount,
                Category = category,
                Note = note,
                Date = dtpDate.Value.Date
            };

            _serviceManager.TransactionService.CreateTransaction(newTransaction);
            ShowSuccessMessage("Thêm giao dịch thành công!");
        }

        #endregion

        #region Helper Methods

        private void ShowErrorMessage(string message)
        {
            MessageBox.Show(message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ShowWarningMessage(string message)
        {
            MessageBox.Show(message, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void ShowSuccessMessage(string message)
        {
            MessageBox.Show(message, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ShowValidationErrors(System.Data.Entity.Validation.DbEntityValidationException dbEx)
        {
            string errorMessage = "Lỗi validation:\n";
            foreach (var validationErrors in dbEx.EntityValidationErrors)
            {
                foreach (var validationError in validationErrors.ValidationErrors)
                {
                    errorMessage += $"- {validationError.PropertyName}: {validationError.ErrorMessage}\n";
                }
            }
            ShowErrorMessage(errorMessage);
        }

        private void ShowDetailedError(Exception ex)
        {
            string errorMessage = $"Lỗi khi lưu giao dịch: {ex.Message}";
            if (ex.InnerException != null)
            {
                errorMessage += $"\n\nChi tiết: {ex.InnerException.Message}";
                if (ex.InnerException.InnerException != null)
                {
                    errorMessage += $"\n\n{ex.InnerException.InnerException.Message}";
                }
            }
            ShowErrorMessage(errorMessage);
        }

        #endregion
    }
}