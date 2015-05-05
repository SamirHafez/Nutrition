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
        double Score { get; }
        string Description { get; }
    }

    public interface IHealthBalance
    {
        double KCals { get; }
        double CarbPercentage { get; }
        double ProteinPercentage { get; }
        double FatPercentage { get; }

        double CarbsKCals { get; }
        double ProteinKCals { get; }
        double FatKCals { get; }
    }

    public interface IHandleNutritionService
    {
        IHealthSummary GetSummary(NutritionTable table);
        IHealthBalance GetBalance(NutritionTable table);
    }
}
