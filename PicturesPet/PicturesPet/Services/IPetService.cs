using PicturesPet.Models;
using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PicturesPet.Services
{
    [Headers("Content-Type: application/json")]
    public interface IPetService
    {
        [Get("/v1/images/search?size={size}&mime_types={mimeTypes}&format={format}&order={order}&page={page}&limit={limit}")]
        Task<List<PetModel>> Search([Header("x-api-key")]string apiKey, string size = "full", string mimeTypes = "jpg", string format = "json", string order = "RANDOM", int page = 0, int limit = 10);
    }
}