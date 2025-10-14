using Lotto3000App.DataAccess.Interfaces;
using Lotto3000App.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Lotto3000App.DataAccess.Implementation
{
    public class WinnerRepository : IWinnerRepository
    {
        private readonly Lotto3000DbContext _context;
        public WinnerRepository(Lotto3000DbContext context)
        {
            _context = context;
        }
        public void Add(Winner entity)
        {
            _context.Winners.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(Winner entity)
        {
            _context.Winners.Remove(entity);
            _context.SaveChanges();
        }

        public List<Winner> GetAll()
        {
            return _context.Winners.ToList();
        }

        public Winner GetById(int id)
        {
            var winner = _context.Winners.FirstOrDefault(d => d.Id == id);
            if (winner == null)
            {
                throw new Exception($"draw with {id} not found.");
            }
            return winner;
        }

        public List<Winner> GetWinnersByDrawId(int drawId)
        {
            return _context.Winners.Where(w => w.DrawId == drawId).ToList();
        }

        public void Update(Winner entity)
        {
            _context.Winners.Update(entity);
            _context.SaveChanges();
        }
    }
}