using Lotto3000App.DTOs;

namespace Lotto3000App.Services.Interfaces
{
    public interface IPrizeService
    {
        List<PrizeDto> GetAll();
        PrizeDto GetById(int id);
        PrizeDto GetPrizeByTier(int tier);
        void Add(PrizeDto entity);
        void Update(PrizeDto entity);
        void Delete(int id);
    }
}
