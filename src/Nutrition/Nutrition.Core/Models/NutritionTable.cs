using System;

namespace Nutrition.Core.Models
{
    public class NutritionTable
    {
        public double Carbs { get; set; }
        public double SugarCarbs { get; set; }
        public double Protein { get; set; }
        public double Fat { get; set; }
        public double SaturatedFats { get; set; }
        public double Salt { get; set; }

        public static NutritionTable Parse(string text)
        {
            throw new NotImplementedException();
        }
    }
}
