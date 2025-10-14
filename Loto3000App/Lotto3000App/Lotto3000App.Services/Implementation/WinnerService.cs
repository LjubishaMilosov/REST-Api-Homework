using System.Reflection;
using System.Text.RegularExpressions;
using Lotto3000App.DataAccess.Implementation;
using Lotto3000App.DataAccess.Interfaces;
using Lotto3000App.Domain.Enums;
using Lotto3000App.Domain.Models;
using Lotto3000App.DTOs;
using Lotto3000App.Services.Interfaces;

namespace Lotto3000App.Services.Implementation
{
    public class WinnerService : IWinnerService
    {
        private readonly IWinnerRepository _winnerRepository;
        public WinnerService(IWinnerRepository winnerRepository)
        {
            _winnerRepository = winnerRepository;
        }

        public List<WinnerDto> GetAll()
        {
            return _winnerRepository.GetAll()
                .Select(w => new WinnerDto
                {
                    Id = w.Id,
                    FirstName = w.FirstName,
                    LastName = w.LastName,
                    UserId = w.UserId,
                    WinningNumbers = w.WinningNumbers,
                    DrawId = w.DrawId,
                    TicketId = w.TicketId,
                    PrizeId = w.PrizeId,
                    Matches = w.Matches,
                    CreatedAt = w.CreatedAt,
                    PrizeName = w.Prize?.Name
                }).ToList();
        }

        public WinnerDto GetById(int id)
        {
            var winner = _winnerRepository.GetById(id);
            if (winner == null)
            {
                throw new Exception($"Winner with ID {id} not found.");
            };
            return new WinnerDto
            {
                Id = winner.Id,
                FirstName = winner.FirstName,
                LastName = winner.LastName,
                UserId = winner.UserId,
                WinningNumbers = winner.WinningNumbers,
                DrawId = winner.DrawId,
                TicketId = winner.TicketId,
                PrizeId = winner.PrizeId,
                Matches = winner.Matches,
                CreatedAt = winner.CreatedAt,
                PrizeName = winner.Prize?.Name
            };
        }
        public List<WinnerDto> GetWinnersByDrawId(int drawId)
        {
            return _winnerRepository.GetWinnersByDrawId(drawId)
                .Select(w => new WinnerDto
                {
                    Id = w.Id,
                    FirstName = w.FirstName,
                    LastName = w.LastName,
                    UserId = w.UserId,
                    WinningNumbers = w.WinningNumbers,
                    DrawId = w.DrawId,
                    TicketId = w.TicketId,
                    PrizeId = w.PrizeId,
                    Matches = w.Matches,
                    CreatedAt = w.CreatedAt,
                    PrizeName = w.Prize?.Name
                }).ToList();
        }

        public void Add(WinnerDto winnerDto)
        {
            if (winnerDto == null)
                throw new ArgumentNullException(nameof(winnerDto), "Winner cannot be null");
            if (winnerDto.WinningNumbers == null || winnerDto.WinningNumbers.Count < 3)
                throw new ArgumentException("Winning numbers must be at least 3");
            if (string.IsNullOrWhiteSpace(winnerDto.PrizeName))
                throw new ArgumentException("Prize must be specified");

            var winner = new Winner
            {

                FirstName = winnerDto.FirstName,
                LastName = winnerDto.LastName,
                UserId = winnerDto.UserId,
                WinningNumbers = winnerDto.WinningNumbers,
                DrawId = winnerDto.DrawId,
                TicketId = winnerDto.TicketId,
                PrizeId = winnerDto.PrizeId,
                Matches = winnerDto.Matches,
                CreatedAt = winnerDto.CreatedAt
            };
            _winnerRepository.Add(winner);
            winnerDto.Id = winner.Id;
        }

        public void Update(WinnerDto winnerDto)
        {
            var winner = _winnerRepository.GetById(winnerDto.Id);
            if (winner == null) throw new ArgumentException("Winner not found");
            winner.FirstName = winnerDto.FirstName;
            winner.LastName = winnerDto.LastName;
            winner.UserId = winnerDto.UserId;
            winner.WinningNumbers = winnerDto.WinningNumbers;
            winner.DrawId = winnerDto.DrawId;
            winner.TicketId = winnerDto.TicketId;
            winner.PrizeId = winnerDto.PrizeId;
            winner.Matches = winnerDto.Matches;
            winner.CreatedAt = winnerDto.CreatedAt;
            _winnerRepository.Update(winner);
        }

        public void Delete(int id)
        {
            var winner = _winnerRepository.GetById(id);
            if (winner != null)
                _winnerRepository.Delete(winner);
        }
    }
}
