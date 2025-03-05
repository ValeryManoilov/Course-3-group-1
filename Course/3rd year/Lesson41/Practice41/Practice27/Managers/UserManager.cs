using Practice27.Context;
using Practice27.Dto;
using Practice27.Models;
using Microsoft.EntityFrameworkCore;

namespace Practice27.Managers
{
    public class UserManager
    {
        private readonly UserContext _context;

        public UserManager(UserContext context)
        {
            _context = context;
        }

        public async Task<User> GetUserByNameAsync(string username)
        {
            User user = await _context.Users.FirstOrDefaultAsync(u => u.UserName == username);

            return user;
        }

        public async Task<User> CreateUserAsync(UserDto newUser)
        {
            User user = new User
            {
                UserName = newUser.Username,
                Email = newUser.Email,
                Password = newUser.Password
            };

            await _context.Users.AddAsync(user);

            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<User> DeleteUserById(int id)
        {
            User user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);

            if (user == null)
            {
                return null;
            }

            _context.Users.Remove(user);

            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<User> ChangeUserDataAsync(int id, UserDto newUser)
        {
            User user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);

            if (user == null)
            {
                return null;
            }

            user.UserName = newUser.Username;

            user.Email = newUser.Email;
            
            user.Password = newUser.Password;

            await _context.SaveChangesAsync();

            return user;
        }
    }
}
