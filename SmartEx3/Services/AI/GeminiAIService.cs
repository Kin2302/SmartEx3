using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SmartEx3.Models;

namespace SmartEx3.Services.AI
{
    /// <summary>
    /// Service tích hợp với Gemini AI API
    /// </summary>
    public class GeminiAIService : IGeminiAIService
    {
        private readonly string _apiKey;
        private readonly HttpClient _httpClient;
        private readonly ServiceManager _serviceManager;
        private const string GEMINI_API_URL = "https://generativelanguage.googleapis.com/v1beta/models/gemini-2.0-flash-exp:generateContent";

        public GeminiAIService(ServiceManager serviceManager, string apiKey = null)
        {
            _serviceManager = serviceManager ?? throw new ArgumentNullException(nameof(serviceManager));
            _apiKey = apiKey ?? "";
            _httpClient = new HttpClient
            {
                Timeout = TimeSpan.FromSeconds(30)
            };
        }

        #region Phân tích thói quen chi tiêu

        public async Task<string> AnalyzeSpendingHabitsAsync(int userId, int months = 3)
        {
            try
            {
                var user = _serviceManager.UserService.GetUserById(userId);
                if (user == null)
                    return "❌ Không tìm thấy thông tin người dùng.";

                // Lấy dữ liệu giao dịch
                DateTime startDate;
                string periodText;
                
                if (months >= 999) // Toàn bộ lịch sử
                {
                    // Lấy giao dịch đầu tiên để xác định startDate
                    var firstTransaction = _serviceManager.TransactionService
                        .GetTransactionsByUserId(userId)
                        .OrderBy(t => t.Date)
                        .FirstOrDefault();
                    
                    startDate = firstTransaction?.Date ?? DateTime.Now.AddMonths(-3);
                    periodText = "toàn bộ lịch sử";
                }
                else
                {
                    startDate = DateTime.Now.AddMonths(-months);
                    periodText = months == 12 ? "1 năm" : 
                                months == 6 ? "6 tháng" : 
                                months == 1 ? "1 tháng" : 
                                $"{months} tháng";
                }

                var transactions = _serviceManager.TransactionService
                    .GetTransactionsByDateRange(startDate, DateTime.Now)
                    .Where(t => t.UserId == userId)
                    .ToList();

                if (!transactions.Any())
                    return $"📊 Chưa có đủ dữ liệu giao dịch trong {periodText} gần đây để phân tích.";

                // Tạo prompt cho Gemini
                string prompt = BuildSpendingHabitsPrompt(user, transactions, periodText);

                // Gọi Gemini API
                var response = await CallGeminiAPIAsync(prompt);
                return response;
            }
            catch (Exception ex)
            {
                return $"❌ Lỗi khi phân tích: {ex.Message}";
            }
        }

