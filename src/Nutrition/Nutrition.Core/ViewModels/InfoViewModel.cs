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

        bool recommended;
        public bool Recommended
        {
            get { return recommended; }
            set { recommended = value; RaisePropertyChanged(() => Recommended); }
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

            Recommended = summary.Recommended;
            KCals = summary.KCals;
            CarbPercentage = summary.CarbPercentage;
            ProteinPercentage = summary.ProteinPercentage;
            FatPercentage = summary.FatPercentage;
            SummaryDescription = summary.Description;

            this.nutritionTable = nutritionTable;
        }
    }
}
