using Nutrition.Core.Models;

namespace Nutrition.Core.Services.Interfaces
{
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
        double GetScore(NutritionTable table);
        IHealthBalance GetBalance(NutritionTable table);
    }
}
