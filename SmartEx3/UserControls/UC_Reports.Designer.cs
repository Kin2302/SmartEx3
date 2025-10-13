namespace SmartEx3.UserControls
{
    partial class UC_Reports
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.panelMain = new System.Windows.Forms.Panel();
            this.panelContent = new System.Windows.Forms.Panel();
            this.panelInsights = new System.Windows.Forms.Panel();
            this.rtbInsights = new System.Windows.Forms.RichTextBox();
            this.lblInsightsTitle = new System.Windows.Forms.Label();
            this.panelCharts = new System.Windows.Forms.Panel();
            this.panelChart2 = new System.Windows.Forms.Panel();
            this.chartTrend = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lblTrendPlaceholder = new System.Windows.Forms.Label();
            this.panelChart1 = new System.Windows.Forms.Panel();
            this.chartCategory = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lblChartPlaceholder = new System.Windows.Forms.Label();
            this.panelSummary = new System.Windows.Forms.Panel();
            this.panelSavingCard = new System.Windows.Forms.Panel();
            this.lblSavingRateValue = new System.Windows.Forms.Label();
            this.lblSavingRateTitle = new System.Windows.Forms.Label();
            this.panelBalanceCard = new System.Windows.Forms.Panel();
            this.lblBalanceValue = new System.Windows.Forms.Label();
            this.lblBalanceTitle = new System.Windows.Forms.Label();
            this.panelExpenseCard = new System.Windows.Forms.Panel();
            this.lblExpenseValue = new System.Windows.Forms.Label();
            this.lblExpenseTitle = new System.Windows.Forms.Label();
            this.panelIncomeCard = new System.Windows.Forms.Panel();
            this.lblIncomeValue = new System.Windows.Forms.Label();
            this.lblIncomeTitle = new System.Windows.Forms.Label();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.btnExportCSV = new System.Windows.Forms.Button();
            this.btnApplyFilter = new System.Windows.Forms.Button();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.lblTo = new System.Windows.Forms.Label();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.cmbPeriod = new System.Windows.Forms.ComboBox();
            this.lblFilterTitle = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelMain.SuspendLayout();
            this.panelContent.SuspendLayout();
            this.panelInsights.SuspendLayout();
            this.panelCharts.SuspendLayout();
            this.panelChart2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartTrend)).BeginInit();
            this.panelChart1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartCategory)).BeginInit();
            this.panelSummary.SuspendLayout();
            this.panelSavingCard.SuspendLayout();
            this.panelBalanceCard.SuspendLayout();
            this.panelExpenseCard.SuspendLayout();
            this.panelIncomeCard.SuspendLayout();
            this.panelHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(244)))), ((int)(((byte)(254)))));
            this.panelMain.Controls.Add(this.panelContent);
            this.panelMain.Controls.Add(this.panelHeader);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Padding = new System.Windows.Forms.Padding(20);
            this.panelMain.Size = new System.Drawing.Size(1200, 700);
            this.panelMain.TabIndex = 0;
            // 
            // panelContent
            // 
            this.panelContent.BackColor = System.Drawing.Color.White;
            this.panelContent.Controls.Add(this.panelInsights);
            this.panelContent.Controls.Add(this.panelCharts);
            this.panelContent.Controls.Add(this.panelSummary);
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(20, 120);
            this.panelContent.Name = "panelContent";
            this.panelContent.Padding = new System.Windows.Forms.Padding(20);
            this.panelContent.Size = new System.Drawing.Size(1160, 560);
            this.panelContent.TabIndex = 1;
            // 
            // panelInsights
            // 
            this.panelInsights.Controls.Add(this.rtbInsights);
            this.panelInsights.Controls.Add(this.lblInsightsTitle);
            this.panelInsights.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelInsights.Location = new System.Drawing.Point(20, 440);
            this.panelInsights.Name = "panelInsights";
            this.panelInsights.Size = new System.Drawing.Size(1120, 100);
            this.panelInsights.TabIndex = 2;
            // 
            // rtbInsights
            // 
            this.rtbInsights.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbInsights.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbInsights.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbInsights.Location = new System.Drawing.Point(0, 30);
            this.rtbInsights.Name = "rtbInsights";
            this.rtbInsights.ReadOnly = true;
            this.rtbInsights.Size = new System.Drawing.Size(1120, 70);
            this.rtbInsights.TabIndex = 1;
            this.rtbInsights.Text = "";
            // 
            // lblInsightsTitle
            // 
            this.lblInsightsTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblInsightsTitle.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInsightsTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.lblInsightsTitle.Location = new System.Drawing.Point(0, 0);
            this.lblInsightsTitle.Name = "lblInsightsTitle";
            this.lblInsightsTitle.Size = new System.Drawing.Size(1120, 30);
            this.lblInsightsTitle.TabIndex = 0;
            this.lblInsightsTitle.Text = "💡 Phân tích & Insights";
            this.lblInsightsTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelCharts
            // 
            this.panelCharts.Controls.Add(this.panelChart2);
            this.panelCharts.Controls.Add(this.panelChart1);
            this.panelCharts.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelCharts.Location = new System.Drawing.Point(20, 140);
            this.panelCharts.Name = "panelCharts";
            this.panelCharts.Size = new System.Drawing.Size(1120, 300);
            this.panelCharts.TabIndex = 1;
            // 
            // panelChart2
            // 
            this.panelChart2.Controls.Add(this.chartTrend);
            this.panelChart2.Controls.Add(this.lblTrendPlaceholder);
            this.panelChart2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelChart2.Location = new System.Drawing.Point(560, 0);
            this.panelChart2.Name = "panelChart2";
            this.panelChart2.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.panelChart2.Size = new System.Drawing.Size(560, 300);
            this.panelChart2.TabIndex = 1;
            // 
            // chartTrend
            // 
            this.chartTrend.BackColor = System.Drawing.Color.White;
            chartArea2.AxisX.LabelStyle.Font = new System.Drawing.Font("Century Gothic", 7F);
            chartArea2.AxisX.LineColor = System.Drawing.Color.LightGray;
            chartArea2.AxisX.MajorGrid.LineColor = System.Drawing.Color.LightGray;
            chartArea2.AxisX.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;
            chartArea2.AxisY.LabelStyle.Font = new System.Drawing.Font("Century Gothic", 7F);
            chartArea2.AxisY.LabelStyle.Format = "N0";
            chartArea2.AxisY.LineColor = System.Drawing.Color.LightGray;
            chartArea2.AxisY.MajorGrid.LineColor = System.Drawing.Color.LightGray;
            chartArea2.AxisY.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;
            chartArea2.BackColor = System.Drawing.Color.White;
            chartArea2.Name = "ChartArea1";
            this.chartTrend.ChartAreas.Add(chartArea2);
            this.chartTrend.Dock = System.Windows.Forms.DockStyle.Fill;
            legend2.BackColor = System.Drawing.Color.Transparent;
            legend2.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top;
            legend2.Font = new System.Drawing.Font("Century Gothic", 8F);
            legend2.IsTextAutoFit = false;
            legend2.Name = "Legend1";
            this.chartTrend.Legends.Add(legend2);
            this.chartTrend.Location = new System.Drawing.Point(10, 0);
            this.chartTrend.Name = "chartTrend";
            series2.BorderWidth = 3;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            series2.Legend = "Legend1";
            series2.MarkerSize = 8;
            series2.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            series2.Name = "Income";
            series3.BorderWidth = 3;
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.Color = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            series3.Legend = "Legend1";
            series3.MarkerSize = 8;
            series3.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            series3.Name = "Expense";
            this.chartTrend.Series.Add(series2);
            this.chartTrend.Series.Add(series3);
            this.chartTrend.Size = new System.Drawing.Size(550, 300);
            this.chartTrend.TabIndex = 0;
            this.chartTrend.Text = "chart1";
            title2.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold);
            title2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            title2.Name = "Title1";
            title2.Text = "📈 Xu hướng thu chi";
            this.chartTrend.Titles.Add(title2);
            // 
            // lblTrendPlaceholder
            // 
            this.lblTrendPlaceholder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTrendPlaceholder.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTrendPlaceholder.ForeColor = System.Drawing.Color.Gray;
            this.lblTrendPlaceholder.Location = new System.Drawing.Point(10, 0);
            this.lblTrendPlaceholder.Name = "lblTrendPlaceholder";
            this.lblTrendPlaceholder.Size = new System.Drawing.Size(550, 300);
            this.lblTrendPlaceholder.TabIndex = 1;
            this.lblTrendPlaceholder.Text = "📈 Chưa có dữ liệu xu hướng";
            this.lblTrendPlaceholder.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTrendPlaceholder.Visible = false;
            // 
            // panelChart1
            // 
            this.panelChart1.Controls.Add(this.chartCategory);
            this.panelChart1.Controls.Add(this.lblChartPlaceholder);
            this.panelChart1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelChart1.Location = new System.Drawing.Point(0, 0);
            this.panelChart1.Name = "panelChart1";
            this.panelChart1.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.panelChart1.Size = new System.Drawing.Size(560, 300);
            this.panelChart1.TabIndex = 0;
            // 
            // chartCategory
            // 
            this.chartCategory.BackColor = System.Drawing.Color.White;
            chartArea1.Area3DStyle.Enable3D = true;
            chartArea1.Area3DStyle.Inclination = 15;
            chartArea1.Area3DStyle.Rotation = 10;
            chartArea1.BackColor = System.Drawing.Color.White;
            chartArea1.Name = "ChartArea1";
            this.chartCategory.ChartAreas.Add(chartArea1);
            this.chartCategory.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.BackColor = System.Drawing.Color.Transparent;
            legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            legend1.Font = new System.Drawing.Font("Century Gothic", 7F);
            legend1.IsTextAutoFit = false;
            legend1.Name = "Legend1";
            this.chartCategory.Legends.Add(legend1);
            this.chartCategory.Location = new System.Drawing.Point(0, 0);
            this.chartCategory.Name = "chartCategory";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series1.Font = new System.Drawing.Font("Century Gothic", 8F, System.Drawing.FontStyle.Bold);
            series1.IsValueShownAsLabel = true;
            series1.LabelFormat = "0.0%";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartCategory.Series.Add(series1);
            this.chartCategory.Size = new System.Drawing.Size(550, 300);
            this.chartCategory.TabIndex = 0;
            this.chartCategory.Text = "chart1";
            title1.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold);
            title1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            title1.Name = "Title1";
            title1.Text = "📊 Chi tiêu theo danh mục";
            this.chartCategory.Titles.Add(title1);
            // 
            // lblChartPlaceholder
            // 
            this.lblChartPlaceholder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblChartPlaceholder.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChartPlaceholder.ForeColor = System.Drawing.Color.Gray;
            this.lblChartPlaceholder.Location = new System.Drawing.Point(0, 0);
            this.lblChartPlaceholder.Name = "lblChartPlaceholder";
            this.lblChartPlaceholder.Size = new System.Drawing.Size(550, 300);
            this.lblChartPlaceholder.TabIndex = 1;
            this.lblChartPlaceholder.Text = "📊 Chưa có dữ liệu chi tiêu";
            this.lblChartPlaceholder.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblChartPlaceholder.Visible = false;
            // 
            // panelSummary
            // 
            this.panelSummary.Controls.Add(this.panelSavingCard);
            this.panelSummary.Controls.Add(this.panelBalanceCard);
            this.panelSummary.Controls.Add(this.panelExpenseCard);
            this.panelSummary.Controls.Add(this.panelIncomeCard);
            this.panelSummary.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSummary.Location = new System.Drawing.Point(20, 20);
            this.panelSummary.Name = "panelSummary";
            this.panelSummary.Size = new System.Drawing.Size(1120, 120);
            this.panelSummary.TabIndex = 0;
            // 
            // panelSavingCard
            // 
            this.panelSavingCard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.panelSavingCard.Controls.Add(this.lblSavingRateValue);
            this.panelSavingCard.Controls.Add(this.lblSavingRateTitle);
            this.panelSavingCard.Location = new System.Drawing.Point(840, 10);
            this.panelSavingCard.Name = "panelSavingCard";
            this.panelSavingCard.Padding = new System.Windows.Forms.Padding(15);
            this.panelSavingCard.Size = new System.Drawing.Size(270, 100);
            this.panelSavingCard.TabIndex = 3;
            // 
            // lblSavingRateValue
            // 
            this.lblSavingRateValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSavingRateValue.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSavingRateValue.ForeColor = System.Drawing.Color.White;
            this.lblSavingRateValue.Location = new System.Drawing.Point(15, 45);
            this.lblSavingRateValue.Name = "lblSavingRateValue";
            this.lblSavingRateValue.Size = new System.Drawing.Size(240, 40);
            this.lblSavingRateValue.TabIndex = 1;
            this.lblSavingRateValue.Text = "0%";
            this.lblSavingRateValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSavingRateTitle
            // 
            this.lblSavingRateTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblSavingRateTitle.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSavingRateTitle.ForeColor = System.Drawing.Color.White;
            this.lblSavingRateTitle.Location = new System.Drawing.Point(15, 15);
            this.lblSavingRateTitle.Name = "lblSavingRateTitle";
            this.lblSavingRateTitle.Size = new System.Drawing.Size(240, 30);
            this.lblSavingRateTitle.TabIndex = 0;
            this.lblSavingRateTitle.Text = "📊 Tỉ lệ tiết kiệm";
            this.lblSavingRateTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelBalanceCard
            // 
            this.panelBalanceCard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.panelBalanceCard.Controls.Add(this.lblBalanceValue);
            this.panelBalanceCard.Controls.Add(this.lblBalanceTitle);
            this.panelBalanceCard.Location = new System.Drawing.Point(560, 10);
            this.panelBalanceCard.Name = "panelBalanceCard";
            this.panelBalanceCard.Padding = new System.Windows.Forms.Padding(15);
            this.panelBalanceCard.Size = new System.Drawing.Size(270, 100);
            this.panelBalanceCard.TabIndex = 2;
            // 
            // lblBalanceValue
            // 
            this.lblBalanceValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblBalanceValue.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBalanceValue.ForeColor = System.Drawing.Color.White;
            this.lblBalanceValue.Location = new System.Drawing.Point(15, 45);
            this.lblBalanceValue.Name = "lblBalanceValue";
            this.lblBalanceValue.Size = new System.Drawing.Size(240, 40);
            this.lblBalanceValue.TabIndex = 1;
            this.lblBalanceValue.Text = "0 ₫";
            this.lblBalanceValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblBalanceTitle
            // 
            this.lblBalanceTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblBalanceTitle.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBalanceTitle.ForeColor = System.Drawing.Color.White;
            this.lblBalanceTitle.Location = new System.Drawing.Point(15, 15);
            this.lblBalanceTitle.Name = "lblBalanceTitle";
            this.lblBalanceTitle.Size = new System.Drawing.Size(240, 30);
            this.lblBalanceTitle.TabIndex = 0;
            this.lblBalanceTitle.Text = "💵 Số dư";
            this.lblBalanceTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelExpenseCard
            // 
            this.panelExpenseCard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.panelExpenseCard.Controls.Add(this.lblExpenseValue);
            this.panelExpenseCard.Controls.Add(this.lblExpenseTitle);
            this.panelExpenseCard.Location = new System.Drawing.Point(280, 10);
            this.panelExpenseCard.Name = "panelExpenseCard";
            this.panelExpenseCard.Padding = new System.Windows.Forms.Padding(15);
            this.panelExpenseCard.Size = new System.Drawing.Size(270, 100);
            this.panelExpenseCard.TabIndex = 1;
            // 
            // lblExpenseValue
            // 
            this.lblExpenseValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblExpenseValue.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExpenseValue.ForeColor = System.Drawing.Color.White;
            this.lblExpenseValue.Location = new System.Drawing.Point(15, 45);
            this.lblExpenseValue.Name = "lblExpenseValue";
            this.lblExpenseValue.Size = new System.Drawing.Size(240, 40);
            this.lblExpenseValue.TabIndex = 1;
            this.lblExpenseValue.Text = "0 ₫";
            this.lblExpenseValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblExpenseTitle
            // 
            this.lblExpenseTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblExpenseTitle.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExpenseTitle.ForeColor = System.Drawing.Color.White;
            this.lblExpenseTitle.Location = new System.Drawing.Point(15, 15);
            this.lblExpenseTitle.Name = "lblExpenseTitle";
            this.lblExpenseTitle.Size = new System.Drawing.Size(240, 30);
            this.lblExpenseTitle.TabIndex = 0;
            this.lblExpenseTitle.Text = "💸 Tổng chi tiêu";
            this.lblExpenseTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelIncomeCard
            // 
            this.panelIncomeCard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.panelIncomeCard.Controls.Add(this.lblIncomeValue);
            this.panelIncomeCard.Controls.Add(this.lblIncomeTitle);
            this.panelIncomeCard.Location = new System.Drawing.Point(0, 10);
            this.panelIncomeCard.Name = "panelIncomeCard";
            this.panelIncomeCard.Padding = new System.Windows.Forms.Padding(15);
            this.panelIncomeCard.Size = new System.Drawing.Size(270, 100);
            this.panelIncomeCard.TabIndex = 0;
            // 
            // lblIncomeValue
            // 
            this.lblIncomeValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblIncomeValue.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIncomeValue.ForeColor = System.Drawing.Color.White;
            this.lblIncomeValue.Location = new System.Drawing.Point(15, 45);
            this.lblIncomeValue.Name = "lblIncomeValue";
            this.lblIncomeValue.Size = new System.Drawing.Size(240, 40);
            this.lblIncomeValue.TabIndex = 1;
            this.lblIncomeValue.Text = "0 ₫";
            this.lblIncomeValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblIncomeTitle
            // 
            this.lblIncomeTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblIncomeTitle.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIncomeTitle.ForeColor = System.Drawing.Color.White;
            this.lblIncomeTitle.Location = new System.Drawing.Point(15, 15);
            this.lblIncomeTitle.Name = "lblIncomeTitle";
            this.lblIncomeTitle.Size = new System.Drawing.Size(240, 30);
            this.lblIncomeTitle.TabIndex = 0;
            this.lblIncomeTitle.Text = "💰 Tổng thu nhập";
            this.lblIncomeTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.White;
            this.panelHeader.Controls.Add(this.btnExportCSV);
            this.panelHeader.Controls.Add(this.btnApplyFilter);
            this.panelHeader.Controls.Add(this.dtpEndDate);
            this.panelHeader.Controls.Add(this.lblTo);
            this.panelHeader.Controls.Add(this.dtpStartDate);
            this.panelHeader.Controls.Add(this.cmbPeriod);
            this.panelHeader.Controls.Add(this.lblFilterTitle);
            this.panelHeader.Controls.Add(this.lblTitle);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(20, 20);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Padding = new System.Windows.Forms.Padding(20);
            this.panelHeader.Size = new System.Drawing.Size(1160, 100);
            this.panelHeader.TabIndex = 0;
            // 
            // btnExportCSV
            // 
            this.btnExportCSV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportCSV.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnExportCSV.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExportCSV.FlatAppearance.BorderSize = 0;
            this.btnExportCSV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportCSV.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportCSV.ForeColor = System.Drawing.Color.White;
            this.btnExportCSV.Location = new System.Drawing.Point(1020, 58);
            this.btnExportCSV.Name = "btnExportCSV";
            this.btnExportCSV.Size = new System.Drawing.Size(120, 30);
            this.btnExportCSV.TabIndex = 7;
            this.btnExportCSV.Text = "📄 Xuất CSV";
            this.btnExportCSV.UseVisualStyleBackColor = false;
            this.btnExportCSV.Click += new System.EventHandler(this.btnExportCSV_Click);
            // 
            // btnApplyFilter
            // 
            this.btnApplyFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnApplyFilter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnApplyFilter.FlatAppearance.BorderSize = 0;
            this.btnApplyFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApplyFilter.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApplyFilter.ForeColor = System.Drawing.Color.White;
            this.btnApplyFilter.Location = new System.Drawing.Point(650, 58);
            this.btnApplyFilter.Name = "btnApplyFilter";
            this.btnApplyFilter.Size = new System.Drawing.Size(100, 30);
            this.btnApplyFilter.TabIndex = 6;
            this.btnApplyFilter.Text = "Áp dụng";
            this.btnApplyFilter.UseVisualStyleBackColor = false;
            this.btnApplyFilter.Click += new System.EventHandler(this.btnApplyFilter_Click);
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.CustomFormat = "dd/MM/yyyy";
            this.dtpEndDate.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndDate.Location = new System.Drawing.Point(510, 62);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(120, 22);
            this.dtpEndDate.TabIndex = 5;
            this.dtpEndDate.Visible = false;
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTo.Location = new System.Drawing.Point(470, 66);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(34, 17);
            this.lblTo.TabIndex = 4;
            this.lblTo.Text = "đến";
            this.lblTo.Visible = false;
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.CustomFormat = "dd/MM/yyyy";
            this.dtpStartDate.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartDate.Location = new System.Drawing.Point(340, 62);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(120, 22);
            this.dtpStartDate.TabIndex = 3;
            this.dtpStartDate.Visible = false;
            // 
            // cmbPeriod
            // 
            this.cmbPeriod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPeriod.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPeriod.FormattingEnabled = true;
            this.cmbPeriod.Items.AddRange(new object[] {
            "Tháng này",
            "Tháng trước",
            "3 tháng gần đây",
            "Năm nay",
            "Tùy chọn"});
            this.cmbPeriod.Location = new System.Drawing.Point(170, 62);
            this.cmbPeriod.Name = "cmbPeriod";
            this.cmbPeriod.Size = new System.Drawing.Size(150, 25);
            this.cmbPeriod.TabIndex = 2;
            this.cmbPeriod.SelectedIndexChanged += new System.EventHandler(this.cmbPeriod_SelectedIndexChanged);
            // 
            // lblFilterTitle
            // 
            this.lblFilterTitle.AutoSize = true;
            this.lblFilterTitle.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFilterTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblFilterTitle.Location = new System.Drawing.Point(20, 66);
            this.lblFilterTitle.Name = "lblFilterTitle";
            this.lblFilterTitle.Size = new System.Drawing.Size(138, 16);
            this.lblFilterTitle.TabIndex = 1;
            this.lblFilterTitle.Text = "🔍 Lọc theo thời gian:";
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Century Gothic", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(1120, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "📊 Báo cáo & Phân tích tài chính";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // UC_Reports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(244)))), ((int)(((byte)(254)))));
            this.Controls.Add(this.panelMain);
            this.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "UC_Reports";
            this.Size = new System.Drawing.Size(1200, 700);
            this.panelMain.ResumeLayout(false);
            this.panelContent.ResumeLayout(false);
            this.panelInsights.ResumeLayout(false);
            this.panelCharts.ResumeLayout(false);
            this.panelChart2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartTrend)).EndInit();
            this.panelChart1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartCategory)).EndInit();
            this.panelSummary.ResumeLayout(false);
            this.panelSavingCard.ResumeLayout(false);
            this.panelBalanceCard.ResumeLayout(false);
            this.panelExpenseCard.ResumeLayout(false);
            this.panelIncomeCard.ResumeLayout(false);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblFilterTitle;
        private System.Windows.Forms.ComboBox cmbPeriod;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.Button btnApplyFilter;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.Panel panelSummary;
        private System.Windows.Forms.Panel panelIncomeCard;
        private System.Windows.Forms.Label lblIncomeTitle;
        private System.Windows.Forms.Label lblIncomeValue;
        private System.Windows.Forms.Panel panelExpenseCard;
        private System.Windows.Forms.Label lblExpenseValue;
        private System.Windows.Forms.Label lblExpenseTitle;
        private System.Windows.Forms.Panel panelBalanceCard;
        private System.Windows.Forms.Label lblBalanceValue;
        private System.Windows.Forms.Label lblBalanceTitle;
        private System.Windows.Forms.Panel panelSavingCard;
        private System.Windows.Forms.Label lblSavingRateValue;
        private System.Windows.Forms.Label lblSavingRateTitle;
        private System.Windows.Forms.Panel panelCharts;
        private System.Windows.Forms.Panel panelChart1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartCategory;
        private System.Windows.Forms.Panel panelChart2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartTrend;
        private System.Windows.Forms.Panel panelInsights;
        private System.Windows.Forms.RichTextBox rtbInsights;
        private System.Windows.Forms.Label lblInsightsTitle;
        private System.Windows.Forms.Label lblChartPlaceholder;
        private System.Windows.Forms.Label lblTrendPlaceholder;
        private System.Windows.Forms.Button btnExportCSV;
    }
}
