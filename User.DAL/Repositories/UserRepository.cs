using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User.DAL.Repositories
{
    public interface IUserRepository
    {
        void AddUser(User.DAL.Entities.User user);
        User.DAL.Entities.User? GetUser(int id);
        User.DAL.Entities.User? GetUser(string email);
        void UpdateUser(User.DAL.Entities.User user);
        void DeleteUser(int id);
    }
    public class UserRepository : IUserRepository
    {
        private readonly UserDbContext _context;
        public UserRepository(UserDbContext context)
        {
            _context = context;
        }
        public void AddUser(User.DAL.Entities.User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }
        public User.DAL.Entities.User? GetUser(int id)
        {
            return _context.Users.FirstOrDefault(u => u.Id == id);
        }
        public User.DAL.Entities.User? GetUser(string email)
        {
            return _context.Users.FirstOrDefault(u => u.Email == email);
        }
        public void UpdateUser(User.DAL.Entities.User user)
        {
            user.UpdatedDate = DateTime.Now;
            _context.Users.Update(user);
            _context.SaveChanges();
        }
        public void DeleteUser(int id)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == id);
            if (user != null)
            {
                user.IsDeleted = true;
                _context.SaveChanges();
            }
        }

    }
}
