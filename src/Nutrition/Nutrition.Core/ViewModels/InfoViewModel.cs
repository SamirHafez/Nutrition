using Cirrious.MvvmCross.ViewModels;
using Nutrition.Core.Models;
using Nutrition.Core.Services.Interfaces;
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

        double score;
        public double Score
        {
            get { return score; }
            set { score = value; RaisePropertyChanged(() => Score); }
        }

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

        string summaryDescription;
        public string SummaryDescription
        {
            get { return summaryDescription; }
            set { summaryDescription = value; RaisePropertyChanged(() => SummaryDescription); }
        }

        readonly IHandleNutritionService NutritionService;
        public InfoViewModel(IHandleNutritionService nutritionService)
        {
            NutritionService = nutritionService;
        }

        protected override void InitFromBundle(IMvxBundle parameters)
        {
            UpdateTable(parameters.Read<NutritionTable>());
        }

        void UpdateTable(NutritionTable nutritionTable)
        {
            var summary = NutritionService.GetSummary(nutritionTable);
            var balance = NutritionService.GetBalance(nutritionTable);

            Score = summary.Score;
            SummaryDescription = summary.Description;

            KCals = balance.KCals;
            CarbPercentage = balance.CarbPercentage;
            ProteinPercentage = balance.ProteinPercentage;
            FatPercentage = balance.FatPercentage;
            CarbKCals = balance.CarbsKCals;
            ProteinKCals = balance.ProteinKCals;
            FatKCals = balance.FatKCals;

            this.nutritionTable = nutritionTable;
        }
    }
}
