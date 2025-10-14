using Lotto3000App.DataAccess.Interfaces;
using Lotto3000App.Domain.Models;

namespace Lotto3000App.DataAccess.Implementation
{
    public class UserRepository : IUserRepository
    {
        private readonly Lotto3000DbContext _context;
        public UserRepository(Lotto3000DbContext context)
        {
            _context = context;
        }
        public void Add(User entity)
        {
            _context.Users.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(User entity)
        {
            _context.Users.Remove(entity);
            _context.SaveChanges();
        }

        public List<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public User GetById(int id)
        {
           var user = _context.Users.FirstOrDefault(u => u.Id == id);
              if (user == null)
              {
                throw new Exception($"User with id {id} not found.");
            }
            return user;
        }

        public User GetByUsername(string username)
        {
            var user = _context.Users.FirstOrDefault(u => u.Username == username);
            if (user == null)
            {
                throw new Exception($"User with username {username} not found.");
            }
            return user;
        }

        public void Update(User entity)
        {
            _context.Users.Update(entity);
            _context.SaveChanges();
        }
    }
}
