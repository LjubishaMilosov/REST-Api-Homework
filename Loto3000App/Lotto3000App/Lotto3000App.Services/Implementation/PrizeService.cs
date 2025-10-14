using Lotto3000App.DataAccess.Interfaces;
using Lotto3000App.Domain.Enums;
using Lotto3000App.Domain.Models;
using Lotto3000App.DTOs;
using Lotto3000App.Services.Interfaces;

namespace Lotto3000App.Services.Implementation
{
    public class PrizeService : IPrizeService
    {
        private readonly IPrizeRepository _prizeRepository;
        public PrizeService(IPrizeRepository prizeRepository)
        {
            _prizeRepository = prizeRepository;
        }

        public List<PrizeDto> GetAll()
        {
            return _prizeRepository.GetAll()
                .Select(p => new PrizeDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Tier = (int)p.Tier
                }).ToList();
        }

        public PrizeDto GetById(int id)
        {
            var prize = _prizeRepository.GetById(id);
            if (prize == null) return null;
            return new PrizeDto
            {
                Id = prize.Id,
                Name = prize.Name,
                Tier = (int)prize.Tier
            };
        }

        public PrizeDto GetPrizeByTier(int tier)
        {
            var prize = _prizeRepository.GetPrizeByTier(tier);
            if (prize == null) return null;
            return new PrizeDto
            {
                Id = prize.Id,
                Name = prize.Name,
                Tier = (int)prize.Tier
            };
        }

        public void Add(PrizeDto prizeDto)
        {
            var prize = new Prize
            {
                Name = prizeDto.Name,
                Tier = (PrizeTier)prizeDto.Tier
            };
            _prizeRepository.Add(prize);
            prizeDto.Id = prize.Id;
        }

        public void Update(PrizeDto prizeDto)
        {
            var prize = _prizeRepository.GetById(prizeDto.Id);
            if (prize == null) throw new ArgumentException("Prize not found.");
            prize.Name = prizeDto.Name;
            prize.Tier = (PrizeTier)prizeDto.Tier;
            _prizeRepository.Update(prize);
        }

        public void Delete(int id)
        {
            var prize = _prizeRepository.GetById(id);
            if (prize != null)
                _prizeRepository.Delete(prize);
        }
    }
}
