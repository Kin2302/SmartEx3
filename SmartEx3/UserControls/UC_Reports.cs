using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using SmartEx3.Models;
using SmartEx3.Services;
using System.IO;
using System.Text;

namespace SmartEx3.UserControls
{
    public partial class UC_Reports : UserControl
    {
        #region Private Fields

        private ServiceManager _serviceManager;
        private int _currentUserId;
        private List<Transaction> _transactions;
        private DateTime _startDate;
        private DateTime _endDate;

        #endregion

        #region Constructor

        public UC_Reports()
        {
            InitializeComponent();
            _startDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            _endDate = DateTime.Now.Date;
        }

        #endregion

        #region Public Methods

        public void Initialize(ServiceManager serviceManager, int userId)
        {
            _serviceManager = serviceManager ?? throw new ArgumentNullException(nameof(serviceManager));
            _currentUserId = userId;
            LoadReportData();
        }

        public void RefreshData()
        {
            if (_serviceManager != null && _currentUserId > 0)
                LoadReportData();
        }

        #endregion

        #region Load Data

        private void LoadReportData()
        {
            if (_serviceManager == null || _currentUserId == 0) return;

            try
            {
                _transactions = _serviceManager.TransactionService
                    .GetTransactionsByDateRange(_startDate, _endDate)
                    .Where(t => t.UserId == _currentUserId)
                    .ToList();

                UpdateSummaryCards();
                UpdateCharts();
                UpdateInsights();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Update UI

        private void UpdateSummaryCards()
        {
            decimal totalIncome = _transactions?.Where(t => t.Amount > 0).Sum(t => (decimal?)t.Amount) ?? 0;
            decimal totalExpense = _transactions?.Where(t => t.Amount < 0).Sum(t => (decimal?)Math.Abs(t.Amount)) ?? 0;
            decimal balance = totalIncome - totalExpense;
            decimal savingRate = totalIncome > 0 ? (balance / totalIncome) * 100 : 0;

            lblIncomeValue.Text = FormatCurrency(totalIncome);
            lblExpenseValue.Text = FormatCurrency(totalExpense);
            lblBalanceValue.Text = FormatCurrency(balance);
            lblSavingRateValue.Text = savingRate.ToString("0.0") + "%";

            // Update balance card color
            panelBalanceCard.BackColor = balance >= 0 
                ? Color.FromArgb(46, 204, 113) 
                : Color.FromArgb(231, 76, 60);
        }

        private void UpdateCharts()
        {
            UpdatePieChart();
            UpdateLineChart();
        }

        private void UpdatePieChart()
        {
            chartCategory.Series[0].Points.Clear();

            if (_transactions == null || !_transactions.Any())
            {
                chartCategory.Visible = false;
                lblChartPlaceholder.Visible = true;
                return;
            }

            var categoryData = _transactions
                .Where(t => t.Amount < 0 && !string.IsNullOrEmpty(t.Category))
                .GroupBy(t => t.Category)
                .Select(g => new { 
                    Category = g.Key, 
                    Amount = Math.Abs(g.Sum(t => t.Amount)) 
                })
                .OrderByDescending(x => x.Amount)
                .ToList();

            if (!categoryData.Any())
            {
                chartCategory.Visible = false;
                lblChartPlaceholder.Visible = true;
                return;
            }

            Color[] colors = { 
                Color.FromArgb(231, 76, 60), Color.FromArgb(52, 152, 219), 
                Color.FromArgb(46, 204, 113), Color.FromArgb(241, 196, 15), 
                Color.FromArgb(155, 89, 182), Color.FromArgb(230, 126, 34),
                Color.FromArgb(26, 188, 156), Color.FromArgb(149, 165, 166) 
            };

            decimal total = categoryData.Sum(x => x.Amount);
            int colorIndex = 0;

            foreach (var item in categoryData)
            {
                var point = chartCategory.Series[0].Points.Add((double)item.Amount);
                point.LegendText = $"{item.Category} ({FormatCurrency(item.Amount)})";
                point.Label = ((item.Amount / total) * 100).ToString("0.0") + "%";
                point.Color = colors[colorIndex++ % colors.Length];
                point.LabelForeColor = Color.White;
            }

            chartCategory.Visible = true;
            lblChartPlaceholder.Visible = false;
        }

        private void UpdateLineChart()
        {
            chartTrend.Series["Income"].Points.Clear();
            chartTrend.Series["Expense"].Points.Clear();

            if (_transactions == null || !_transactions.Any())
            {
                chartTrend.Visible = false;
                lblTrendPlaceholder.Visible = true;
                return;
            }

            var dailyData = _transactions
                .GroupBy(t => t.Date.Date)
                .Select(g => new
                {
                    Date = g.Key,
                    Income = g.Where(t => t.Amount > 0).Sum(t => (decimal?)t.Amount) ?? 0,
                    Expense = Math.Abs(g.Where(t => t.Amount < 0).Sum(t => (decimal?)t.Amount) ?? 0)
                })
                .OrderBy(x => x.Date)
                .ToList();

            foreach (var day in dailyData)
            {
                string dateLabel = day.Date.ToString("dd/MM");
                chartTrend.Series["Income"].Points.AddXY(dateLabel, (double)day.Income);
                chartTrend.Series["Expense"].Points.AddXY(dateLabel, (double)day.Expense);
            }

            chartTrend.Visible = true;
            lblTrendPlaceholder.Visible = false;
        }

        private void UpdateInsights()
        {
            rtbInsights.Clear();

            if (_transactions == null || !_transactions.Any())
            {
                AppendInsight("ℹ️ Chưa có dữ liệu để phân tích.", Color.Gray);
                return;
            }

            decimal totalIncome = _transactions.Where(t => t.Amount > 0).Sum(t => (decimal?)t.Amount) ?? 0;
            decimal totalExpense = Math.Abs(_transactions.Where(t => t.Amount < 0).Sum(t => (decimal?)t.Amount) ?? 0);
            decimal savingRate = totalIncome > 0 ? ((totalIncome - totalExpense) / totalIncome) * 100 : 0;

            // Top spending categories
            var topCategories = _transactions
                .Where(t => t.Amount < 0 && !string.IsNullOrEmpty(t.Category))
                .GroupBy(t => t.Category)
                .Select(g => new { Category = g.Key, Amount = Math.Abs(g.Sum(t => t.Amount)) })
                .OrderByDescending(x => x.Amount)
                .Take(3)
                .ToList();

            if (topCategories.Any())
            {
                AppendInsight("📌 Top 3 danh mục chi tiêu:", Color.FromArgb(52, 73, 94), true);
                for (int i = 0; i < topCategories.Count; i++)
                {
                    decimal percent = totalExpense > 0 ? (topCategories[i].Amount / totalExpense) * 100 : 0;
                    AppendInsight($"   {i + 1}. {topCategories[i].Category}: {FormatCurrency(topCategories[i].Amount)} ({percent:0.0}%)", 
                        Color.FromArgb(44, 62, 80));
                }
                rtbInsights.AppendText("\n");
            }

            // Saving rate analysis
            if (savingRate >= 20)
                AppendInsight($"✅ Xuất sắc! Tỉ lệ tiết kiệm {savingRate:0.0}%", Color.FromArgb(39, 174, 96), true);
            else if (savingRate >= 10)
                AppendInsight($"⚠️ Tỉ lệ tiết kiệm {savingRate:0.0}% - Hãy cố gắng tăng lên 20%", Color.FromArgb(243, 156, 18), true);
            else if (savingRate >= 0)
                AppendInsight($"❌ Tỉ lệ tiết kiệm chỉ {savingRate:0.0}%", Color.FromArgb(231, 76, 60), true);
            else
                AppendInsight($"🚨 Cảnh báo: Chi vượt thu! ({savingRate:0.0}%)", Color.FromArgb(192, 57, 43), true);
        }

        private void AppendInsight(string text, Color color, bool bold = false)
        {
            int start = rtbInsights.TextLength;
            rtbInsights.AppendText(text + "\n");
            int end = rtbInsights.TextLength;
            rtbInsights.Select(start, end - start);
            rtbInsights.SelectionColor = color;
            if (bold) rtbInsights.SelectionFont = new Font(rtbInsights.Font, FontStyle.Bold);
            rtbInsights.Select(end, 0);
        }

        #endregion

        #region Event Handlers

        private void cmbPeriod_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool isCustom = cmbPeriod.SelectedIndex == 4;
            dtpStartDate.Visible = isCustom;
            dtpEndDate.Visible = isCustom;
            lblTo.Visible = isCustom;

            if (!isCustom)
            {
                SetDateRangeFromPeriod();
                LoadReportData();
            }
        }

        private void SetDateRangeFromPeriod()
        {
            DateTime now = DateTime.Now;
            switch (cmbPeriod.SelectedIndex)
            {
                case 0: // Tháng này
                    _startDate = new DateTime(now.Year, now.Month, 1);
                    _endDate = now.Date;
                    break;
                case 1: // Tháng trước
                    DateTime lastMonth = now.AddMonths(-1);
                    _startDate = new DateTime(lastMonth.Year, lastMonth.Month, 1);
                    _endDate = _startDate.AddMonths(1).AddDays(-1);
                    break;
                case 2: // 3 tháng
                    _startDate = now.AddMonths(-3).Date;
                    _endDate = now.Date;
                    break;
                case 3: // Năm nay
                    _startDate = new DateTime(now.Year, 1, 1);
                    _endDate = now.Date;
                    break;
            }
        }

        private void btnApplyFilter_Click(object sender, EventArgs e)
        {
            if (cmbPeriod.SelectedIndex == 4)
            {
                _startDate = dtpStartDate.Value.Date;
                _endDate = dtpEndDate.Value.Date;
                
                if (_startDate > _endDate)
                {
                    MessageBox.Show("Ngày bắt đầu không thể lớn hơn ngày kết thúc!", 
                        "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            LoadReportData();
        }

        private void btnExportCSV_Click(object sender, EventArgs e)
        {
            if (_transactions == null || !_transactions.Any())
            {
                MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "CSV files (*.csv)|*.csv";
                sfd.FileName = $"BaoCao_ChiTieu_{DateTime.Now:yyyyMMdd_HHmmss}.csv";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        StringBuilder csv = new StringBuilder();
                        csv.AppendLine("Ngày,Loại,Số tiền,Danh mục,Ghi chú");

                        foreach (var trans in _transactions.OrderBy(t => t.Date))
                        {
                            string type = trans.Amount > 0 ? "Thu nhập" : "Chi tiêu";
                            string category = trans.Category ?? "Thu nhập";
                            string note = trans.Note ?? "";
                            csv.AppendLine($"{trans.Date:dd/MM/yyyy},{type},{trans.Amount},\"{category}\",\"{note}\"");
                        }

                        File.WriteAllText(sfd.FileName, csv.ToString(), Encoding.UTF8);
                        MessageBox.Show("Xuất file CSV thành công!", "Thành công", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi khi xuất file: {ex.Message}", "Lỗi", 
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        #endregion

        #region Helper Methods

        private string FormatCurrency(decimal amount)
        {
            return amount.ToString("#,##0") + " ₫";
        }

        #endregion
    }
}
