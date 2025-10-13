using System;
using System.Collections.Generic;
using System.Linq;
using SmartEx3.Models;

namespace SmartEx3.Services
{
    public interface ICategoryService
    {
        // Create
        Category CreateCategory(Category category);
        
        // Read
        Category GetCategoryById(int categoryId);
        Category GetCategoryByName(string name);
        IEnumerable<Category> GetAllCategories();
        
        // Update
        Category UpdateCategory(Category category);
        
        // Delete
        bool DeleteCategory(int categoryId);
        
        // Additional methods
        bool CategoryExists(string name);
        IEnumerable<Category> SearchCategories(string searchTerm);
        int GetTransactionCountByCategory(int categoryId);
    }
}