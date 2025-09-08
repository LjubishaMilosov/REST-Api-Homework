using Lotto3000App.DataAccess.Interfaces;
using Lotto3000App.Domain.Models;
using Lotto3000App.DTOs;
using Lotto3000App.Services.Interfaces;

namespace Lotto3000App.Services.Implementation
{
    public class DrawService : IDrawService<Draw>
    {
        private readonly IUserRepository<Draw> _drawRepository;
        public DrawService(IUserRepository<Draw> drawRepository)
        {
            _drawRepository = drawRepository;
        }

        public void Add(DrawDto drawDto)
        {
            var draw = new Draw
            {
                DrawTime = drawDto.DrawTime,
                DrawnNumbers = drawDto.DrawnNumbers,
                SessionId = drawDto.SessionId
            };
            _drawRepository.Add(draw);
            drawDto.Id = draw.Id;
        }

        public void Delete(int id)
        {
            var draw = _drawRepository.GetById(id);
            if (draw != null)
                _drawRepository.Delete(draw);
        }

        public List<DrawDto> GetAll()
        {
            return _drawRepository.GetAll()
               .Select(d => new DrawDto
               {
                   Id = d.Id,
                   DrawTime = d.DrawTime,
                   DrawnNumbers = d.DrawnNumbers,
                   SessionId = d.SessionId
               })
               .ToList();
        }

        public DrawDto GetById(int id)
        {
            var draw = _drawRepository.GetById(id);
            if (draw == null) return null;
            return new DrawDto
            {
                Id = draw.Id,
                DrawTime = draw.DrawTime,
                DrawnNumbers = draw.DrawnNumbers,
                SessionId = draw.SessionId
            };
        }

        public void Update(DrawDto drawDto)
        {
            var draw = _drawRepository.GetById(drawDto.Id);
            if (draw == null) return;
            draw.DrawTime = drawDto.DrawTime;
            draw.DrawnNumbers = drawDto.DrawnNumbers;
            draw.SessionId = drawDto.SessionId;
            _drawRepository.Update(draw);
        }
    }
}
