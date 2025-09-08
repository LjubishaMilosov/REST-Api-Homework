using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lotto3000App.DataAccess.Interfaces;
using Lotto3000App.Domain.Models;

namespace Lotto3000App.DataAccess.Implementation
{
    public class DrawRepository : IDrawRepository<Draw>
    {
        private readonly Lotto3000DbContext _context;
        public DrawRepository(Lotto3000DbContext context)
        {
            _context = context;
        }
        public void Add(Draw entity)
        {
            _context.Draws.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(Draw entity)
        {
            _context.Draws.Remove(entity);
            _context.SaveChanges();
        }

        public List<Draw> GetAll()
        {
            return _context.Draws.ToList();
        }

        public Draw GetById(int id)
        {
            var draw = _context.Draws.FirstOrDefault(d => d.Id == id);
            if (draw == null)
            {
                throw new Exception($"draw with {id} not found.");
            }
            return draw;
        }

        public void Update(Draw entity)
        {
            _context.Draws.Update(entity);
            _context.SaveChanges();
        }
    }
}