        private string BuildSpendingHabitsPrompt(User user, List<Transaction> transactions, string periodText)
        {
            var totalIncome = transactions.Where(t => t.Amount > 0).Sum(t => t.Amount);
            var totalExpense = Math.Abs(transactions.Where(t => t.Amount < 0).Sum(t => t.Amount));
            var categorySummary = transactions
                .Where(t => t.Amount < 0 && !string.IsNullOrEmpty(t.Category))
                .GroupBy(t => t.Category)
                .Select(g => new { Category = g.Key, Total = Math.Abs(g.Sum(t => t.Amount)) })
                .OrderByDescending(x => x.Total)
                .Take(10)
                .ToList();

            // Tính số ngày thực tế
            var firstDate = transactions.Min(t => t.Date);
            var lastDate = transactions.Max(t => t.Date);
            var actualDays = (lastDate - firstDate).Days + 1;

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Bạn là chuyên gia tài chính cá nhân. Hãy phân tích thói quen chi tiêu của người dùng '{user.Name}' dựa trên dữ liệu sau:");
            sb.AppendLine();
            sb.AppendLine($"📊 TỔNG QUAN {periodText.ToUpper()}:");
            sb.AppendLine($"- Khoảng thời gian: {firstDate:dd/MM/yyyy} - {lastDate:dd/MM/yyyy} ({actualDays} ngày)");
            sb.AppendLine($"- Tổng thu nhập: {totalIncome:N0} ₫");
            sb.AppendLine($"- Tổng chi tiêu: {totalExpense:N0} ₫");
            sb.AppendLine($"- Số dư: {(totalIncome - totalExpense):N0} ₫");
            sb.AppendLine($"- Thu nhập hàng tháng (khai báo): {(user.Income.HasValue ? user.Income.Value.ToString("N0") + " ₫" : "Chưa có")}" );
            sb.AppendLine($"- Mục tiêu tiết kiệm: {(user.Goal.HasValue ? user.Goal.Value.ToString("N0") + " ₫" : "Chưa có")}" );
            sb.AppendLine();
            sb.AppendLine("💳 CHI TIÊU THEO DANH MỤC:");
            foreach (var item in categorySummary)
            {
                decimal percent = (item.Total / totalExpense) * 100;
                sb.AppendLine($"- {item.Category}: {item.Total:N0} ₫ ({percent:F1}%)");
            }
            sb.AppendLine();
            sb.AppendLine("YÊU CẦU:");
            sb.AppendLine("1. Phân tích xu hướng chi tiêu (tăng/giảm, ổn định/không ổn định)");
            sb.AppendLine("2. Nhận xét về các danh mục chi tiêu chính");
            sb.AppendLine("3. Đánh giá tỷ lệ chi tiêu so với thu nhập");
            sb.AppendLine("4. Chỉ ra các điểm mạnh và điểm yếu trong cách quản lý tài chính");
            sb.AppendLine("5. So sánh với mục tiêu tiết kiệm (nếu có)");
            sb.AppendLine();
            sb.AppendLine("Hãy trả lời bằng tiếng Việt, súc tích, dễ hiểu và có emoji phù hợp.");

            return sb.ToString();
        }

        #endregion

        #region Gợi ý tiết kiệm

        public async Task<List<string>> GetSavingsSuggestionsAsync(int userId)
        {
            try
            {
                var user = _serviceManager.UserService.GetUserById(userId);
                if (user == null)
                    return new List<string> { "❌ Không tìm thấy thông tin người dùng." };

                var transactions = _serviceManager.TransactionService
                    .GetTransactionsByDateRange(DateTime.Now.AddMonths(-1), DateTime.Now)
                    .Where(t => t.UserId == userId)
                    .ToList();

                if (!transactions.Any())
                    return new List<string> { "📊 Chưa có đủ dữ liệu để đưa ra gợi ý tiết kiệm." };

                string prompt = BuildSavingsSuggestionsPrompt(user, transactions);
                var response = await CallGeminiAPIAsync(prompt);

                // Parse response thành list
                var suggestions = response
                    .Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries)
                    .Where(line => line.Trim().StartsWith("-") || line.Trim().StartsWith("•") || 
                                   line.Trim().StartsWith("✓") || char.IsDigit(line.Trim().FirstOrDefault()))
                    .Select(line => line.Trim().TrimStart('-', '•', '✓', ' ').Trim())
                    .Where(line => !string.IsNullOrWhiteSpace(line))
                    .Take(10)
                    .ToList();

                return suggestions.Any() ? suggestions : new List<string> { response };
            }
            catch (Exception ex)
            {
                return new List<string> { $"❌ Lỗi khi tạo gợi ý: {ex.Message}" };
            }
        }

