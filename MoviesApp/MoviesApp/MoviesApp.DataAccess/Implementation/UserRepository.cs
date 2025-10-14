using Microsoft.EntityFrameworkCore;
using MoviesApp.DataAccess.Interfaces;
using MoviesApp.Domaim.Models;

namespace MoviesApp.DataAccess.Implementation
{
    public class UserRepository : IUserRepository
    {
        private readonly MoviesDbContext _dbContext;
        public UserRepository(MoviesDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Add(User entity)
        {
            _dbContext.Users.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(User entity)
        {
            _dbContext.Users.Remove(entity);
            _dbContext.SaveChanges();
        }

        public List<User> GetAll()
        {
            return _dbContext.Users.Include(x => x.MovieList).ToList();
        }

        public User GetById(int id)
        {   
            return _dbContext.Users
                .Include(x => x.MovieList)
                .FirstOrDefault(u => u.Id == id);
        }

        public User GetUserByUsername(string username)
        {
            return _dbContext.Users
                .Include(x => x.MovieList)
                .FirstOrDefault(u => u.Username.ToLower() == username.ToLower());
        }

        public void Update(User entity)
        {
            _dbContext.Users.Update(entity);
            _dbContext.SaveChanges();
        }
    }
}
