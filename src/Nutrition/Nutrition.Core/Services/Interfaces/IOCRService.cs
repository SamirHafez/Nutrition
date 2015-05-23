using Nutrition.Core.Models;
using System.IO;
using System.Threading.Tasks;

namespace Nutrition.Core.Services.Interfaces
{
    public interface IOCRService
    {
        Task<NutritionTable> GetTableAsync(byte[] picture, uint width, uint height);
    }
}
