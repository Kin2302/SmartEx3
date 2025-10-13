using System;
using System.Collections.Generic;
using System.Linq;
using SmartEx3.Models;

namespace SmartEx3.Services
{
    public interface IUserService
    {
        // Create
        User CreateUser(User user);
        
        // Read
        User GetUserById(int userId);
        User GetUserByEmail(string email);
        IEnumerable<User> GetAllUsers();
        
        // Update
        User UpdateUser(User user);
        
        // Delete
        bool DeleteUser(int userId);
        
        // Additional methods
        bool ValidateUser(string email, string password);
        bool EmailExists(string email);
        IEnumerable<User> SearchUsers(string searchTerm);
    }
}