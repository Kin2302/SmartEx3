using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using SmartEx3.Models;

namespace SmartEx3.Services
{
    public class TransactionService : ITransactionService
    {
        #region Private Fields
        
        // Database context để truy cập dữ liệu
        private readonly Model1 _context;
        
        #endregion

        #region Constructors
        
        public TransactionService(Model1 context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public TransactionService() : this(new Model1())
        {
        }
        
        #endregion

        #region Create Operations
        
        public Transaction CreateTransaction(Transaction transaction)
        {
            if (transaction == null)
                throw new ArgumentNullException(nameof(transaction));

            // Kiểm tra user có tồn tại không
            var userExists = _context.Users.Any(u => u.UserId == transaction.UserId);
            if (!userExists)
                throw new InvalidOperationException("User not found");

            // Validate danh mục dựa trên loại giao dịch
            ValidateTransactionCategory(transaction);

            // Đặt thời gian tạo
            transaction.CreatedAt = DateTime.Now;

            // Thêm vào database
            _context.Transactions.Add(transaction);
            _context.SaveChanges();
            return transaction;
        }
        
        #endregion

        #region Read Operations
        
        public Transaction GetTransactionById(int transactionId)
        {
            return _context.Transactions.Include(t => t.User).FirstOrDefault(t => t.TransId == transactionId);
        }

        public IEnumerable<Transaction> GetAllTransactions()
        {
            return _context.Transactions.Include(t => t.User).ToList();
        }

        public IEnumerable<Transaction> GetTransactionsByUserId(int userId)
        {
            return _context.Transactions
                .Where(t => t.UserId == userId)
                .Include(t => t.User)
                .OrderByDescending(t => t.Date)
                .ToList();
        }

        public IEnumerable<Transaction> GetTransactionsByCategory(string category)
        {
            return _context.Transactions
                .Where(t => t.Category != null && t.Category.Equals(category, StringComparison.OrdinalIgnoreCase))
                .Include(t => t.User)
                .OrderByDescending(t => t.Date)
                .ToList();
        }

        public IEnumerable<Transaction> GetTransactionsByDateRange(DateTime startDate, DateTime endDate)
        {
            return _context.Transactions
                .Where(t => t.Date >= startDate && t.Date <= endDate)
                .Include(t => t.User)
                .OrderByDescending(t => t.Date)
                .ToList();
        }
        
        #endregion

        #region Update Operations
        
        public Transaction UpdateTransaction(Transaction transaction)
        {
            if (transaction == null)
                throw new ArgumentNullException(nameof(transaction));

            var existingTransaction = _context.Transactions.Find(transaction.TransId);
            if (existingTransaction == null)
                throw new InvalidOperationException("Transaction not found");

            // Kiểm tra user có tồn tại không nếu UserId thay đổi
            if (existingTransaction.UserId != transaction.UserId)
            {
                var userExists = _context.Users.Any(u => u.UserId == transaction.UserId);
                if (!userExists)
                    throw new InvalidOperationException("User not found");
            }

            // Validate danh mục dựa trên loại giao dịch
            ValidateTransactionCategory(transaction);

            // Cập nhật các thuộc tính
            existingTransaction.UserId = transaction.UserId;
            existingTransaction.Amount = transaction.Amount;
            existingTransaction.Category = transaction.Category;
            existingTransaction.Note = transaction.Note;
            existingTransaction.Date = transaction.Date;

            _context.SaveChanges();
            return existingTransaction;
        }
        
        #endregion

        #region Delete Operations
        
        public bool DeleteTransaction(int transactionId)
        {
            var transaction = _context.Transactions.Find(transactionId);
            if (transaction == null)
                return false;

            _context.Transactions.Remove(transaction);
            _context.SaveChanges();
            return true;
        }

        public bool DeleteTransactionsByUserId(int userId)
        {
            var transactions = _context.Transactions.Where(t => t.UserId == userId).ToList();
            if (!transactions.Any())
                return false;

            _context.Transactions.RemoveRange(transactions);
            _context.SaveChanges();
            return true;
        }
        
        #endregion

        #region Statistics Operations
        
        public decimal GetTotalAmountByUserId(int userId)
        {
            // Xử lý trường hợp không có giao dịch nào bằng cách sử dụng nullable decimal
            return _context.Transactions
                .Where(t => t.UserId == userId)
                .Sum(t => (decimal?)t.Amount) ?? 0;
        }

        public decimal GetTotalAmountByCategory(int userId, string category)
        {
            // Xử lý trường hợp không có kết quả bằng cách sử dụng nullable decimal
            return _context.Transactions
                .Where(t => t.UserId == userId && t.Category != null && t.Category.Equals(category, StringComparison.OrdinalIgnoreCase))
                .Sum(t => (decimal?)t.Amount) ?? 0;
        }

        public decimal GetTotalAmountByDateRange(int userId, DateTime startDate, DateTime endDate)
        {
            // Xử lý trường hợp không có kết quả bằng cách sử dụng nullable decimal
            return _context.Transactions
                .Where(t => t.UserId == userId && t.Date >= startDate && t.Date <= endDate)
                .Sum(t => (decimal?)t.Amount) ?? 0;
        }
        
        #endregion

        #region Search Operations
        
        public IEnumerable<Transaction> SearchTransactions(int userId, string searchTerm)
        {
            if (string.IsNullOrEmpty(searchTerm))
                return GetTransactionsByUserId(userId);

            return _context.Transactions
                .Where(t => t.UserId == userId && 
                           ((t.Category != null && t.Category.Contains(searchTerm)) || 
                            (t.Note != null && t.Note.Contains(searchTerm))))
                .Include(t => t.User)
                .OrderByDescending(t => t.Date)
                .ToList();
        }
        
        #endregion

        #region Summary Operations
        
        public Dictionary<string, decimal> GetCategorySummary(int userId)
        {
            // Lấy các giao dịch đã phân loại, loại trừ thu nhập
            var categorizedTransactions = _context.Transactions
                .Where(t => t.UserId == userId && t.Category != null && t.Category != "Thu nhập")
                .GroupBy(t => t.Category)
                .ToDictionary(g => g.Key, g => g.Sum(t => t.Amount));

            // Thêm tổng thu nhập như một danh mục riêng
            var incomeTotal = _context.Transactions
                .Where(t => t.UserId == userId && t.Amount > 0 && t.Category == "Thu nhập")
                .Sum(t => (decimal?)t.Amount) ?? 0;

            if (incomeTotal > 0)
            {
                categorizedTransactions["Thu nhập"] = incomeTotal;
            }

            return categorizedTransactions;
        }

        public Dictionary<DateTime, decimal> GetDailySummary(int userId, DateTime startDate, DateTime endDate)
        {
            // EF không hỗ trợ .Date trong LINQ to Entities
            // Load tất cả giao dịch trước, sau đó group theo ngày trong memory
            var transactions = _context.Transactions
                .Where(t => t.UserId == userId && t.Date >= startDate && t.Date <= endDate)
                .ToList();

            // Bây giờ group theo ngày trong memory
            return transactions
                .GroupBy(t => t.Date.Date)
                .ToDictionary(g => g.Key, g => g.Sum(t => t.Amount));
        }
        
        #endregion

        #region Validation
        
        private void ValidateTransactionCategory(Transaction transaction)
        {
            // Nếu là chi tiêu (số tiền âm), danh mục là bắt buộc
            if (transaction.Amount < 0 && string.IsNullOrWhiteSpace(transaction.Category))
            {
                throw new InvalidOperationException("Category is required for expense transactions");
            }

            // Nếu là thu nhập (số tiền dương), dùng placeholder thay vì NULL
            if (transaction.Amount > 0)
            {
                transaction.Category = "Thu nhập";
            }
        }
        
        #endregion

        #region IDisposable Implementation
        
        public void Dispose()
        {
            _context?.Dispose();
        }

        public Dictionary<string, decimal> GetCategorySummaryByDateRange(int userId, DateTime startDate, DateTime endDate)
        {
            // Lấy tất cả transactions trong khoảng thời gian (1 query duy nhất)
            var transactions = _context.Transactions
                .Where(t => t.UserId == userId && t.Date >= startDate && t.Date <= endDate)
                .ToList();

            // Group chi tiêu theo category
            var categorizedTransactions = transactions
                .Where(t => t.Category != null && t.Category != "Thu nhập")
                .GroupBy(t => t.Category)
                .ToDictionary(g => g.Key, g => g.Sum(t => t.Amount));

            // Tính tổng thu nhập từ transactions đã lấy
            var incomeTotal = transactions
                .Where(t => t.Amount > 0 && t.Category == "Thu nhập")
                .Sum(t => t.Amount);

            // Thêm thu nhập vào dictionary nếu có
            if (incomeTotal > 0)
            {
                categorizedTransactions["Thu nhập"] = incomeTotal;
            }

            return categorizedTransactions;
        }

        #endregion
    }
}