        private string BuildSavingsSuggestionsPrompt(User user, List<Transaction> transactions)
        {
            var totalExpense = Math.Abs(transactions.Where(t => t.Amount < 0).Sum(t => t.Amount));
            var categorySummary = transactions
                .Where(t => t.Amount < 0 && !string.IsNullOrEmpty(t.Category))
                .GroupBy(t => t.Category)
                .Select(g => new { Category = g.Key, Total = Math.Abs(g.Sum(t => t.Amount)) })
                .OrderByDescending(x => x.Total)
                .ToList();

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Bạn là chuyên gia tư vấn tiết kiệm. Hãy đưa ra 8-10 gợi ý THỰC TẾ và CỤ THỂ để tiết kiệm chi phí dựa trên:");
            sb.AppendLine();
            sb.AppendLine("CHI TIÊU THÁNG QUA:");
            foreach (var item in categorySummary)
            {
                sb.AppendLine($"- {item.Category}: {item.Total:N0} ₫");
            }
            sb.AppendLine();
            sb.AppendLine($"Thu nhập: {(user.Income.HasValue ? user.Income.Value.ToString("N0") + " ₫" : "Chưa có")}");
            sb.AppendLine();
            sb.AppendLine("YÊU CẦU:");
            sb.AppendLine("- Mỗi gợi ý phải CỤ THỂ, DỄ THỰC HIỆN");
            sb.AppendLine("- Ước tính số tiền có thể tiết kiệm");
            sb.AppendLine("- Tập trung vào các danh mục chi tiêu NHIỀU NHẤT");
            sb.AppendLine("- Format: Mỗi gợi ý 1 dòng, bắt đầu bằng dấu '-'");
            sb.AppendLine("- Viết bằng tiếng Việt, có emoji");

            return sb.ToString();
        }

        #endregion

        #region Dự đoán xu hướng chi tiêu

        public async Task<string> PredictSpendingTrendAsync(int userId, int forecastMonths = 1)
        {
            try
            {
                var transactions = _serviceManager.TransactionService
                    .GetTransactionsByDateRange(DateTime.Now.AddMonths(-6), DateTime.Now)
                    .Where(t => t.UserId == userId)
                    .ToList();

                if (!transactions.Any())
                    return "📊 Chưa có đủ dữ liệu lịch sử để dự đoán xu hướng.";

                string prompt = BuildPredictionPrompt(transactions, forecastMonths);
                var response = await CallGeminiAPIAsync(prompt);

                return response;
            }
            catch (Exception ex)
            {
                return $"❌ Lỗi khi dự đoán: {ex.Message}";
            }
        }

        private string BuildPredictionPrompt(List<Transaction> transactions, int forecastMonths)
        {
            var monthlyData = transactions
                .GroupBy(t => new { t.Date.Year, t.Date.Month })
                .OrderBy(g => g.Key.Year).ThenBy(g => g.Key.Month)
                .Select(g => new
                {
                    Month = $"{g.Key.Month:D2}/{g.Key.Year}",
                    Income = g.Where(t => t.Amount > 0).Sum(t => t.Amount),
                    Expense = Math.Abs(g.Where(t => t.Amount < 0).Sum(t => t.Amount))
                })
                .ToList();

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Bạn là chuyên gia phân tích xu hướng tài chính. Hãy dự đoán xu hướng chi tiêu dựa trên dữ liệu:");
            sb.AppendLine();
            sb.AppendLine("📊 DỮ LIỆU 6 THÁNG QUA:");
            foreach (var month in monthlyData)
            {
                sb.AppendLine($"- {month.Month}: Thu {month.Income:N0} ₫ | Chi {month.Expense:N0} ₫");
            }
            sb.AppendLine();
            sb.AppendLine($"YÊU CẦU: Dự đoán xu hướng cho {forecastMonths} tháng tới:");
            sb.AppendLine("1. Dự đoán mức chi tiêu trung bình/tháng");
            sb.AppendLine("2. Xu hướng tăng/giảm");
            sb.AppendLine("3. Các yếu tố ảnh hưởng");
            sb.AppendLine("4. Khuyến nghị để tối ưu hóa");
            sb.AppendLine();
            sb.AppendLine("Trả lời bằng tiếng Việt, có số liệu cụ thể và emoji.");

            return sb.ToString();
        }

