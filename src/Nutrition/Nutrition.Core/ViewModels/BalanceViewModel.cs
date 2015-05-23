using Cirrious.MvvmCross.ViewModels;
using Nutrition.Core.Models;
using Nutrition.Core.Services.Interfaces;

namespace Nutrition.Core.ViewModels
{
    public class BalanceViewModel : MvxViewModel
    {
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

        double carbKCals;
        public double CarbKCals
        {
            get { return carbKCals; }
            set { carbKCals = value; RaisePropertyChanged(() => CarbKCals); }
        }

        double proteinKCals;
        public double ProteinKCals
        {
            get { return proteinKCals; }
            set { proteinKCals = value; RaisePropertyChanged(() => ProteinKCals); }
        }

        double fatKCals;
        public double FatKCals
        {
            get { return fatKCals; }
            set { fatKCals = value; RaisePropertyChanged(() => FatKCals); }
        }

        readonly IHandleNutritionService NutritionService;
        public BalanceViewModel(IHandleNutritionService nutritionService)
        {
            NutritionService = nutritionService;
        }

        protected override void InitFromBundle(IMvxBundle parameters)
        {
            base.InitFromBundle(parameters);

            var nutritionTable = parameters.Read<NutritionTable>();

            Update(nutritionTable);
        }

        public void Update(NutritionTable nutritionTable)
        {
            var balance = NutritionService.GetBalance(nutritionTable);

            KCals = balance.KCals;
            CarbPercentage = balance.CarbPercentage;
            ProteinPercentage = balance.ProteinPercentage;
            FatPercentage = balance.FatPercentage;
            CarbKCals = balance.CarbsKCals;
            ProteinKCals = balance.ProteinKCals;
            FatKCals = balance.FatKCals;
        }
    }
}
