using System;
using System.Collections.Generic;
using System.Linq;
using SmartEx3.Models;

namespace SmartEx3.Services
{
    public interface ITransactionService
    {
        // Create
        Transaction CreateTransaction(Transaction transaction);
        
        // Read
        Transaction GetTransactionById(int transactionId);
        IEnumerable<Transaction> GetAllTransactions();
        IEnumerable<Transaction> GetTransactionsByUserId(int userId);
        IEnumerable<Transaction> GetTransactionsByCategory(string category);
        IEnumerable<Transaction> GetTransactionsByDateRange(DateTime startDate, DateTime endDate);
        
        // Update
        Transaction UpdateTransaction(Transaction transaction);
        
        // Delete
        bool DeleteTransaction(int transactionId);
        bool DeleteTransactionsByUserId(int userId);
        
        // Additional methods
        decimal GetTotalAmountByUserId(int userId);
        decimal GetTotalAmountByCategory(int userId, string category);
        decimal GetTotalAmountByDateRange(int userId, DateTime startDate, DateTime endDate);
        IEnumerable<Transaction> SearchTransactions(int userId, string searchTerm);
        Dictionary<string, decimal> GetCategorySummary(int userId);
        Dictionary<string, decimal> GetCategorySummaryByDateRange(int userId , DateTime startDate  , DateTime endDate);

        Dictionary<DateTime, decimal> GetDailySummary(int userId, DateTime startDate, DateTime endDate);
    }
}