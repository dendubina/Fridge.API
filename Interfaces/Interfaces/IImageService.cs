using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Contracts.Interfaces
{
    public interface IImageService
    {
        Task<string> AddImageGetPath(IFormFile image);
    }
}
