using System;
using SmartEx3.Models;
using SmartEx3.Services.AI;

namespace SmartEx3.Services
{
    public class ServiceManager : IDisposable
    {
        #region Private Fields
        
        // Database context ?? truy c?p d? li?u
        private readonly Model1 _context;
        
        // Lazy initialization c?a các service ?? t?i ?u performance
        private readonly Lazy<IUserService> _userService;
        private readonly Lazy<ITransactionService> _transactionService;
        private readonly Lazy<ICategoryService> _categoryService;
        private readonly Lazy<IGeminiAIService> _geminiAIService;
        
        #endregion

        #region Constructor
        
        public ServiceManager()
        {
            // T?o database context
            _context = new Model1();
            
            // Kh?i t?o lazy instances - service ch? ???c t?o khi ???c s? d?ng l?n ??u
            _userService = new Lazy<IUserService>(() => new UserService(_context));
            _transactionService = new Lazy<ITransactionService>(() => new TransactionService(_context));
            _categoryService = new Lazy<ICategoryService>(() => new CategoryService(_context));
            _geminiAIService = new Lazy<IGeminiAIService>(() => new GeminiAIService(this));
        }
        
        #endregion

        #region Public Properties
        
        public IUserService UserService => _userService.Value;
        public ITransactionService TransactionService => _transactionService.Value;
        public ICategoryService CategoryService => _categoryService.Value;
        public IGeminiAIService GeminiAIService => _geminiAIService.Value;
        
        #endregion

        #region IDisposable Implementation
        
        public void Dispose()
        {
            // Dispose UserService n?u ?ã ???c kh?i t?o
            if (_userService.IsValueCreated && _userService.Value is IDisposable userDisposable)
                userDisposable.Dispose();
            
            // Dispose TransactionService n?u ?ã ???c kh?i t?o
            if (_transactionService.IsValueCreated && _transactionService.Value is IDisposable transactionDisposable)
                transactionDisposable.Dispose();
            
            // Dispose CategoryService n?u ?ã ???c kh?i t?o
            if (_categoryService.IsValueCreated && _categoryService.Value is IDisposable categoryDisposable)
                categoryDisposable.Dispose();

            // Dispose GeminiAIService n?u ?ã ???c kh?i t?o
            if (_geminiAIService.IsValueCreated && _geminiAIService.Value is IDisposable geminiDisposable)
                geminiDisposable.Dispose();

            // Dispose database context
            _context?.Dispose();
        }
        
        #endregion
    }
}