using System;
using System.CodeDom;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using SmartEx3.Services;
using SmartEx3.Services.AI;

namespace SmartEx3.UserControls
{
    public partial class UC_AIAssistant : UserControl
    {
        private ServiceManager _serviceManager;
        private int _currentUserId;
        private bool _isProcessing = false;

        public UC_AIAssistant()
        {
            InitializeComponent();
            InitializeServices();
            InitializeDefaultValues();
            AttachEventHandlers();
        }

        private void InitializeServices()
        {
            _serviceManager = new ServiceManager();
        }

        private void InitializeDefaultValues()
        {
            // Set default analysis period to 3 months
            cmbAnalysisPeriod.SelectedIndex = 1; // "3 tháng gần đây"
        }

        private void AttachEventHandlers()
        {
            btnAnalyzeSpending.Click += BtnAnalyzeSpending_Click;
            btnGetSuggestions.Click += BtnGetSuggestions_Click;
            btnPredict.Click += BtnPredict_Click;
            btnGetAdvice.Click += BtnGetAdvice_Click;
            btnEvaluateHealth.Click += BtnEvaluateHealth_Click;
        }

        public void Initialize(ServiceManager serviceManager, int userId)
        {
            _serviceManager = serviceManager ?? throw new ArgumentNullException(nameof(serviceManager));
            _currentUserId = userId;
        }

        #region Phân tích chi tiêu

        private async void BtnAnalyzeSpending_Click(object sender, EventArgs e)
        {
            if (_isProcessing) return;

            try
            {
                _isProcessing = true;
                SetButtonEnabled(btnAnalyzeSpending, false, "⏳ Đang phân tích...");
                rtbSpendingAnalysis.Text = "🔄 Đang phân tích dữ liệu chi tiêu của bạn...\nVui lòng đợi trong giây lát...";

                // Get selected period
                int months = GetSelectedMonthsPeriod();
                string periodText = GetPeriodDisplayText(months);

                var result = await _serviceManager.GeminiAIService.AnalyzeSpendingHabitsAsync(_currentUserId, months);
                
                rtbSpendingAnalysis.Text = "";
                AppendTextWithColor(rtbSpendingAnalysis, $"📊 KẾT QUẢ PHÂN TÍCH THÓI QUEN CHI TIÊU ({periodText})\n\n", Color.FromArgb(52, 152, 219), true);
                AppendTextWithColor(rtbSpendingAnalysis, result, Color.FromArgb(52, 73, 94), false);
            }
            catch (Exception ex)
            {
                rtbSpendingAnalysis.Text = $"❌ Lỗi: {ex.Message}";
            }
            finally
            {
                SetButtonEnabled(btnAnalyzeSpending, true, "🔍 Phân tích thói quen chi tiêu");
                _isProcessing = false;
            }
        }

        private int GetSelectedMonthsPeriod()
        {
            switch (cmbAnalysisPeriod.SelectedIndex)
            {
                case 0: return 1;   // 1 tháng
                case 1: return 3;   // 3 tháng
                case 2: return 6;   // 6 tháng
                case 3: return 12;  // 1 năm
                case 4: return 999; // Toàn bộ (dùng số lớn)
                default: return 3;  // Mặc định 3 tháng
            }
        }

        private string GetPeriodDisplayText(int months)
        {
            if (months >= 999) return "Toàn bộ lịch sử";
            if (months == 12) return "1 năm gần đây";
            if (months == 6) return "6 tháng gần đây";
            if (months == 3) return "3 tháng gần đây";
            if (months == 1) return "1 tháng gần đây";
            return $"{months} tháng gần đây";
        }

        #endregion

        #region Gợi ý tiết kiệm

