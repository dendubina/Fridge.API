using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ProductsService.Contracts
{
    public interface IImageService
    {
        Task<string> AddImageGetPath(IFormFile image);
    }
}
