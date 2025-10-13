using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using SmartEx3.Models;
using SmartEx3.Services;
using SmartEx3.Forms;

namespace SmartEx3.UserControls
{
    public partial class UC_Transaction : UserControl
    {
        #region Private Fields

        private ServiceManager _serviceManager;
        private int _currentUserId;

        #endregion

        #region Constructor and Initialization

        public UC_Transaction()
        {
            InitializeComponent();
            InitializeServices();
            LoadInitialData();
        }

        /// <summary>
        /// Initialize service manager
        /// </summary>
        private void InitializeServices()
        {
            _serviceManager = new ServiceManager();
            _currentUserId = 1; // Default user ID - in real app, get from logged in user
        }

        /// <summary>
        /// Load initial data
        /// </summary>
        private void LoadInitialData()
        {
            LoadTransactionsFromDatabase();
            UpdateButtonStates();
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Set the current user ID
        /// </summary>
        public int CurrentUserId
        {
            get => _currentUserId;
            set
            {
                _currentUserId = value;
                LoadTransactionsFromDatabase();
            }
        }

        #endregion

        #region Public Methods - CRUD Operations

        /// <summary>
        /// Refresh the transaction list from database
        /// </summary>
        public void RefreshTransactions()
        {
            LoadTransactionsFromDatabase();
            UpdateButtonStates();
        }



        #endregion

        #region Private Methods - Data Operations

        /// <summary>
        /// Load transactions from database
        /// </summary>
        private void LoadTransactionsFromDatabase()
        {
            try
            {
                var transactions = _serviceManager.TransactionService.GetTransactionsByUserId(_currentUserId);
                PopulateDataGridView(transactions);
            }
            catch (Exception ex)
            {
                ShowErrorMessage($"Lỗi khi tải dữ liệu giao dịch: {ex.Message}");
            }
        }

        /// <summary>
        /// Populate DataGridView with transaction data
        /// </summary>
        private void PopulateDataGridView(IEnumerable<Transaction> transactions)
        {
            dgvTransactions.Rows.Clear();
            
            foreach (var transaction in transactions)
            {
                // For income transactions (positive amount), show "Thu nhập" instead of category
                string displayCategory = transaction.Amount > 0 ? "Thu nhập" : transaction.Category;
                
                dgvTransactions.Rows.Add(
                    transaction.Date.ToString("dd/MM/yyyy"),
                    displayCategory,
                    FormatAmount(transaction.Amount),
                    transaction.Note
                );
                
                // Store the transaction ID in the row tag
                dgvTransactions.Rows[dgvTransactions.Rows.Count - 1].Tag = transaction.TransId;
                
                // Color coding for income/expense
                var lastRow = dgvTransactions.Rows[dgvTransactions.Rows.Count - 1];
                if (transaction.Amount > 0)
                {
                    lastRow.DefaultCellStyle.ForeColor = Color.FromArgb(39, 174, 96);
                }
                else
                {
                    lastRow.DefaultCellStyle.ForeColor = Color.FromArgb(231, 76, 60);
                }
            }
        }       

        /// <summary>
        /// Format amount for display
        /// </summary>
        private string FormatAmount(decimal amount)
        {
            string sign = amount >= 0 ? "+" : "";
            return $"{sign}{amount:N0} ₫";
        }

        /// <summary>
        /// Get the selected transaction from database
        /// </summary>
        private Transaction GetSelectedTransactionFromDb()
        {
            var selectedRow = GetSelectedTransaction();
            if (selectedRow?.Tag is int transactionId)
            {
                return _serviceManager.TransactionService.GetTransactionById(transactionId);
            }
            return null;
        }

        /// <summary>
        /// Get the currently selected transaction row
        /// </summary>
        private DataGridViewRow GetSelectedTransaction()
        {
            return dgvTransactions.SelectedRows.Count > 0 ? dgvTransactions.SelectedRows[0] : null;
        }

        #endregion

        #region Private Methods - UI State Management

        /// <summary>
        /// Update button enabled states based on selection
        /// </summary>
        private void UpdateButtonStates()
        {
            bool hasSelection = GetSelectedTransaction() != null;
            btnEdit.Enabled = hasSelection;
            btnDelete.Enabled = hasSelection;
            btnAdd.Enabled = true; // Always enabled
        }

        #endregion

        #region Event Handlers

        /// <summary>
        /// Handle Add button click
        /// </summary>
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                using (var addForm = new FormTransactionEdit(_currentUserId, _serviceManager))
                {
                    if (addForm.ShowDialog() == DialogResult.OK)
                    {
                        RefreshTransactions();
                        //ShowSuccessMessage("Đã thêm giao dịch thành công!");
                    }
                }
            }
            catch (Exception ex)
            {
                ShowErrorMessage($"Lỗi khi thêm giao dịch: {ex.Message}");
            }
        }

        /// <summary>
        /// Handle Edit button click
        /// </summary>
        private void BtnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                var selectedTransaction = GetSelectedTransactionFromDb();
                if (selectedTransaction != null)
                {
                    using (var editForm = new FormTransactionEdit(_currentUserId, _serviceManager, selectedTransaction))
                    {
                        if (editForm.ShowDialog() == DialogResult.OK)
                        {
                            RefreshTransactions();
                            //ShowSuccessMessage("Đã cập nhật giao dịch thành công!");
                        }
                    }
                }
                else
                {
                    ShowWarningMessage("Vui lòng chọn giao dịch cần sửa!");
                }
            }
            catch (Exception ex)
            {
                ShowErrorMessage($"Lỗi khi chỉnh sửa giao dịch: {ex.Message}");
            }
        }

        /// <summary>
        /// Handle Delete button click
        /// </summary>
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                var selectedTransaction = GetSelectedTransactionFromDb();
                if (selectedTransaction == null)
                {
                    ShowWarningMessage("Vui lòng chọn giao dịch cần xóa!");
                    return;
                }

                if (ConfirmAction($"Bạn có chắc chắn muốn xóa giao dịch này?\n\nNgày: {selectedTransaction.Date:dd/MM/yyyy}\nDanh mục: {selectedTransaction.Category}\nSố tiền: {FormatAmount(selectedTransaction.Amount)}", "Xác nhận xóa"))
                {
                    _serviceManager.TransactionService.DeleteTransaction(selectedTransaction.TransId);
                    RefreshTransactions();
                    ShowSuccessMessage("Đã xóa giao dịch thành công!");
                }
            }
            catch (Exception ex)
            {
                ShowErrorMessage($"Lỗi khi xóa giao dịch: {ex.Message}");
            }
        }

        /// <summary>
        /// Handle DataGridView selection changed
        /// </summary>
        private void DgvTransactions_SelectionChanged(object sender, EventArgs e)
        {
            UpdateButtonStates();
        }

        /// <summary>
        /// Handle DataGridView cell double click (edit transaction)
        /// </summary>
        private void DgvTransactions_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                BtnEdit_Click(sender, e);
            }
        }

        #endregion

        #region Private Methods - Message Helpers

        private void ShowErrorMessage(string message)
        {
            MessageBox.Show(message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ShowWarningMessage(string message)
        {
            MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void ShowSuccessMessage(string message)
        {
            MessageBox.Show(message, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private bool ConfirmAction(string message, string title)
        {
            var result = MessageBox.Show(message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            return result == DialogResult.Yes;
        }

        #endregion

        #region IDisposable Implementation

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _serviceManager?.Dispose();
            }
            base.Dispose(disposing);
        }

        #endregion
    }
}