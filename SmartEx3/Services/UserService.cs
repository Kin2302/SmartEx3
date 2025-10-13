using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using SmartEx3.Models;

namespace SmartEx3.Services
{
    public class UserService : IUserService
    {
        #region Private Fields
        
        // Database context ?? truy c?p d? li?u
        private readonly Model1 _context;
        
        #endregion

        #region Constructors
        
        public UserService(Model1 context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public UserService() : this(new Model1())
        {
        }
        
        #endregion

        #region Create Operations
        
        public User CreateUser(User user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            // Ki?m tra email ?ã t?n t?i ch?a
            if (EmailExists(user.Email))
                throw new InvalidOperationException("Email already exists");

            // T?o salt và hash password n?u ch?a ???c th?c hi?n
            if (string.IsNullOrEmpty(user.Salt))
            {
                user.Salt = GenerateSalt();
                user.PasswordHash = HashPassword(user.PasswordHash, user.Salt);
            }

            // ??t th?i gian t?o
            user.CreatedAt = DateTime.Now;

            // Thêm vào database
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }
        
        #endregion

        #region Read Operations
        
        public User GetUserById(int userId)
        {
            return _context.Users.Find(userId);
        }

        public User GetUserByEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
                return null;

            return _context.Users.FirstOrDefault(u => u.Email.Equals(email, StringComparison.OrdinalIgnoreCase));
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }
        
        #endregion

        #region Update Operations
        
        public User UpdateUser(User user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            var existingUser = _context.Users.Find(user.UserId);
            if (existingUser == null)
                throw new InvalidOperationException("User not found");

            // Ki?m tra n?u email ?ang thay ??i sang email ?ã t?n t?i
            if (!existingUser.Email.Equals(user.Email, StringComparison.OrdinalIgnoreCase) && EmailExists(user.Email))
                throw new InvalidOperationException("Email already exists");

            // C?p nh?t các thu?c tính
            existingUser.Name = user.Name;
            existingUser.Email = user.Email;
            existingUser.Income = user.Income;
            existingUser.Goal = user.Goal;

            // Ch? c?p nh?t m?t kh?u n?u có m?t kh?u m?i
            if (!string.IsNullOrEmpty(user.PasswordHash) && user.PasswordHash != existingUser.PasswordHash)
            {
                existingUser.Salt = GenerateSalt();
                existingUser.PasswordHash = HashPassword(user.PasswordHash, existingUser.Salt);
            }

            _context.SaveChanges();
            return existingUser;
        }
        
        #endregion

        #region Delete Operations
        
        public bool DeleteUser(int userId)
        {
            var user = _context.Users.Find(userId);
            if (user == null)
                return false;

            _context.Users.Remove(user);
            _context.SaveChanges();
            return true;
        }
        
        #endregion

        #region Authentication
        
        public bool ValidateUser(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
                return false;

            // L?y thông tin ng??i dùng
            var user = GetUserByEmail(email);
            if (user == null)
                return false;

            // Hash password v?i salt và so sánh
            var hashedPassword = HashPassword(password, user.Salt);
            return user.PasswordHash == hashedPassword;
        }
        
        #endregion

        #region Validation
        
        public bool EmailExists(string email)
        {
            if (string.IsNullOrEmpty(email))
                return false;

            return _context.Users.Any(u => u.Email.Equals(email, StringComparison.OrdinalIgnoreCase));
        }
        
        #endregion

        #region Search Operations
        
        public IEnumerable<User> SearchUsers(string searchTerm)
        {
            if (string.IsNullOrEmpty(searchTerm))
                return GetAllUsers();

            return _context.Users.Where(u => 
                u.Name.Contains(searchTerm) || 
                u.Email.Contains(searchTerm)
            ).ToList();
        }
        
        #endregion

        #region Password Hashing
        
        private string GenerateSalt()
        {
            byte[] saltBytes = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(saltBytes);
            }
            return Convert.ToBase64String(saltBytes);
        }

        private string HashPassword(string password, string salt)
        {
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password + salt);
            using (var sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(passwordBytes);
                return Convert.ToBase64String(hashBytes);
            }
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