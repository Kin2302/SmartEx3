using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SmartEx3.Models;

namespace SmartEx3.Services.AI
{
    /// <summary>
    /// Interface for Gemini AI Service
    /// </summary>
    public interface IGeminiAIService : IDisposable
    {
        /// <summary>
        /// Phân tích thói quen chi tiêu của người dùng
        /// </summary>
        /// <param name="userId">User ID</param>
        /// <param name="months">Số tháng để phân tích (mặc định 3 tháng)</param>
        /// <returns>Phân tích chi tiết về thói quen chi tiêu</returns>
        Task<string> AnalyzeSpendingHabitsAsync(int userId, int months = 3);

        /// <summary>
        /// Đưa ra gợi ý tiết kiệm dựa trên dữ liệu chi tiêu
        /// </summary>
        /// <param name="userId">User ID</param>
        /// <returns>Danh sách gợi ý tiết kiệm</returns>
        Task<List<string>> GetSavingsSuggestionsAsync(int userId);

        /// <summary>
        /// Dự đoán xu hướng chi tiêu trong tương lai
        /// </summary>
        /// <param name="userId">User ID</param>
        /// <param name="forecastMonths">Số tháng dự đoán (mặc định 1 tháng)</param>
        /// <returns>Dự đoán xu hướng chi tiêu</returns>
        Task<string> PredictSpendingTrendAsync(int userId, int forecastMonths = 1);

        /// <summary>
        /// Tư vấn về mục tiêu tài chính
        /// </summary>
        /// <param name="userId">User ID</param>
        /// <param name="goalAmount">Số tiền mục tiêu</param>
        /// <param name="targetMonths">Số tháng muốn đạt mục tiêu</param>
        /// <returns>Lời tư vấn chi tiết về cách đạt mục tiêu</returns>
        Task<string> GetFinancialGoalAdviceAsync(int userId, decimal goalAmount, int targetMonths);

        /// <summary>
        /// Phân tích tổng quan tài chính cá nhân
        /// </summary>
        /// <param name="userId">User ID</param>
        /// <returns>Phân tích tổng quan</returns>
        Task<string> GetFinancialOverviewAsync(int userId);

        /// <summary>
        /// Đánh giá mức độ lành mạnh của tài chính
        /// </summary>
        /// <param name="userId">User ID</param>
        /// <returns>Điểm số và nhận xét về sức khỏe tài chính</returns>
        Task<FinancialHealthScore> EvaluateFinancialHealthAsync(int userId);
    }

    /// <summary>
    /// Model cho điểm đánh giá sức khỏe tài chính
    /// </summary>
    public class FinancialHealthScore
    {
        public int Score { get; set; } // 0-100
        public string Rating { get; set; } // "Xuất sắc", "Tốt", "Trung bình", "Cần cải thiện"
        public string Summary { get; set; }
        public List<string> Strengths { get; set; }
        public List<string> Weaknesses { get; set; }
        public List<string> Recommendations { get; set; }
    }
}