        private async void BtnGetSuggestions_Click(object sender, EventArgs e)
        {
            if (_isProcessing) return;

            try
            {
                _isProcessing = true;
                SetButtonEnabled(btnGetSuggestions, false, "⏳ Đang tạo gợi ý...");
                rtbSavingsSuggestions.Text = "🔄 Đang phân tích và tạo gợi ý tiết kiệm...\nVui lòng đợi trong giây lát...";

                var suggestions = await _serviceManager.GeminiAIService.GetSavingsSuggestionsAsync(_currentUserId);
                
                rtbSavingsSuggestions.Text = "";
                AppendTextWithColor(rtbSavingsSuggestions, "💡 GỢI Ý TIẾT KIỆM THÔNG MINH\n\n", Color.FromArgb(46, 204, 113), true);
                
                if (suggestions != null && suggestions.Count > 0)
                {
                    for (int i = 0; i < suggestions.Count; i++)
                    {
                        AppendTextWithColor(rtbSavingsSuggestions, $"{i + 1}. ", Color.FromArgb(52, 152, 219), true);
                        AppendTextWithColor(rtbSavingsSuggestions, $"{suggestions[i]}\n\n", Color.FromArgb(52, 73, 94), false);
                    }
                }
                else
                {
                    AppendTextWithColor(rtbSavingsSuggestions, "Chưa có gợi ý phù hợp.", Color.Gray, false);
                }
            }
            catch (Exception ex)
            {
                rtbSavingsSuggestions.Text = $"❌ Lỗi: {ex.Message}";
            }
            finally
            {
                SetButtonEnabled(btnGetSuggestions, true, "💰 Nhận gợi ý tiết kiệm thông minh");
                _isProcessing = false;
            }
        }

        #endregion

        #region Dự đoán xu hướng

        private async void BtnPredict_Click(object sender, EventArgs e)
        {
            if (_isProcessing) return;

            try
            {
                _isProcessing = true;
                SetButtonEnabled(btnPredict, false, "⏳ Đang dự đoán...");
                rtbPrediction.Text = "🔄 Đang phân tích dữ liệu và dự đoán xu hướng...\nVui lòng đợi trong giây lát...";

                var result = await _serviceManager.GeminiAIService.PredictSpendingTrendAsync(_currentUserId, 1);
                
                rtbPrediction.Text = "";
                AppendTextWithColor(rtbPrediction, "📈 DỰ ĐOÁN XU HƯỚNG CHI TIÊU\n\n", Color.FromArgb(155, 89, 182), true);
                AppendTextWithColor(rtbPrediction, result, Color.FromArgb(52, 73, 94), false);
            }
            catch (Exception ex)
            {
                rtbPrediction.Text = $"❌ Lỗi: {ex.Message}";
            }
            finally
            {
                SetButtonEnabled(btnPredict, true, "🔮 Dự đoán xu hướng chi tiêu tháng tới");
                _isProcessing = false;
            }
        }

        #endregion

        #region Tư vấn mục tiêu

