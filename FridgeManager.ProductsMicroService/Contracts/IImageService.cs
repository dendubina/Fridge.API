using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace FridgeManager.ProductsMicroService.Contracts
{
    public interface IImageService
    {
        Task<string> AddImageGetPath(IFormFile image);
    }
}