        #endregion

        #region Tư vấn mục tiêu tài chính

        public async Task<string> GetFinancialGoalAdviceAsync(int userId, decimal goalAmount, int targetMonths)
        {
            try
            {
                var user = _serviceManager.UserService.GetUserById(userId);
                if (user == null)
                    return "❌ Không tìm thấy thông tin người dùng.";

                var transactions = _serviceManager.TransactionService
                    .GetTransactionsByDateRange(DateTime.Now.AddMonths(-3), DateTime.Now)
                    .Where(t => t.UserId == userId)
                    .ToList();

                string prompt = BuildGoalAdvicePrompt(user, transactions, goalAmount, targetMonths);
                var response = await CallGeminiAPIAsync(prompt);

                return response;
            }
            catch (Exception ex)
            {
                return $"❌ Lỗi khi tư vấn: {ex.Message}";
            }
        }

        private string BuildGoalAdvicePrompt(User user, List<Transaction> transactions, decimal goalAmount, int targetMonths)
        {
            var avgMonthlyIncome = user.Income ?? 0;
            var avgMonthlyExpense = transactions.Any() 
                ? Math.Abs(transactions.Where(t => t.Amount < 0).Sum(t => t.Amount)) / 3 
                : 0;
            var avgMonthlySavings = avgMonthlyIncome - avgMonthlyExpense;
            var requiredMonthlySavings = goalAmount / targetMonths;

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Bạn là chuyên gia hoạch định tài chính. Hãy tư vấn chi tiết về cách đạt mục tiêu:");
            sb.AppendLine();
            sb.AppendLine("🎯 MỤC TIÊU:");
            sb.AppendLine($"- Số tiền cần tiết kiệm: {goalAmount:N0} ₫");
            sb.AppendLine($"- Thời gian: {targetMonths} tháng");
            sb.AppendLine($"- Cần tiết kiệm mỗi tháng: {requiredMonthlySavings:N0} ₫");
            sb.AppendLine();
            sb.AppendLine("📊 TÌNH HÌNH HIỆN TẠI:");
            sb.AppendLine($"- Thu nhập trung bình/tháng: {avgMonthlyIncome:N0} ₫");
            sb.AppendLine($"- Chi tiêu trung bình/tháng: {avgMonthlyExpense:N0} ₫");
            sb.AppendLine($"- Tiết kiệm hiện tại/tháng: {avgMonthlySavings:N0} ₫");
            sb.AppendLine();
            sb.AppendLine("YÊU CẦU:");
            sb.AppendLine("1. Đánh giá tính khả thi của mục tiêu");
            sb.AppendLine("2. Lộ trình chi tiết để đạt mục tiêu");
            sb.AppendLine("3. Các hạng mục cần cắt giảm (cụ thể)");
            sb.AppendLine("4. Gợi ý tăng thu nhập (nếu cần)");
            sb.AppendLine("5. Lời khuyên và động viên");
            sb.AppendLine();
            sb.AppendLine("Trả lời bằng tiếng Việt, thực tế và có số liệu.");

            return sb.ToString();
        }

        #endregion

        #region Phân tích tổng quan

        public async Task<string> GetFinancialOverviewAsync(int userId)
        {
            try
            {
                var user = _serviceManager.UserService.GetUserById(userId);
                if (user == null)
                    return "❌ Không tìm thấy thông tin người dùng.";

                var transactions = _serviceManager.TransactionService.GetTransactionsByUserId(userId);
                
                string prompt = BuildOverviewPrompt(user, transactions.ToList());
                var response = await CallGeminiAPIAsync(prompt);

                return response;
            }
            catch (Exception ex)
            {
                return $"❌ Lỗi khi phân tích: {ex.Message}";
            }
        }

