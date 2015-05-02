using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nutrition.Core.Services.Interfaces
{
    public interface IOCRService
    {
        Task<string> GetTextAsync();
    }
}
