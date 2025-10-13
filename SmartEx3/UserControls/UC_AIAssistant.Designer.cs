namespace SmartEx3.UserControls
{
    partial class UC_AIAssistant
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
            this.panelMain = new System.Windows.Forms.Panel();
            this.panelContent = new System.Windows.Forms.Panel();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabSpendingAnalysis = new System.Windows.Forms.TabPage();
            this.rtbSpendingAnalysis = new System.Windows.Forms.RichTextBox();
            this.panelAnalysisOptions = new System.Windows.Forms.Panel();
            this.btnAnalyzeSpending = new System.Windows.Forms.Button();
            this.cmbAnalysisPeriod = new System.Windows.Forms.ComboBox();
            this.lblAnalysisPeriod = new System.Windows.Forms.Label();
            this.tabSavingsSuggestions = new System.Windows.Forms.TabPage();
            this.rtbSavingsSuggestions = new System.Windows.Forms.RichTextBox();
            this.btnGetSuggestions = new System.Windows.Forms.Button();
            this.tabPrediction = new System.Windows.Forms.TabPage();
            this.rtbPrediction = new System.Windows.Forms.RichTextBox();
            this.btnPredict = new System.Windows.Forms.Button();
            this.tabGoalAdvice = new System.Windows.Forms.TabPage();
            this.rtbGoalAdvice = new System.Windows.Forms.RichTextBox();
            this.panelGoalInput = new System.Windows.Forms.Panel();
            this.btnGetAdvice = new System.Windows.Forms.Button();
            this.numTargetMonths = new System.Windows.Forms.NumericUpDown();
            this.lblTargetMonths = new System.Windows.Forms.Label();
            this.txtGoalAmount = new System.Windows.Forms.TextBox();
            this.lblGoalAmount = new System.Windows.Forms.Label();
            this.tabHealthScore = new System.Windows.Forms.TabPage();
            this.rtbHealthDetails = new System.Windows.Forms.RichTextBox();
            this.panelScore = new System.Windows.Forms.Panel();
            this.lblRating = new System.Windows.Forms.Label();
            this.lblScore = new System.Windows.Forms.Label();
            this.btnEvaluateHealth = new System.Windows.Forms.Button();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtThuNhap = new System.Windows.Forms.TextBox();
            this.panelMain.SuspendLayout();
            this.panelContent.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabSpendingAnalysis.SuspendLayout();
            this.panelAnalysisOptions.SuspendLayout();
            this.tabSavingsSuggestions.SuspendLayout();
            this.tabPrediction.SuspendLayout();
            this.tabGoalAdvice.SuspendLayout();
            this.panelGoalInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTargetMonths)).BeginInit();
            this.tabHealthScore.SuspendLayout();
            this.panelScore.SuspendLayout();
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
            this.panelMain.Size = new System.Drawing.Size(1000, 700);
            this.panelMain.TabIndex = 0;
            // 
            // panelContent
            // 
            this.panelContent.BackColor = System.Drawing.Color.White;
            this.panelContent.Controls.Add(this.tabControl);
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(20, 120);
            this.panelContent.Name = "panelContent";
            this.panelContent.Padding = new System.Windows.Forms.Padding(15);
            this.panelContent.Size = new System.Drawing.Size(960, 560);
            this.panelContent.TabIndex = 1;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabSpendingAnalysis);
            this.tabControl.Controls.Add(this.tabSavingsSuggestions);
            this.tabControl.Controls.Add(this.tabPrediction);
            this.tabControl.Controls.Add(this.tabGoalAdvice);
            this.tabControl.Controls.Add(this.tabHealthScore);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl.Location = new System.Drawing.Point(15, 15);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(930, 530);
            this.tabControl.TabIndex = 0;
            // 
            // tabSpendingAnalysis
            // 
            this.tabSpendingAnalysis.Controls.Add(this.rtbSpendingAnalysis);
            this.tabSpendingAnalysis.Controls.Add(this.panelAnalysisOptions);
            this.tabSpendingAnalysis.Location = new System.Drawing.Point(4, 26);
            this.tabSpendingAnalysis.Name = "tabSpendingAnalysis";
            this.tabSpendingAnalysis.Padding = new System.Windows.Forms.Padding(10);
            this.tabSpendingAnalysis.Size = new System.Drawing.Size(922, 500);
            this.tabSpendingAnalysis.TabIndex = 0;
            this.tabSpendingAnalysis.Text = "📊 Phân tích chi tiêu";
            this.tabSpendingAnalysis.UseVisualStyleBackColor = true;
            // 
            // rtbSpendingAnalysis
            // 
            this.rtbSpendingAnalysis.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbSpendingAnalysis.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbSpendingAnalysis.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbSpendingAnalysis.Location = new System.Drawing.Point(10, 80);
            this.rtbSpendingAnalysis.Name = "rtbSpendingAnalysis";
            this.rtbSpendingAnalysis.ReadOnly = true;
            this.rtbSpendingAnalysis.Size = new System.Drawing.Size(902, 410);
            this.rtbSpendingAnalysis.TabIndex = 1;
            this.rtbSpendingAnalysis.Text = "Chọn khoảng thời gian và nhấn nút phân tích...";
            // 
            // panelAnalysisOptions
            // 
            this.panelAnalysisOptions.Controls.Add(this.btnAnalyzeSpending);
            this.panelAnalysisOptions.Controls.Add(this.cmbAnalysisPeriod);
            this.panelAnalysisOptions.Controls.Add(this.lblAnalysisPeriod);
            this.panelAnalysisOptions.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelAnalysisOptions.Location = new System.Drawing.Point(10, 10);
            this.panelAnalysisOptions.Name = "panelAnalysisOptions";
            this.panelAnalysisOptions.Size = new System.Drawing.Size(902, 70);
            this.panelAnalysisOptions.TabIndex = 0;
            // 
            // btnAnalyzeSpending
            // 
            this.btnAnalyzeSpending.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnAnalyzeSpending.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAnalyzeSpending.FlatAppearance.BorderSize = 0;
            this.btnAnalyzeSpending.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnalyzeSpending.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnalyzeSpending.ForeColor = System.Drawing.Color.White;
            this.btnAnalyzeSpending.Location = new System.Drawing.Point(10, 35);
            this.btnAnalyzeSpending.Name = "btnAnalyzeSpending";
            this.btnAnalyzeSpending.Size = new System.Drawing.Size(882, 30);
            this.btnAnalyzeSpending.TabIndex = 2;
            this.btnAnalyzeSpending.Text = "🔍 Phân tích thói quen chi tiêu";
            this.btnAnalyzeSpending.UseVisualStyleBackColor = false;
            // 
            // cmbAnalysisPeriod
            // 
            this.cmbAnalysisPeriod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAnalysisPeriod.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbAnalysisPeriod.FormattingEnabled = true;
            this.cmbAnalysisPeriod.Items.AddRange(new object[] {
            "1 tháng gần đây",
            "3 tháng gần đây",
            "6 tháng gần đây",
            "1 năm gần đây",
            "Toàn bộ lịch sử"});
            this.cmbAnalysisPeriod.Location = new System.Drawing.Point(140, 5);
            this.cmbAnalysisPeriod.Name = "cmbAnalysisPeriod";
            this.cmbAnalysisPeriod.Size = new System.Drawing.Size(200, 25);
            this.cmbAnalysisPeriod.TabIndex = 1;
            // 
            // lblAnalysisPeriod
            // 
            this.lblAnalysisPeriod.AutoSize = true;
            this.lblAnalysisPeriod.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAnalysisPeriod.Location = new System.Drawing.Point(10, 8);
            this.lblAnalysisPeriod.Name = "lblAnalysisPeriod";
            this.lblAnalysisPeriod.Size = new System.Drawing.Size(109, 17);
            this.lblAnalysisPeriod.TabIndex = 0;
            this.lblAnalysisPeriod.Text = "Khoảng thời gian:";
            // 
            // tabSavingsSuggestions
            // 
            this.tabSavingsSuggestions.Controls.Add(this.rtbSavingsSuggestions);
            this.tabSavingsSuggestions.Controls.Add(this.btnGetSuggestions);
            this.tabSavingsSuggestions.Location = new System.Drawing.Point(4, 26);
            this.tabSavingsSuggestions.Name = "tabSavingsSuggestions";
            this.tabSavingsSuggestions.Padding = new System.Windows.Forms.Padding(10);
            this.tabSavingsSuggestions.Size = new System.Drawing.Size(922, 500);
            this.tabSavingsSuggestions.TabIndex = 1;
            this.tabSavingsSuggestions.Text = "💡 Gợi ý tiết kiệm";
            this.tabSavingsSuggestions.UseVisualStyleBackColor = true;
            // 
            // rtbSavingsSuggestions
            // 
            this.rtbSavingsSuggestions.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbSavingsSuggestions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbSavingsSuggestions.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbSavingsSuggestions.Location = new System.Drawing.Point(10, 50);
            this.rtbSavingsSuggestions.Name = "rtbSavingsSuggestions";
            this.rtbSavingsSuggestions.ReadOnly = true;
            this.rtbSavingsSuggestions.Size = new System.Drawing.Size(902, 440);
            this.rtbSavingsSuggestions.TabIndex = 1;
            this.rtbSavingsSuggestions.Text = "Nhấn nút bên dưới để nhận gợi ý tiết kiệm...";
            // 
            // btnGetSuggestions
            // 
            this.btnGetSuggestions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnGetSuggestions.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGetSuggestions.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnGetSuggestions.FlatAppearance.BorderSize = 0;
            this.btnGetSuggestions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGetSuggestions.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGetSuggestions.ForeColor = System.Drawing.Color.White;
            this.btnGetSuggestions.Location = new System.Drawing.Point(10, 10);
            this.btnGetSuggestions.Name = "btnGetSuggestions";
            this.btnGetSuggestions.Size = new System.Drawing.Size(902, 40);
            this.btnGetSuggestions.TabIndex = 0;
            this.btnGetSuggestions.Text = "💰 Nhận gợi ý tiết kiệm thông minh";
            this.btnGetSuggestions.UseVisualStyleBackColor = false;
            // 
            // tabPrediction
            // 
            this.tabPrediction.Controls.Add(this.rtbPrediction);
            this.tabPrediction.Controls.Add(this.btnPredict);
            this.tabPrediction.Location = new System.Drawing.Point(4, 26);
            this.tabPrediction.Name = "tabPrediction";
            this.tabPrediction.Padding = new System.Windows.Forms.Padding(10);
            this.tabPrediction.Size = new System.Drawing.Size(922, 500);
            this.tabPrediction.TabIndex = 2;
            this.tabPrediction.Text = "📈 Dự đoán xu hướng";
            this.tabPrediction.UseVisualStyleBackColor = true;
            // 
            // rtbPrediction
            // 
            this.rtbPrediction.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbPrediction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbPrediction.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbPrediction.Location = new System.Drawing.Point(10, 50);
            this.rtbPrediction.Name = "rtbPrediction";
            this.rtbPrediction.ReadOnly = true;
            this.rtbPrediction.Size = new System.Drawing.Size(902, 440);
            this.rtbPrediction.TabIndex = 1;
            this.rtbPrediction.Text = "Nhấn nút bên dưới để dự đoán xu hướng chi tiêu...";
            // 
            // btnPredict
            // 
            this.btnPredict.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.btnPredict.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPredict.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnPredict.FlatAppearance.BorderSize = 0;
            this.btnPredict.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPredict.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPredict.ForeColor = System.Drawing.Color.White;
            this.btnPredict.Location = new System.Drawing.Point(10, 10);
            this.btnPredict.Name = "btnPredict";
            this.btnPredict.Size = new System.Drawing.Size(902, 40);
            this.btnPredict.TabIndex = 0;
            this.btnPredict.Text = "🔮 Dự đoán xu hướng chi tiêu tháng tới";
            this.btnPredict.UseVisualStyleBackColor = false;
            // 
            // tabGoalAdvice
            // 
            this.tabGoalAdvice.Controls.Add(this.rtbGoalAdvice);
            this.tabGoalAdvice.Controls.Add(this.panelGoalInput);
            this.tabGoalAdvice.Location = new System.Drawing.Point(4, 26);
            this.tabGoalAdvice.Name = "tabGoalAdvice";
            this.tabGoalAdvice.Padding = new System.Windows.Forms.Padding(10);
            this.tabGoalAdvice.Size = new System.Drawing.Size(922, 500);
            this.tabGoalAdvice.TabIndex = 3;
            this.tabGoalAdvice.Text = "🎯 Tư vấn mục tiêu";
            this.tabGoalAdvice.UseVisualStyleBackColor = true;
            // 
            // rtbGoalAdvice
            // 
            this.rtbGoalAdvice.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbGoalAdvice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbGoalAdvice.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbGoalAdvice.Location = new System.Drawing.Point(10, 110);
            this.rtbGoalAdvice.Name = "rtbGoalAdvice";
            this.rtbGoalAdvice.ReadOnly = true;
            this.rtbGoalAdvice.Size = new System.Drawing.Size(902, 380);
            this.rtbGoalAdvice.TabIndex = 1;
            this.rtbGoalAdvice.Text = "Nhập thông tin mục tiêu và nhấn nút để nhận tư vấn...";
            // 
            // panelGoalInput
            // 
            this.panelGoalInput.Controls.Add(this.txtThuNhap);
            this.panelGoalInput.Controls.Add(this.label1);
            this.panelGoalInput.Controls.Add(this.btnGetAdvice);
            this.panelGoalInput.Controls.Add(this.numTargetMonths);
            this.panelGoalInput.Controls.Add(this.lblTargetMonths);
            this.panelGoalInput.Controls.Add(this.txtGoalAmount);
            this.panelGoalInput.Controls.Add(this.lblGoalAmount);
            this.panelGoalInput.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelGoalInput.Location = new System.Drawing.Point(10, 10);
            this.panelGoalInput.Name = "panelGoalInput";
            this.panelGoalInput.Size = new System.Drawing.Size(902, 100);
            this.panelGoalInput.TabIndex = 0;
            // 
            // btnGetAdvice
            // 
            this.btnGetAdvice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(196)))), ((int)(((byte)(15)))));
            this.btnGetAdvice.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGetAdvice.FlatAppearance.BorderSize = 0;
            this.btnGetAdvice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGetAdvice.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGetAdvice.ForeColor = System.Drawing.Color.White;
            this.btnGetAdvice.Location = new System.Drawing.Point(10, 50);
            this.btnGetAdvice.Name = "btnGetAdvice";
            this.btnGetAdvice.Size = new System.Drawing.Size(882, 40);
            this.btnGetAdvice.TabIndex = 4;
            this.btnGetAdvice.Text = "🎯 Nhận tư vấn cách đạt mục tiêu";
            this.btnGetAdvice.UseVisualStyleBackColor = false;
            this.btnGetAdvice.Click += new System.EventHandler(this.btnGetAdvice_Click_1);
            // 
            // numTargetMonths
            // 
            this.numTargetMonths.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numTargetMonths.Location = new System.Drawing.Point(774, 10);
            this.numTargetMonths.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.numTargetMonths.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numTargetMonths.Name = "numTargetMonths";
            this.numTargetMonths.Size = new System.Drawing.Size(100, 24);
            this.numTargetMonths.TabIndex = 3;
            this.numTargetMonths.Value = new decimal(new int[] {
            12,
            0,
            0,
            0});
            // 
            // lblTargetMonths
            // 
            this.lblTargetMonths.AutoSize = true;
            this.lblTargetMonths.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTargetMonths.Location = new System.Drawing.Point(631, 12);
            this.lblTargetMonths.Name = "lblTargetMonths";
            this.lblTargetMonths.Size = new System.Drawing.Size(124, 17);
            this.lblTargetMonths.TabIndex = 2;
            this.lblTargetMonths.Text = "Trong vòng (tháng):";
            this.lblTargetMonths.Click += new System.EventHandler(this.lblTargetMonths_Click);
            // 
            // txtGoalAmount
            // 
            this.txtGoalAmount.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGoalAmount.Location = new System.Drawing.Point(173, 9);
            this.txtGoalAmount.Name = "txtGoalAmount";
            this.txtGoalAmount.Size = new System.Drawing.Size(148, 24);
            this.txtGoalAmount.TabIndex = 1;
            // 
            // lblGoalAmount
            // 
            this.lblGoalAmount.AutoSize = true;
            this.lblGoalAmount.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGoalAmount.Location = new System.Drawing.Point(10, 10);
            this.lblGoalAmount.Name = "lblGoalAmount";
            this.lblGoalAmount.Size = new System.Drawing.Size(157, 17);
            this.lblGoalAmount.TabIndex = 0;
            this.lblGoalAmount.Text = "Số tiền muốn tiết kiệm (₫):";
            // 
            // tabHealthScore
            // 
            this.tabHealthScore.Controls.Add(this.rtbHealthDetails);
            this.tabHealthScore.Controls.Add(this.panelScore);
            this.tabHealthScore.Controls.Add(this.btnEvaluateHealth);
            this.tabHealthScore.Location = new System.Drawing.Point(4, 26);
            this.tabHealthScore.Name = "tabHealthScore";
            this.tabHealthScore.Padding = new System.Windows.Forms.Padding(10);
            this.tabHealthScore.Size = new System.Drawing.Size(922, 500);
            this.tabHealthScore.TabIndex = 4;
            this.tabHealthScore.Text = "❤️ Sức khỏe tài chính";
            this.tabHealthScore.UseVisualStyleBackColor = true;
            // 
            // rtbHealthDetails
            // 
            this.rtbHealthDetails.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbHealthDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbHealthDetails.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbHealthDetails.Location = new System.Drawing.Point(10, 130);
            this.rtbHealthDetails.Name = "rtbHealthDetails";
            this.rtbHealthDetails.ReadOnly = true;
            this.rtbHealthDetails.Size = new System.Drawing.Size(902, 360);
            this.rtbHealthDetails.TabIndex = 2;
            this.rtbHealthDetails.Text = "Nhấn nút để đánh giá sức khỏe tài chính của bạn...";
            // 
            // panelScore
            // 
            this.panelScore.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(244)))), ((int)(((byte)(254)))));
            this.panelScore.Controls.Add(this.lblRating);
            this.panelScore.Controls.Add(this.lblScore);
            this.panelScore.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelScore.Location = new System.Drawing.Point(10, 50);
            this.panelScore.Name = "panelScore";
            this.panelScore.Size = new System.Drawing.Size(902, 80);
            this.panelScore.TabIndex = 1;
            // 
            // lblRating
            // 
            this.lblRating.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblRating.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRating.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblRating.Location = new System.Drawing.Point(300, 0);
            this.lblRating.Name = "lblRating";
            this.lblRating.Size = new System.Drawing.Size(602, 80);
            this.lblRating.TabIndex = 1;
            this.lblRating.Text = "Chưa đánh giá";
            this.lblRating.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblScore
            // 
            this.lblScore.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblScore.Font = new System.Drawing.Font("Century Gothic", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScore.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.lblScore.Location = new System.Drawing.Point(0, 0);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(300, 80);
            this.lblScore.TabIndex = 0;
            this.lblScore.Text = "--/100";
            this.lblScore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnEvaluateHealth
            // 
            this.btnEvaluateHealth.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnEvaluateHealth.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEvaluateHealth.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnEvaluateHealth.FlatAppearance.BorderSize = 0;
            this.btnEvaluateHealth.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEvaluateHealth.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEvaluateHealth.ForeColor = System.Drawing.Color.White;
            this.btnEvaluateHealth.Location = new System.Drawing.Point(10, 10);
            this.btnEvaluateHealth.Name = "btnEvaluateHealth";
            this.btnEvaluateHealth.Size = new System.Drawing.Size(902, 40);
            this.btnEvaluateHealth.TabIndex = 0;
            this.btnEvaluateHealth.Text = "❤️ Đánh giá sức khỏe tài chính";
            this.btnEvaluateHealth.UseVisualStyleBackColor = false;
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.White;
            this.panelHeader.Controls.Add(this.lblSubtitle);
            this.panelHeader.Controls.Add(this.lblTitle);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(20, 20);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Padding = new System.Windows.Forms.Padding(15);
            this.panelHeader.Size = new System.Drawing.Size(960, 100);
            this.panelHeader.TabIndex = 0;
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSubtitle.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(140)))), ((int)(((byte)(141)))));
            this.lblSubtitle.Location = new System.Drawing.Point(15, 55);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(930, 30);
            this.lblSubtitle.TabIndex = 1;
            this.lblSubtitle.Text = "Phân tích thông minh, gợi ý tiết kiệm và dự đoán xu hướng chi tiêu của bạn";
            this.lblSubtitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Century Gothic", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.lblTitle.Location = new System.Drawing.Point(15, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(930, 40);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "🤖 Trợ lý AI thông minh \r\n";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(343, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Thu nhập hàng tháng";
            // 
            // txtThuNhap
            // 
            this.txtThuNhap.Location = new System.Drawing.Point(479, 10);
            this.txtThuNhap.Name = "txtThuNhap";
            this.txtThuNhap.Size = new System.Drawing.Size(100, 22);
            this.txtThuNhap.TabIndex = 6;
            this.txtThuNhap.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // UC_AIAssistant
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(244)))), ((int)(((byte)(254)))));
            this.Controls.Add(this.panelMain);
            this.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "UC_AIAssistant";
            this.Size = new System.Drawing.Size(1000, 700);
            this.panelMain.ResumeLayout(false);
            this.panelContent.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tabSpendingAnalysis.ResumeLayout(false);
            this.panelAnalysisOptions.ResumeLayout(false);
            this.panelAnalysisOptions.PerformLayout();
            this.tabSavingsSuggestions.ResumeLayout(false);
            this.tabPrediction.ResumeLayout(false);
            this.tabGoalAdvice.ResumeLayout(false);
            this.panelGoalInput.ResumeLayout(false);
            this.panelGoalInput.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTargetMonths)).EndInit();
            this.tabHealthScore.ResumeLayout(false);
            this.panelScore.ResumeLayout(false);
            this.panelHeader.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabSpendingAnalysis;
        private System.Windows.Forms.RichTextBox rtbSpendingAnalysis;
        private System.Windows.Forms.Panel panelAnalysisOptions;
        private System.Windows.Forms.Label lblAnalysisPeriod;
        private System.Windows.Forms.ComboBox cmbAnalysisPeriod;
        private System.Windows.Forms.Button btnAnalyzeSpending;
        private System.Windows.Forms.TabPage tabSavingsSuggestions;
        private System.Windows.Forms.RichTextBox rtbSavingsSuggestions;
        private System.Windows.Forms.Button btnGetSuggestions;
        private System.Windows.Forms.TabPage tabPrediction;
        private System.Windows.Forms.RichTextBox rtbPrediction;
        private System.Windows.Forms.Button btnPredict;
        private System.Windows.Forms.TabPage tabGoalAdvice;
        private System.Windows.Forms.RichTextBox rtbGoalAdvice;
        private System.Windows.Forms.Panel panelGoalInput;
        private System.Windows.Forms.Button btnGetAdvice;
        private System.Windows.Forms.NumericUpDown numTargetMonths;
        private System.Windows.Forms.Label lblTargetMonths;
        private System.Windows.Forms.TextBox txtGoalAmount;
        private System.Windows.Forms.Label lblGoalAmount;
        private System.Windows.Forms.TabPage tabHealthScore;
        private System.Windows.Forms.RichTextBox rtbHealthDetails;
        private System.Windows.Forms.Panel panelScore;
        private System.Windows.Forms.Label lblRating;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.Button btnEvaluateHealth;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtThuNhap;
        private System.Windows.Forms.Label label1;
    }
}
