//using Lotto3000App.DataAccess.Interfaces;
//using Microsoft.EntityFrameworkCore;

//namespace Lotto3000App.DataAccess.Implementation
//{
//    public class Repository<T> : IRepository<T> where T : class
//    {

//        protected readonly Lotto3000DbContext _context;
//        protected readonly DbSet<T> _dbSet;
//        public Repository(Lotto3000DbContext context)
//        {
//            _context = context;
//            _dbSet = _context.Set<T>();
//        }

//        public void Add(T entity)
//        {
//            throw new NotImplementedException();
//        }

//        public void Delete(int id)
//        {
//            throw new NotImplementedException();
//        }

//        public IEnumerable<T> GetAll()
//        {
//            throw new NotImplementedException();
//        }

//        public T? GetById(int id)
//        {
//            throw new NotImplementedException();
//        }

//        public void Update(T entity)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}
