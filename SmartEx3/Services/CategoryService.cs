using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using SmartEx3.Models;

namespace SmartEx3.Services
{
    public class CategoryService : ICategoryService
    {
        #region Private Fields
        
        // Database context ?? truy c?p d? li?u
        private readonly Model1 _context;
        
        #endregion

        #region Constructors
        
        public CategoryService(Model1 context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public CategoryService() : this(new Model1())
        {
        }
        
        #endregion

        #region Create Operations
        
        public Category CreateCategory(Category category)
        {
            if (category == null)
                throw new ArgumentNullException(nameof(category));

            // Ki?m tra tên danh m?c ?ã t?n t?i ch?a
            if (CategoryExists(category.Name))
                throw new InvalidOperationException("Category name already exists");

            // Thêm vào database
            _context.Categories.Add(category);
            _context.SaveChanges();
            return category;
        }
        
        #endregion

        #region Read Operations
        
        public Category GetCategoryById(int categoryId)
        {
            return _context.Categories.Find(categoryId);
        }

        public Category GetCategoryByName(string name)
        {
            if (string.IsNullOrEmpty(name))
                return null;

            return _context.Categories.FirstOrDefault(c => c.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return _context.Categories.OrderBy(c => c.Name).ToList();
        }
        
        #endregion

        #region Update Operations
        
        public Category UpdateCategory(Category category)
        {
            if (category == null)
                throw new ArgumentNullException(nameof(category));

            var existingCategory = _context.Categories.Find(category.CategoryId);
            if (existingCategory == null)
                throw new InvalidOperationException("Category not found");

            // Ki?m tra n?u tên ?ang thay ??i sang tên ?ã t?n t?i
            if (!existingCategory.Name.Equals(category.Name, StringComparison.OrdinalIgnoreCase) && CategoryExists(category.Name))
                throw new InvalidOperationException("Category name already exists");

            // C?p nh?t tên
            existingCategory.Name = category.Name;
            _context.SaveChanges();
            return existingCategory;
        }
        
        #endregion

        #region Delete Operations
        
        public bool DeleteCategory(int categoryId)
        {
            var category = _context.Categories.Find(categoryId);
            if (category == null)
                return false;

            // Ki?m tra danh m?c có ?ang ???c s? d?ng trong giao d?ch không
            var transactionCount = GetTransactionCountByCategory(categoryId);
            if (transactionCount > 0)
                throw new InvalidOperationException($"Cannot delete category. It is used in {transactionCount} transaction(s).");

            _context.Categories.Remove(category);
            _context.SaveChanges();
            return true;
        }
        
        #endregion

        #region Validation
        
        public bool CategoryExists(string name)
        {
            if (string.IsNullOrEmpty(name))
                return false;

            return _context.Categories.Any(c => c.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }
        
        #endregion

        #region Search Operations
        
        public IEnumerable<Category> SearchCategories(string searchTerm)
        {
            if (string.IsNullOrEmpty(searchTerm))
                return GetAllCategories();

            return _context.Categories
                .Where(c => c.Name.Contains(searchTerm))
                .OrderBy(c => c.Name)
                .ToList();
        }
        
        #endregion

        #region Statistics
        
        public int GetTransactionCountByCategory(int categoryId)
        {
            var category = GetCategoryById(categoryId);
            if (category == null)
                return 0;

            // Lo?i tr? các giao d?ch thu nh?p
            return _context.Transactions.Count(t => 
                t.Category != null && 
                t.Category != "Thu nh?p" && // Lo?i tr? placeholder thu nh?p
                t.Category.Equals(category.Name, StringComparison.OrdinalIgnoreCase)
            );
        }
        
        #endregion

        #region IDisposable Implementation
        
        public void Dispose()
        {
            _context?.Dispose();
        }
        
        #endregion
    }
}