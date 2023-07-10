using ConsumingApiSection.Models;
using ConsumingApiSection.Models.Models;

namespace ConsumingApiSection.Services.IServices
{
    public interface IBaseService
    {
        APIResponse responseModel { get; set; }
        Task<T> SendAsync<T>(APIRequest apiRequest);


    }
}
