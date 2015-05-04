using Cirrious.MvvmCross.ViewModels;
using System.Windows.Input;

namespace Nutrition.Core.ViewModels
{
    public class MainViewModel : MvxViewModel
    {
        MvxCommand toManualInputCommand;
        public MvxCommand ToManualInputCommand
        {
            get
            {
                return toManualInputCommand ??
                    (toManualInputCommand = new MvxCommand(
                        () => ShowViewModel<ManualInputViewModel>()));
            }
        }
    }
}
