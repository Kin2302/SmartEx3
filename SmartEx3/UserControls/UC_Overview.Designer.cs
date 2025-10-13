namespace SmartEx3.UserControls
{
    partial class UC_Overview
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
            this.panelBalance = new System.Windows.Forms.Panel();
            this.lblBalanceAmount = new System.Windows.Forms.Label();
            this.lblBalanceTitle = new System.Windows.Forms.Label();
            this.panelIncome = new System.Windows.Forms.Panel();
            this.lblIncomeAmount = new System.Windows.Forms.Label();
            this.lblIncomeTitle = new System.Windows.Forms.Label();
            this.panelExpense = new System.Windows.Forms.Panel();
            this.lblExpenseAmount = new System.Windows.Forms.Label();
            this.lblExpenseTitle = new System.Windows.Forms.Label();
            this.panelChart1 = new System.Windows.Forms.Panel();
            this.lblChart1Placeholder = new System.Windows.Forms.Label();
            this.panelChart2 = new System.Windows.Forms.Panel();
            this.lblChart2Placeholder = new System.Windows.Forms.Label();
            this.panelBalance.SuspendLayout();
            this.panelIncome.SuspendLayout();
            this.panelExpense.SuspendLayout();
            this.panelChart1.SuspendLayout();
            this.panelChart2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelBalance
            // 
            this.panelBalance.BackColor = System.Drawing.Color.White;
            this.panelBalance.Controls.Add(this.lblBalanceAmount);
            this.panelBalance.Controls.Add(this.lblBalanceTitle);
            this.panelBalance.Location = new System.Drawing.Point(20, 20);
            this.panelBalance.Name = "panelBalance";
            this.panelBalance.Size = new System.Drawing.Size(200, 100);
            this.panelBalance.TabIndex = 0;
            // 
            // lblBalanceAmount
            // 
            this.lblBalanceAmount.Font = new System.Drawing.Font("Century Gothic", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBalanceAmount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.lblBalanceAmount.Location = new System.Drawing.Point(0, 50);
            this.lblBalanceAmount.Name = "lblBalanceAmount";
            this.lblBalanceAmount.Size = new System.Drawing.Size(200, 35);
            this.lblBalanceAmount.TabIndex = 1;
            this.lblBalanceAmount.Text = "0 ₫";
            this.lblBalanceAmount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBalanceTitle
            // 
            this.lblBalanceTitle.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBalanceTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(140)))), ((int)(((byte)(141)))));
            this.lblBalanceTitle.Location = new System.Drawing.Point(0, 15);
            this.lblBalanceTitle.Name = "lblBalanceTitle";
            this.lblBalanceTitle.Size = new System.Drawing.Size(200, 20);
            this.lblBalanceTitle.TabIndex = 0;
            this.lblBalanceTitle.Text = "💳 SỐ DƯ";
            this.lblBalanceTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelIncome
            // 
            this.panelIncome.BackColor = System.Drawing.Color.White;
            this.panelIncome.Controls.Add(this.lblIncomeAmount);
            this.panelIncome.Controls.Add(this.lblIncomeTitle);
            this.panelIncome.Location = new System.Drawing.Point(240, 20);
            this.panelIncome.Name = "panelIncome";
            this.panelIncome.Size = new System.Drawing.Size(200, 100);
            this.panelIncome.TabIndex = 1;
            // 
            // lblIncomeAmount
            // 
            this.lblIncomeAmount.Font = new System.Drawing.Font("Century Gothic", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIncomeAmount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.lblIncomeAmount.Location = new System.Drawing.Point(0, 50);
            this.lblIncomeAmount.Name = "lblIncomeAmount";
            this.lblIncomeAmount.Size = new System.Drawing.Size(200, 35);
            this.lblIncomeAmount.TabIndex = 1;
            this.lblIncomeAmount.Text = "0 ₫";
            this.lblIncomeAmount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblIncomeTitle
            // 
            this.lblIncomeTitle.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIncomeTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(140)))), ((int)(((byte)(141)))));
            this.lblIncomeTitle.Location = new System.Drawing.Point(0, 15);
            this.lblIncomeTitle.Name = "lblIncomeTitle";
            this.lblIncomeTitle.Size = new System.Drawing.Size(200, 20);
            this.lblIncomeTitle.TabIndex = 0;
            this.lblIncomeTitle.Text = "💰 THU NHẬP";
            this.lblIncomeTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelExpense
            // 
            this.panelExpense.BackColor = System.Drawing.Color.White;
            this.panelExpense.Controls.Add(this.lblExpenseAmount);
            this.panelExpense.Controls.Add(this.lblExpenseTitle);
            this.panelExpense.Location = new System.Drawing.Point(460, 20);
            this.panelExpense.Name = "panelExpense";
            this.panelExpense.Size = new System.Drawing.Size(200, 100);
            this.panelExpense.TabIndex = 2;
            // 
            // lblExpenseAmount
            // 
            this.lblExpenseAmount.Font = new System.Drawing.Font("Century Gothic", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExpenseAmount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.lblExpenseAmount.Location = new System.Drawing.Point(0, 50);
            this.lblExpenseAmount.Name = "lblExpenseAmount";
            this.lblExpenseAmount.Size = new System.Drawing.Size(200, 35);
            this.lblExpenseAmount.TabIndex = 1;
            this.lblExpenseAmount.Text = "0 ₫";
            this.lblExpenseAmount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblExpenseTitle
            // 
            this.lblExpenseTitle.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExpenseTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(140)))), ((int)(((byte)(141)))));
            this.lblExpenseTitle.Location = new System.Drawing.Point(0, 15);
            this.lblExpenseTitle.Name = "lblExpenseTitle";
            this.lblExpenseTitle.Size = new System.Drawing.Size(200, 20);
            this.lblExpenseTitle.TabIndex = 0;
            this.lblExpenseTitle.Text = "💸 CHI TIÊU";
            this.lblExpenseTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelChart1
            // 
            this.panelChart1.BackColor = System.Drawing.Color.White;
            this.panelChart1.Controls.Add(this.lblChart1Placeholder);
            this.panelChart1.Location = new System.Drawing.Point(20, 140);
            this.panelChart1.Name = "panelChart1";
            this.panelChart1.Size = new System.Drawing.Size(420, 300);
            this.panelChart1.TabIndex = 3;
            // 
            // lblChart1Placeholder
            // 
            this.lblChart1Placeholder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblChart1Placeholder.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChart1Placeholder.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(195)))), ((int)(((byte)(199)))));
            this.lblChart1Placeholder.Location = new System.Drawing.Point(0, 0);
            this.lblChart1Placeholder.Name = "lblChart1Placeholder";
            this.lblChart1Placeholder.Size = new System.Drawing.Size(420, 300);
            this.lblChart1Placeholder.TabIndex = 0;
            this.lblChart1Placeholder.Text = "📊 Biểu đồ phân loại chi tiêu";
            this.lblChart1Placeholder.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelChart2
            // 
            this.panelChart2.BackColor = System.Drawing.Color.White;
            this.panelChart2.Controls.Add(this.lblChart2Placeholder);
            this.panelChart2.Location = new System.Drawing.Point(460, 140);
            this.panelChart2.Name = "panelChart2";
            this.panelChart2.Size = new System.Drawing.Size(420, 300);
            this.panelChart2.TabIndex = 4;
            // 
            // lblChart2Placeholder
            // 
            this.lblChart2Placeholder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblChart2Placeholder.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChart2Placeholder.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(195)))), ((int)(((byte)(199)))));
            this.lblChart2Placeholder.Location = new System.Drawing.Point(0, 0);
            this.lblChart2Placeholder.Name = "lblChart2Placeholder";
            this.lblChart2Placeholder.Size = new System.Drawing.Size(420, 300);
            this.lblChart2Placeholder.TabIndex = 0;
            this.lblChart2Placeholder.Text = "📈 Biểu đồ xu hướng chi tiêu";
            this.lblChart2Placeholder.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UC_Overview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(244)))), ((int)(((byte)(254)))));
            this.Controls.Add(this.panelChart2);
            this.Controls.Add(this.panelChart1);
            this.Controls.Add(this.panelExpense);
            this.Controls.Add(this.panelIncome);
            this.Controls.Add(this.panelBalance);
            this.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "UC_Overview";
            this.Size = new System.Drawing.Size(900, 460);
            this.panelBalance.ResumeLayout(false);
            this.panelIncome.ResumeLayout(false);
            this.panelExpense.ResumeLayout(false);
            this.panelChart1.ResumeLayout(false);
            this.panelChart2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelBalance;
        private System.Windows.Forms.Label lblBalanceTitle;
        private System.Windows.Forms.Label lblBalanceAmount;
        private System.Windows.Forms.Panel panelIncome;
        private System.Windows.Forms.Label lblIncomeAmount;
        private System.Windows.Forms.Label lblIncomeTitle;
        private System.Windows.Forms.Panel panelExpense;
        private System.Windows.Forms.Label lblExpenseAmount;
        private System.Windows.Forms.Label lblExpenseTitle;
        private System.Windows.Forms.Panel panelChart1;
        private System.Windows.Forms.Label lblChart1Placeholder;
        private System.Windows.Forms.Panel panelChart2;
        private System.Windows.Forms.Label lblChart2Placeholder;
    }
}
