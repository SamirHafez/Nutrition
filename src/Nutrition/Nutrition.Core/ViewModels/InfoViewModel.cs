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

        double kcals;
        public double KCals
        {
            get { return kcals; }
            set { kcals = value; RaisePropertyChanged(() => KCals); }
        }

        double carbPercentage;
        public double CarbPercentage
        {
            get { return carbPercentage; }
            set { carbPercentage = value; RaisePropertyChanged(() => CarbPercentage); }
        }

        double proteinPercentage;
        public double ProteinPercentage
        {
            get { return proteinPercentage; }
            set { proteinPercentage = value; RaisePropertyChanged(() => ProteinPercentage); }
        }

        double fatPercentage;
        public double FatPercentage
        {
            get { return fatPercentage; }
            set { fatPercentage = value; RaisePropertyChanged(() => FatPercentage); }
        }

        protected override void InitFromBundle(IMvxBundle parameters)
        {
            UpdateTable(parameters.Read<NutritionTable>());
        }

        void UpdateTable(NutritionTable nutritionTable)
        {
            KCals =
                nutritionTable.Carbs * 4 +
                nutritionTable.Protein * 4 +
                nutritionTable.Fat * 9;

            CarbPercentage =
                (nutritionTable.Carbs /
                (nutritionTable.Carbs + nutritionTable.Protein + nutritionTable.Fat)) * 100;

            ProteinPercentage =
                (nutritionTable.Protein /
                (nutritionTable.Carbs + nutritionTable.Protein + nutritionTable.Fat)) * 100;

            FatPercentage =
                (nutritionTable.Fat /
                (nutritionTable.Carbs + nutritionTable.Protein + nutritionTable.Fat)) * 100;

            this.nutritionTable = nutritionTable;
        }
    }
}