        private async void BtnGetAdvice_Click(object sender, EventArgs e)
        {
            if (_isProcessing) return;

            // Validate input
            if (!decimal.TryParse(txtGoalAmount.Text, out decimal goalAmount) || goalAmount <= 0)
            {
                MessageBox.Show("Vui lòng nhập số tiền mục tiêu hợp lệ!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtGoalAmount.Focus();
                return;
            }


            if(!string.IsNullOrEmpty(txtThuNhap.Text))
            {
               var currentUser = _serviceManager.UserService.GetUserById(_currentUserId);
                currentUser.Income = decimal.Parse(txtThuNhap.Text);
                _serviceManager.UserService.UpdateUser(currentUser);
            }

            int targetMonths = (int)numTargetMonths.Value;

            try
            {
                _isProcessing = true;
                SetButtonEnabled(btnGetAdvice, false, "⏳ Đang tư vấn...");
                rtbGoalAdvice.Text = "🔄 Đang phân tích và tạo lộ trình tài chính...\nVui lòng đợi trong giây lát...";
               

                var result = await _serviceManager.GeminiAIService.GetFinancialGoalAdviceAsync(_currentUserId, goalAmount, targetMonths);
                
                rtbGoalAdvice.Text = "";
                AppendTextWithColor(rtbGoalAdvice, "🎯 TƯ VẤN ĐẠT MỤC TIÊU TÀI CHÍNH\n\n", Color.FromArgb(241, 196, 15), true);
                AppendTextWithColor(rtbGoalAdvice, $"Mục tiêu: {goalAmount:N0} ₫ trong {targetMonths} tháng\n\n", Color.FromArgb(52, 152, 219), true);
                AppendTextWithColor(rtbGoalAdvice, result, Color.FromArgb(52, 73, 94), false);
            }
            catch (Exception ex)
            {
                rtbGoalAdvice.Text = $"❌ Lỗi: {ex.Message}";
            }
            finally
            {
                SetButtonEnabled(btnGetAdvice, true, "🎯 Nhận tư vấn cách đạt mục tiêu");
                _isProcessing = false;
            }
        }

        #endregion

        #region Đánh giá sức khỏe tài chính

        private async void BtnEvaluateHealth_Click(object sender, EventArgs e)
        {
            if (_isProcessing) return;

            try
            {
                _isProcessing = true;
                SetButtonEnabled(btnEvaluateHealth, false, "⏳ Đang đánh giá...");
                rtbHealthDetails.Text = "🔄 Đang đánh giá sức khỏe tài chính...\nVui lòng đợi trong giây lát...";
                lblScore.Text = "--/100";
                lblRating.Text = "Đang đánh giá...";

                var result = await _serviceManager.GeminiAIService.EvaluateFinancialHealthAsync(_currentUserId);
                
                // Update score display
                lblScore.Text = $"{result.Score}/100";
                lblScore.ForeColor = GetScoreColor(result.Score);
                lblRating.Text = result.Rating;
                lblRating.ForeColor = GetScoreColor(result.Score);

                // Update details
                rtbHealthDetails.Text = "";
                AppendTextWithColor(rtbHealthDetails, "📋 CHI TIẾT ĐÁNH GIÁ\n\n", Color.FromArgb(52, 152, 219), true);
                
                if (!string.IsNullOrEmpty(result.Summary))
                {
                    AppendTextWithColor(rtbHealthDetails, "📊 Tóm tắt:\n", Color.FromArgb(52, 152, 219), true);
                    AppendTextWithColor(rtbHealthDetails, $"{result.Summary}\n\n", Color.FromArgb(52, 73, 94), false);
                }

                if (result.Strengths != null && result.Strengths.Count > 0)
                {
                    AppendTextWithColor(rtbHealthDetails, "✅ Điểm mạnh:\n", Color.FromArgb(46, 204, 113), true);
                    foreach (var strength in result.Strengths)
                    {
                        AppendTextWithColor(rtbHealthDetails, $"• {strength}\n", Color.FromArgb(39, 174, 96), false);
                    }
                    rtbHealthDetails.AppendText("\n");
                }

                if (result.Weaknesses != null && result.Weaknesses.Count > 0)
                {
                    AppendTextWithColor(rtbHealthDetails, "⚠️ Điểm yếu:\n", Color.FromArgb(231, 76, 60), true);
                    foreach (var weakness in result.Weaknesses)
                    {
                        AppendTextWithColor(rtbHealthDetails, $"• {weakness}\n", Color.FromArgb(192, 57, 43), false);
                    }
                    rtbHealthDetails.AppendText("\n");
                }

                if (result.Recommendations != null && result.Recommendations.Count > 0)
                {
                    AppendTextWithColor(rtbHealthDetails, "💡 Khuyến nghị:\n", Color.FromArgb(52, 152, 219), true);
                    foreach (var recommendation in result.Recommendations)
                    {
                        AppendTextWithColor(rtbHealthDetails, $"• {recommendation}\n", Color.FromArgb(41, 128, 185), false);
                    }
                }
            }
            catch (Exception ex)
            {
                rtbHealthDetails.Text = $"❌ Lỗi: {ex.Message}";
                lblScore.Text = "ERROR";
                lblRating.Text = "Lỗi đánh giá";
            }
            finally
            {
                SetButtonEnabled(btnEvaluateHealth, true, "❤️ Đánh giá sức khỏe tài chính");
                _isProcessing = false;
            }
        }

        private Color GetScoreColor(int score)
        {
            if (score >= 80) return Color.FromArgb(46, 204, 113); // Green
            if (score >= 60) return Color.FromArgb(52, 152, 219); // Blue
            if (score >= 40) return Color.FromArgb(241, 196, 15); // Yellow
            return Color.FromArgb(231, 76, 60); // Red
        }

        #endregion

        #region Helper Methods

        private void AppendTextWithColor(RichTextBox rtb, string text, Color color, bool bold)
        {
            int start = rtb.TextLength;
            rtb.AppendText(text);
            int end = rtb.TextLength;

            rtb.Select(start, end - start);
            rtb.SelectionColor = color;
            if (bold)
            {
                rtb.SelectionFont = new Font(rtb.Font, FontStyle.Bold);
            }
            rtb.Select(end, 0);
            rtb.SelectionColor = rtb.ForeColor;
        }

        private void SetButtonEnabled(Button btn, bool enabled, string text)
        {
            btn.Enabled = enabled;
            btn.Text = text;
            btn.Cursor = enabled ? Cursors.Hand : Cursors.WaitCursor;
        }

        #endregion

        private void btnGetAdvice_Click_1(object sender, EventArgs e)
        {

        }

        private void lblTargetMonths_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