        private string BuildOverviewPrompt(User user, List<Transaction> transactions)
        {
            var totalIncome = transactions.Where(t => t.Amount > 0).Sum(t => t.Amount);
            var totalExpense = Math.Abs(transactions.Where(t => t.Amount < 0).Sum(t => t.Amount));
            var balance = totalIncome - totalExpense;

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Bạn là chuyên gia tài chính. Hãy đưa ra bản tổng quan ngắn gọn về tình hình tài chính:");
            sb.AppendLine();
            sb.AppendLine("📊 TỔNG QUAN:");
            sb.AppendLine($"- Tổng thu nhập: {totalIncome:N0} ₫");
            sb.AppendLine($"- Tổng chi tiêu: {totalExpense:N0} ₫");
            sb.AppendLine($"- Số dư: {balance:N0} ₫");
            sb.AppendLine($"- Số giao dịch: {transactions.Count}");
            sb.AppendLine();
            sb.AppendLine("YÊU CẦU: Tóm tắt ngắn gọn (3-4 câu) với nhận xét chính và 1-2 khuyến nghị quan trọng nhất.");

            return sb.ToString();
        }

        #endregion

        #region Đánh giá sức khỏe tài chính

        public async Task<FinancialHealthScore> EvaluateFinancialHealthAsync(int userId)
        {
            try
            {
                var user = _serviceManager.UserService.GetUserById(userId);
                if (user == null)
                {
                    return new FinancialHealthScore
                    {
                        Score = 0,
                        Rating = "Không xác định",
                        Summary = "Không tìm thấy thông tin người dùng.",
                        Strengths = new List<string>(),
                        Weaknesses = new List<string>(),
                        Recommendations = new List<string>()
                    };
                }

                var transactions = _serviceManager.TransactionService
                    .GetTransactionsByDateRange(DateTime.Now.AddMonths(-3), DateTime.Now)
                    .Where(t => t.UserId == userId)
                    .ToList();

                // Tính điểm dựa trên các yếu tố
                int score = CalculateHealthScore(user, transactions);
                string rating = GetRating(score);

                string prompt = BuildHealthEvaluationPrompt(user, transactions, score, rating);
                var response = await CallGeminiAPIAsync(prompt);

                return ParseHealthScore(response, score, rating);
            }
            catch (Exception ex)
            {
                return new FinancialHealthScore
                {
                    Score = 0,
                    Rating = "Lỗi",
                    Summary = $"Lỗi khi đánh giá: {ex.Message}",
                    Strengths = new List<string>(),
                    Weaknesses = new List<string>(),
                    Recommendations = new List<string>()
                };
            }
        }

        private int CalculateHealthScore(User user, List<Transaction> transactions)
        {
            int score = 50; // Điểm cơ bản

            if (!transactions.Any()) return score;

            var totalIncome = transactions.Where(t => t.Amount > 0).Sum(t => t.Amount);
            var totalExpense = Math.Abs(transactions.Where(t => t.Amount < 0).Sum(t => t.Amount));

            // Tỷ lệ tiết kiệm (30 điểm)
            if (totalIncome > 0)
            {
                decimal savingsRate = ((totalIncome - totalExpense) / totalIncome) * 100;
                if (savingsRate >= 30) score += 30;
                else if (savingsRate >= 20) score += 25;
                else if (savingsRate >= 10) score += 15;
                else if (savingsRate >= 0) score += 5;
                else score -= 10; // Chi nhiều hơn thu
            }

            // Có mục tiêu tài chính (10 điểm)
            if (user.Goal.HasValue && user.Goal.Value > 0) score += 10;

            // Có thu nhập ổn định (10 điểm)
            if (user.Income.HasValue && user.Income.Value > 0) score += 10;

            return Math.Min(100, Math.Max(0, score));
        }

        private string GetRating(int score)
        {
            if (score >= 80) return "Xuất sắc";
            if (score >= 60) return "Tốt";
            if (score >= 40) return "Trung bình";
            return "Cần cải thiện";
        }

