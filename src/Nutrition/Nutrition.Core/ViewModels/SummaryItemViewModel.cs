using Cirrious.MvvmCross.ViewModels;

namespace Nutrition.Core.ViewModels
{
    public class SummaryItemViewModel : MvxViewModel
    {
        string summary;
        public string Summary
        {
            get { return summary; }
            set { summary = value; RaisePropertyChanged(() => Summary); }
        }
    }
}
