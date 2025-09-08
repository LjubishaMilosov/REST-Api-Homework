
using Lotto3000App.Domain.Models;

namespace Lotto3000App.DataAccess.Interfaces
{
    public interface IUserRepository<User> where User : BaseEntity
    {
        List<User> GetAll();
        User GetById(int id);
        void Add(User entity);
        void Update(User entity);
        void Delete(User entity);
    }
}
