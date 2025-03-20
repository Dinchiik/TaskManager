using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BCrypt.Net;
using TaskManager.Data;
using TaskManager.Models;


namespace TaskManager.Services
{
    public class UserService
    {
        private readonly AppDbContext _context;
        public UserService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Register(string username, string password)
        {
            if(await _context.Users.AnyAsync(u=>u.UserName==username))
                return false;
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(password);
            _context.Users.Add(new User { UserName = username, PasswordHash = passwordHash });
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> Login(string username, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserName == username);
            return user != null && BCrypt.Net.BCrypt.Verify(password, user.PasswordHash);
        }
    }
}
