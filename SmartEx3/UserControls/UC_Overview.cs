using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace SmartEx3.UserControls
{
    public partial class UC_Overview : UserControl
    {
        private Chart chartCategoryExpense;
        private Chart chartTrendExpense;

        public UC_Overview()
        {
            InitializeComponent();
            InitializeCharts();
        }

        /// Khởi tạo các biểu đồ
        private void InitializeCharts()
        {
            // Khởi tạo biểu đồ phân loại chi tiêu (Pie Chart)
            InitializeCategoryChart();

            // Khởi tạo biểu đồ xu hướng chi tiêu (Column Chart)
            InitializeTrendChart();
        }

        //Khởi tạo biểu đồ tròn phân loại chi tiêu
        private void InitializeCategoryChart()
        {
            // Xóa placeholder label
            lblChart1Placeholder.Visible = false;

            // Tạo Chart
            chartCategoryExpense = new Chart
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White
            };

            // Thêm Chart Area
            ChartArea chartArea = new ChartArea("CategoryArea")
            {
                BackColor = Color.White,
                Area3DStyle = { Enable3D = true, Inclination = 15, Rotation = 10 }
            };
            chartCategoryExpense.ChartAreas.Add(chartArea);

            // Thêm Series
            Series series = new Series("CategorySeries")
            {
                ChartType = SeriesChartType.Pie,
                IsValueShownAsLabel = true,
                Font = new Font("Century Gothic", 9F, FontStyle.Bold),
                LabelFormat = "0,0 ₫"
            };
            chartCategoryExpense.Series.Add(series);

            // Thêm Title
            Title title = new Title
            {
                Text = "📊 Phân loại chi tiêu theo danh mục",
                Font = new Font("Century Gothic", 12F, FontStyle.Bold),
                ForeColor = Color.FromArgb(52, 152, 219),
                Docking = Docking.Top
            };
            chartCategoryExpense.Titles.Add(title);

            // Thêm Legend
            Legend legend = new Legend
            {
                Name = "CategoryLegend",
                Docking = Docking.Right,
                Font = new Font("Century Gothic", 8F),
                Alignment = StringAlignment.Center,
                BackColor = Color.Transparent
            };
            chartCategoryExpense.Legends.Add(legend);

            // Thêm Chart vào panel
            panelChart1.Controls.Add(chartCategoryExpense);
        }

        /// Khởi tạo biểu đồ cột xu hướng chi tiêu
        private void InitializeTrendChart()
        {
            // Xóa placeholder label
            lblChart2Placeholder.Visible = false;

            // Tạo Chart
            chartTrendExpense = new Chart
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White
            };

            // Thêm Chart Area
            ChartArea chartArea = new ChartArea("TrendArea")
            {
                BackColor = Color.White,
                AxisX = new Axis
                {
                    Title = "Ngày",
                    TitleFont = new Font("Century Gothic", 9F, FontStyle.Bold),
                    LabelStyle = { Font = new Font("Century Gothic", 8F), Angle = -45 },
                    MajorGrid = { LineColor = Color.LightGray, LineDashStyle = ChartDashStyle.Dot }
                },
                AxisY = new Axis
                {
                    Title = "Số tiền (₫)",
                    TitleFont = new Font("Century Gothic", 9F, FontStyle.Bold),
                    LabelStyle = { Font = new Font("Century Gothic", 8F), Format = "N0" },
                    MajorGrid = { LineColor = Color.LightGray, LineDashStyle = ChartDashStyle.Dot }
                }
            };
            chartTrendExpense.ChartAreas.Add(chartArea);

            // Thêm Series cho Chi tiêu
            Series expenseSeries = new Series("Expense")
            {
                ChartType = SeriesChartType.Column,
                Color = Color.FromArgb(231, 76, 60),
                BorderWidth = 2,
                LabelFormat = "N0",
                IsValueShownAsLabel = false,
                Font = new Font("Century Gothic", 8F),
                LegendText = "Chi tiêu"
            };
            chartTrendExpense.Series.Add(expenseSeries);

            // Thêm Series cho Thu nhập
            Series incomeSeries = new Series("Income")
            {
                ChartType = SeriesChartType.Column,
                Color = Color.FromArgb(46, 204, 113),
                BorderWidth = 2,
                LabelFormat = "N0",
                IsValueShownAsLabel = false,
                Font = new Font("Century Gothic", 8F),
                LegendText = "Thu nhập"
            };
            chartTrendExpense.Series.Add(incomeSeries);

            // Thêm Title
            Title title = new Title
            {
                Text = "📈 Xu hướng thu chi trong 7 ngày gần đây",
                Font = new Font("Century Gothic", 12F, FontStyle.Bold),
                ForeColor = Color.FromArgb(52, 152, 219),
                Docking = Docking.Top
            };
            chartTrendExpense.Titles.Add(title);

            // Thêm Legend
            Legend legend = new Legend
            {
                Name = "TrendLegend",
                Docking = Docking.Top,
                Font = new Font("Century Gothic", 9F),
                Alignment = StringAlignment.Center,
                BackColor = Color.Transparent
            };
            chartTrendExpense.Legends.Add(legend);

            // Thêm Chart vào panel
            panelChart2.Controls.Add(chartTrendExpense);
        }

        /// Cập nhật dữ liệu biểu đồ phân loại chi tiêu
        public void UpdateCategoryChart(Dictionary<string, decimal> categoryData)
        {
            if (chartCategoryExpense == null || categoryData == null || categoryData.Count == 0)
                return;

            // Xóa dữ liệu cũ
            chartCategoryExpense.Series["CategorySeries"].Points.Clear();

            // Định nghĩa màu sắc cho các danh mục
            Color[] colors = new Color[]
            {
                Color.FromArgb(231, 76, 60),   // Đỏ
                Color.FromArgb(52, 152, 219),  // Xanh dương
                Color.FromArgb(46, 204, 113),  // Xanh lá
                Color.FromArgb(241, 196, 15),  // Vàng
                Color.FromArgb(155, 89, 182),  // Tím
                Color.FromArgb(230, 126, 34),  // Cam
                Color.FromArgb(26, 188, 156),  // Xanh ngọc
                Color.FromArgb(149, 165, 166)  // Xám
            };

            int colorIndex = 0;

            // Chỉ hiển thị chi tiêu (số âm), bỏ qua thu nhập
            foreach (var category in categoryData.Where(c => c.Value < 0).OrderByDescending(c => Math.Abs(c.Value)))
            {
                var point = chartCategoryExpense.Series["CategorySeries"].Points.Add((double)Math.Abs(category.Value));
                point.LegendText = category.Key;
                point.Label = string.Format("{0:N0} ₫", Math.Abs(category.Value));
                point.Color = colors[colorIndex % colors.Length];
                point.LabelForeColor = Color.White;
                
                colorIndex++;
            }

            // Nếu không có dữ liệu, hiển thị thông báo
            if (chartCategoryExpense.Series["CategorySeries"].Points.Count == 0)
            {
                lblChart1Placeholder.Visible = true;
                lblChart1Placeholder.Text = "📊 Chưa có dữ liệu chi tiêu";
                chartCategoryExpense.Visible = false;
            }
            else
            {
                lblChart1Placeholder.Visible = false;
                chartCategoryExpense.Visible = true;
            }
        }

    
        /// Cập nhật biểu đồ xu hướng từ dữ liệu đơn giản hơn
        /// <param name="dailyExpense">Dictionary với key là ngày và value là tổng chi tiêu</param>
        /// <param name="dailyIncome">Dictionary với key là ngày và value là tổng thu nhập</param>
        public void UpdateTrendChartSimple(Dictionary<DateTime, decimal> dailyExpense, Dictionary<DateTime, decimal> dailyIncome)
        {
            if (chartTrendExpense == null)
                return;

            // Xóa dữ liệu cũ
            chartTrendExpense.Series["Expense"].Points.Clear();
            chartTrendExpense.Series["Income"].Points.Clear();

            // Lấy tất cả các ngày duy nhất
            var allDates = new HashSet<DateTime>();
            if (dailyExpense != null)
                foreach (var date in dailyExpense.Keys) allDates.Add(date);
            if (dailyIncome != null)
                foreach (var date in dailyIncome.Keys) allDates.Add(date);

            // Nếu không có dữ liệu, hiển thị thông báo và thoát
            if (allDates.Count == 0)
            {
                lblChart2Placeholder.Visible = true;
                lblChart2Placeholder.Text = "📈 Chưa có dữ liệu giao dịch";
                chartTrendExpense.Visible = false;
                return;
            }

            // Thêm dữ liệu theo thứ tự ngày
            foreach (var date in allDates.OrderBy(d => d))
            {
                string dateLabel = date.ToString("dd/MM");
                
                // FIX: Đảm bảo lấy giá trị tuyệt đối cho chi tiêu
                decimal expense = (dailyExpense != null && dailyExpense.ContainsKey(date)) 
                    ? Math.Abs(dailyExpense[date]) : 0;
                decimal income = (dailyIncome != null && dailyIncome.ContainsKey(date)) 
                    ? Math.Abs(dailyIncome[date]) : 0;

                // Thêm điểm dữ liệu cho chi tiêu - CAST TO DOUBLE
                var expensePoint = chartTrendExpense.Series["Expense"].Points.AddXY(dateLabel, (double)expense);
                chartTrendExpense.Series["Expense"].Points[expensePoint].ToolTip = 
                    string.Format("{0}\nChi tiêu: {1:N0} ₫", date.ToString("dd/MM/yyyy"), expense);

                // Thêm điểm dữ liệu cho thu nhập - CAST TO DOUBLE
                var incomePoint = chartTrendExpense.Series["Income"].Points.AddXY(dateLabel, (double)income);
                chartTrendExpense.Series["Income"].Points[incomePoint].ToolTip = 
                    string.Format("{0}\nThu nhập: {1:N0} ₫", date.ToString("dd/MM/yyyy"), income);
            }

            lblChart2Placeholder.Visible = false;
            chartTrendExpense.Visible = true;
        }

        // Properties to update the financial data
        public decimal Balance
        {
            get { return GetDecimalFromLabel(lblBalanceAmount.Text); }
            set { lblBalanceAmount.Text = FormatCurrency(value); }
        }

        public decimal Income
        {
            get { return GetDecimalFromLabel(lblIncomeAmount.Text); }
            set { lblIncomeAmount.Text = FormatCurrency(value); }
        }

        public decimal Expense
        {
            get { return GetDecimalFromLabel(lblExpenseAmount.Text); }
            set { lblExpenseAmount.Text = FormatCurrency(value); }
        }

        // Method to update all values at once
        public void UpdateFinancialData(decimal balance, decimal income, decimal expense)
        {
            Balance = balance;
            Income = income;
            Expense = expense;
        }

        // Helper method to format currency
        private string FormatCurrency(decimal amount)
        {
            return amount.ToString("#,##0") + " ₫";
        }

        // Helper method to parse currency from label text
        private decimal GetDecimalFromLabel(string labelText)
        {
            try
            {
                string numericString = labelText.Replace(" ₫", "").Replace(",", "");
                return decimal.Parse(numericString);
            }
            catch
            {
                return 0;
            }
        }

        // Method to set chart placeholder text
        public void SetChart1PlaceholderText(string text)
        {
            lblChart1Placeholder.Text = text;
        }

        public void SetChart2PlaceholderText(string text)
        {
            lblChart2Placeholder.Text = text;
        }

        // Method to xóa tất cả dữ liệu biểu đồ
        public void ClearCharts()
        {
            if (chartCategoryExpense != null && chartCategoryExpense.Series.Count > 0)
            {
                chartCategoryExpense.Series["CategorySeries"].Points.Clear();
                chartCategoryExpense.Visible = false;
            }

            if (chartTrendExpense != null && chartTrendExpense.Series.Count > 0)
            {
                chartTrendExpense.Series["Expense"].Points.Clear();
                chartTrendExpense.Series["Income"].Points.Clear();
                chartTrendExpense.Visible = false;
            }

            lblChart1Placeholder.Visible = true;
            lblChart2Placeholder.Visible = true;
            lblChart1Placeholder.Text = "📊 Biểu đồ phân loại chi tiêu";
            lblChart2Placeholder.Text = "📈 Biểu đồ xu hướng chi tiêu";
        }
    }
}
