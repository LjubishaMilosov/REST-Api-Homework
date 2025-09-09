using System.Reflection;
using Lotto3000App.DataAccess.Implementation;
using Lotto3000App.DataAccess.Interfaces;
using Lotto3000App.Domain.Enums;
using Lotto3000App.Domain.Models;
using Lotto3000App.DTOs;
using Lotto3000App.Services.Interfaces;

namespace Lotto3000App.Services.Implementation
{
    public class WinnerService : IWinnerService<Winner>
    {
        private readonly IWinnerRepository<Winner> _winnerRepository;
        public WinnerService(IWinnerRepository<Winner> winnerRepository)
        {
            _winnerRepository = winnerRepository;
        }

        public void Add(WinnerDto winnerDto)
        {
            if (winnerDto == null)
                throw new ArgumentNullException(nameof(winnerDto), "Winner cannot be null");
            if (winnerDto.WinningNumbers == null || winnerDto.WinningNumbers.Count < 3)
                throw new ArgumentException("Winning numbers must be at least 3");
            if (string.IsNullOrWhiteSpace(winnerDto.Prize))
                throw new ArgumentException("Prize must be specified");

            var winner = new Winner
            {
                UserId = winnerDto.UserId,
                Prize = winnerDto.Prize,
                WinningNumbers = winnerDto.WinningNumbers,
                DrawId = winnerDto.DrawId
            };
            _winnerRepository.Add(winner);
            winnerDto.Id = winner.Id;
        }

        public void Delete(int id)
        {
            var winner = _winnerRepository.GetById(id);
            if (winner != null)
                _winnerRepository.Delete(winner);
        }

        public List<WinnerDto> GetAll()
        {
            return _winnerRepository.GetAll()
                .Select(w => new WinnerDto
                {
                    Id = w.Id,
                    UserId = w.UserId,
                    UserName = w.User?.Username,
                    Prize = w.Prize,
                    WinningNumbers = w.WinningNumbers,
                    DrawId = w.DrawId
                })
                .ToList();
        }

        public WinnerDto GetById(int id)
        {
            var winner = _winnerRepository.GetById(id);
            if (winner == null)
            {
                throw new Exception($"Winner with ID {id} not found.");
            }
            ;
            return new WinnerDto
            {
                Id = winner.Id,
                UserId = winner.UserId,
                UserName = winner.User?.Username,
                Prize = winner.Prize,
                WinningNumbers = winner.WinningNumbers,
                DrawId = winner.DrawId
            };
        }

        public void Update(WinnerDto winnerDto)
        {
            var winner = _winnerRepository.GetById(winnerDto.Id);
            if (winner == null) throw new ArgumentException("Winner not found");
            winner.Prize = winnerDto.Prize;
            winner.WinningNumbers = winnerDto.WinningNumbers;
            winner.DrawId = winnerDto.DrawId;
            _winnerRepository.Update(winner);
        }
    }
}
