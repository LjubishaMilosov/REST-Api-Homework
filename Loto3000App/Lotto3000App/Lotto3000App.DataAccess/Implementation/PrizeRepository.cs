using Lotto3000App.DataAccess.Interfaces;
using Lotto3000App.Domain.Models;

namespace Lotto3000App.DataAccess.Implementation
{
    public class PrizeRepository : IPrizeRepository
    {
        private readonly Lotto3000DbContext _context;
        public PrizeRepository(Lotto3000DbContext context)
        {
            _context = context;
        }
        public void Add(Prize entity)
        {
            _context.Prizes.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(Prize entity)
        {
            _context.Prizes.Remove(entity);
            _context.SaveChanges();
        }

        public List<Prize> GetAll()
        {
            return _context.Prizes.ToList();
        }

        public Prize GetById(int id)
        {
            var prize = _context.Prizes.FirstOrDefault(p => p.Id == id);
            if (prize == null)
                throw new Exception($"Prize with id {id} not found.");
            return prize;
        }

        public Prize GetPrizeByTier(int tier)
        {
            return _context.Prizes.FirstOrDefault(p => (int)p.Tier == tier);
        }

        public void Update(Prize entity)
        {
            _context.Prizes.Update(entity);
            _context.SaveChanges();
        }
    }
}
