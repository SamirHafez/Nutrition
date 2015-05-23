using Cirrious.CrossCore;
using Cirrious.MvvmCross.ViewModels;
using Nutrition.Core.Models;
using Nutrition.Core.Services.Interfaces;
using System.Collections.ObjectModel;

namespace Nutrition.Core.ViewModels
{
    public class InfoViewModel : MvxViewModel
    {
        double score;
        public double Score
        {
            get { return score; }
            set { score = value; RaisePropertyChanged(() => Score); }
        }

        ObservableCollection<SummaryItemViewModel> summaryItems;
        public ObservableCollection<SummaryItemViewModel> SummaryItems
        {
            get { return summaryItems; }
            set { summaryItems = value; RaisePropertyChanged(() => SummaryItems); }
        }

        BalanceViewModel balance;
        public BalanceViewModel Balance
        {
            get { return balance; }
            set { balance = value; RaisePropertyChanged(() => Balance); }
        }

        readonly IHandleNutritionService NutritionService;
        public InfoViewModel(IHandleNutritionService nutritionService)
        {
            NutritionService = nutritionService;
        }

        protected override void InitFromBundle(IMvxBundle parameters)
        {
            var nutritionTable = parameters.Read<NutritionTable>();

            Score = NutritionService.GetScore(nutritionTable);

            Balance = Mvx.Create<BalanceViewModel>();
            Balance.Update(nutritionTable);
        }
    }
}
