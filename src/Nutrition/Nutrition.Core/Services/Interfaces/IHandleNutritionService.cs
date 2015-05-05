using Nutrition.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nutrition.Core.Services.Interfaces
{
    public interface IHealthSummary
    {
        bool Recommended { get; }
        double KCals { get; }
        double CarbPercentage { get; }
        double ProteinPercentage { get; }
        double FatPercentage { get; }

        string Description { get; }
    }

    public interface IHandleNutritionService
    {
        IHealthSummary GetSummary(NutritionTable table);
    }
}
