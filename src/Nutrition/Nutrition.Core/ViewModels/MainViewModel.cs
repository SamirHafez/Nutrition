using System.Threading.Tasks;
using Cirrious.MvvmCross.ViewModels;
using Nutrition.Core.Services.Interfaces;
using System;
using Cirrious.MvvmCross.Plugins.PictureChooser;
using System.IO;
using Cirrious.MvvmCross.Plugins.Messenger;
using Nutrition.Core.Utils;

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

        MvxCommand toCameraInputCommand;
        public MvxCommand ToCameraInputCommand
        {
            get
            {
                return toCameraInputCommand ??
                    (toCameraInputCommand = new MvxCommand(
                        () => PictureChooser.ChoosePictureFromLibrary(900, 80, null, null)));
            }
        }

        readonly IMvxPictureChooserTask PictureChooser;
        readonly IOCRService OCRService;
        readonly IMvxMessenger Messenger;
        public MainViewModel(IOCRService ocrService, IMvxPictureChooserTask pictureChooser, IMvxMessenger messenger)
        {
            OCRService = ocrService;
            PictureChooser = pictureChooser;
            Messenger = messenger;

            Messenger.Subscribe<PictureMessage>(async msg => await OnPictureReceivedAsync(msg));
        }

        async Task OnPictureReceivedAsync(PictureMessage message)
        {
            var nutritionTable = await OCRService.GetTableAsync(message.Picture, 400, 400);
            ShowViewModel<InfoViewModel>(nutritionTable);
        }
    }
}
