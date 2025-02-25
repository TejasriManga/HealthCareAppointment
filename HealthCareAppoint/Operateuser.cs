using System;
using System.Collections.Generic;
using System.Linq;
using HealthCareAppoint;

namespace HealthCareAppoint
{
    public class Operateuser
    {
        private readonly HealthcareContext _context;

        public Operateuser(HealthcareContext context)
        {
            _context = context;
        }

        // User operations
        public void InsertUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            Console.WriteLine("User registered successfully!");
        }

        public void UpdateUser(User updatedUser)
        {
            var user = _context.Users.Find(updatedUser.UserId);
            if (user != null)
            {
                user.Name = updatedUser.Name;
                user.Phone = updatedUser.Phone;
                user.Email = updatedUser.Email;
                user.Password = updatedUser.Password;
                _context.SaveChanges();
                Console.WriteLine("User updated successfully!");
            }
            else
            {
                Console.WriteLine("User not found!");
            }
        }

        public void DeleteUser(User userToDelete)
        {
            var user = _context.Users.Find(userToDelete.UserId);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
                Console.WriteLine("User deleted successfully!");
            }
            else
            {
                Console.WriteLine("User not found!");
            }
        }

        public List<User> ViewUsers()
        {
            return _context.Users.ToList();
        }
    }
}