using Cirrious.MvvmCross.ViewModels;
using Nutrition.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nutrition.Core.ViewModels
{
    public class InfoViewModel : MvxViewModel
    {
        NutritionTable nutritionTable;

        protected override void InitFromBundle(IMvxBundle parameters)
        {
            nutritionTable = parameters.Read<NutritionTable>();
        }
    }
}
