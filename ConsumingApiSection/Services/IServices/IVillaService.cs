using ConsumingApiSection.Models.DTO;

namespace ConsumingApiSection.Services.IServices
{
    public interface IVillaService
    {
        Task<T> GetAllAsync<T>(string token);
        Task<T> GetAsync<T>(int id, string token);
        Task<T> CreateAsync<T>(VillaDTOCreateTable dto, string token);
        Task<T> UpdateAsync<T>(VillaDTOUpdateTable dto, string token);
        Task<T> DeleteAsync<T>(int id, string token);
    }
}
