using Cirrious.CrossCore;
using Cirrious.CrossCore.Platform;
using Cirrious.MvvmCross.ViewModels;
using Cirrious.MvvmCross.WindowsCommon.Platform;
using Nutrition.Core.Services.Interfaces;
using Nutrition.WP.Services;
using Windows.UI.Xaml.Controls;

namespace Nutrition.WP
{
    public class Setup : MvxWindowsSetup
    {
        public Setup(Frame rootFrame) : base(rootFrame)
        { }

        protected override IMvxApplication CreateApp()
        {
            return new Core.App();
        }

        protected override IMvxTrace CreateDebugTrace()
        {
            return new DebugTrace();
        }

        protected override void InitializeFirstChance()
        {
            Mvx.RegisterSingleton<IOCRService>(() => new WPOCRService());
            base.InitializeFirstChance();
        }
    }
}