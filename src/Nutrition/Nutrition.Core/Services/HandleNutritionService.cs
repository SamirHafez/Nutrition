using Nutrition.Core.Models;
using Nutrition.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nutrition.Core.Services
{
    public class HandleNutritionService : IHandleNutritionService
    {
        public class HealthBalance : IHealthBalance
        {
            readonly NutritionTable nutritionTable;

            public HealthBalance(NutritionTable table)
            {
                this.nutritionTable = table;
            }

            public double KCals
            {
                get
                {
                    return Math.Round(nutritionTable.Carbs * 4 +
                           nutritionTable.Protein * 4 +
                           nutritionTable.Fat * 9, 1);
                }
            }

            public double CarbPercentage
            {
                get
                {
                    return Math.Round((nutritionTable.Carbs /
                           (nutritionTable.Carbs + nutritionTable.Protein + nutritionTable.Fat)) * 100, 1);
                }
            }

            public double ProteinPercentage
            {
                get
                {
                    return Math.Round((nutritionTable.Protein /
                           (nutritionTable.Carbs + nutritionTable.Protein + nutritionTable.Fat)) * 100, 1);
                }
            }

            public double FatPercentage
            {
                get
                {
                    return Math.Round((nutritionTable.Fat /
                           (nutritionTable.Carbs + nutritionTable.Protein + nutritionTable.Fat)) * 100, 1);
                }
            }

            public double CarbsKCals
            {
                get { return Math.Round(nutritionTable.Carbs * 4, 1); }
            }

            public double ProteinKCals
            {
                get { return Math.Round(nutritionTable.Protein * 4, 1); }
            }

            public double FatKCals
            {
                get { return Math.Round(nutritionTable.Fat * 9, 1); }
            }
        }

        public double GetScore(NutritionTable table)
        {
            throw new NotImplementedException();
        }

        public IHealthBalance GetBalance(NutritionTable table)
        {
            return new HealthBalance(table);
        }
    }
}