        private string BuildHealthEvaluationPrompt(User user, List<Transaction> transactions, int score, string rating)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Điểm sức khỏe tài chính: {score}/100 - {rating}");
            sb.AppendLine();
            sb.AppendLine("Hãy phân tích và đưa ra:");
            sb.AppendLine("1. ĐIỂM MẠNH: 2-3 điểm mạnh (mỗi dòng bắt đầu bằng 'Mạnh:')");
            sb.AppendLine("2. ĐIỂM YẾU: 2-3 điểm yếu (mỗi dòng bắt đầu bằng 'Yếu:')");
            sb.AppendLine("3. KHUYẾN NGHỊ: 3-4 khuyến nghị (mỗi dòng bắt đầu bằng 'KN:')");
            sb.AppendLine("4. TÓM TẮT: 1-2 câu tóm tắt (bắt đầu bằng 'Tóm tắt:')");
            sb.AppendLine();
            sb.AppendLine("Format nghiêm ngặt, tiếng Việt, ngắn gọn.");

            return sb.ToString();
        }

        private FinancialHealthScore ParseHealthScore(string response, int score, string rating)
        {
            var result = new FinancialHealthScore
            {
                Score = score,
                Rating = rating,
                Strengths = new List<string>(),
                Weaknesses = new List<string>(),
                Recommendations = new List<string>(),
                Summary = ""
            };

            var lines = response.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            
            foreach (var line in lines)
            {
                var trimmed = line.Trim();
                if (trimmed.StartsWith("Mạnh:", StringComparison.OrdinalIgnoreCase))
                    result.Strengths.Add(trimmed.Substring(5).Trim());
                else if (trimmed.StartsWith("Yếu:", StringComparison.OrdinalIgnoreCase))
                    result.Weaknesses.Add(trimmed.Substring(4).Trim());
                else if (trimmed.StartsWith("KN:", StringComparison.OrdinalIgnoreCase))
                    result.Recommendations.Add(trimmed.Substring(3).Trim());
                else if (trimmed.StartsWith("Tóm tắt:", StringComparison.OrdinalIgnoreCase))
                    result.Summary = trimmed.Substring(8).Trim();
            }

            if (string.IsNullOrEmpty(result.Summary))
                result.Summary = $"Điểm sức khỏe tài chính: {score}/100 - {rating}";

            return result;
        }

        #endregion

        #region Gemini API Call

        private async Task<string> CallGeminiAPIAsync(string prompt)
        {
            try
            {
                var requestBody = new
                {
                    contents = new[]
                    {
                        new
                        {
                            parts = new[]
                            {
                                new { text = prompt }
                            }
                        }
                    },
                    generationConfig = new
                    {
                        temperature = 0.7,
                        maxOutputTokens = 1024,
                        topP = 0.8,
                        topK = 10
                    }
                };

                var json = JsonConvert.SerializeObject(requestBody);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync($"{GEMINI_API_URL}?key={_apiKey}", content);
                var responseText = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    return $"❌ Lỗi API: {response.StatusCode} - {responseText}";
                }

                dynamic result = JsonConvert.DeserializeObject(responseText);
                string generatedText = result?.candidates?[0]?.content?.parts?[0]?.text?.ToString();

                return generatedText ?? "❌ Không nhận được phản hồi từ AI.";
            }
            catch (HttpRequestException ex)
            {
                return $"❌ Lỗi kết nối: {ex.Message}. Vui lòng kiểm tra internet.";
            }
            catch (TaskCanceledException)
            {
                return "⏱️ Yêu cầu quá lâu, vui lòng thử lại.";
            }
            catch (Exception ex)
            {
                return $"❌ Lỗi không xác định: {ex.Message}";
            }
        }

        #endregion

        #region Dispose

        public void Dispose()
        {
            _httpClient?.Dispose();
        }

        #endregion
    }
}
