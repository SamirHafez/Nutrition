using Cirrious.CrossCore;
using Cirrious.MvvmCross.Plugins.Messenger;
using Nutrition.Core.Utils;
using System;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

namespace Nutrition.WP
{
    public sealed partial class App : Application
    {
        private TransitionCollection transitions;

        public App()
        {
            this.InitializeComponent();
            this.Suspending += this.OnSuspending;
        }

        protected async override void OnActivated(IActivatedEventArgs args)
        {
            base.OnActivated(args);

            var continuationEventArgs = args as IContinuationActivatedEventArgs;
            if (continuationEventArgs != null)
            {
                switch (continuationEventArgs.Kind)
                {
                    case ActivationKind.PickFileContinuation:
                        FileOpenPickerContinuationEventArgs arguments = continuationEventArgs as FileOpenPickerContinuationEventArgs;
                        StorageFile file = arguments.Files.FirstOrDefault();
                        var messenger = Mvx.Resolve<IMvxMessenger>();

                        using (var imgStream = await file.OpenAsync(FileAccessMode.Read))
                        {
                            var buffer = new byte[imgStream.Size];
                            await imgStream.ReadAsync(buffer.AsBuffer(), (uint)imgStream.Size, InputStreamOptions.None);
                            var properties = await file.Properties.GetImagePropertiesAsync();
                            var message = new PictureMessage(this)
                            {
                                Width = properties.Width,
                                Height = properties.Height,
                                Picture = buffer
                            };
                            messenger.Publish(message);
                        } 
                        break;
                }
            }
        }

        protected override void OnLaunched(LaunchActivatedEventArgs e)
        {
#if DEBUG
            if (System.Diagnostics.Debugger.IsAttached)
            {
                this.DebugSettings.EnableFrameRateCounter = true;
            }
#endif

            Frame rootFrame = Window.Current.Content as Frame;

            if (rootFrame == null)
            {
                rootFrame = new Frame();

                // TODO: change this value to a cache size that is appropriate for your application
                rootFrame.CacheSize = 1;

                if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)
                {
                    // TODO: Load state from previously suspended application
                }

                Window.Current.Content = rootFrame;
            }

            if (rootFrame.Content == null)
            {
                if (rootFrame.ContentTransitions != null)
                {
                    this.transitions = new TransitionCollection();
                    foreach (var c in rootFrame.ContentTransitions)
                    {
                        this.transitions.Add(c);
                    }
                }

                rootFrame.ContentTransitions = null;
                rootFrame.Navigated += this.RootFrame_FirstNavigated;

                var setup = new Setup(rootFrame);
                setup.Initialize();

                var start = Cirrious.CrossCore.Mvx.Resolve<Cirrious.MvvmCross.ViewModels.IMvxAppStart>();
                start.Start();
            }

            Window.Current.Activate();
        }

        private void RootFrame_FirstNavigated(object sender, NavigationEventArgs e)
        {
            var rootFrame = sender as Frame;
            rootFrame.ContentTransitions = this.transitions ?? new TransitionCollection() { new NavigationThemeTransition() };
            rootFrame.Navigated -= this.RootFrame_FirstNavigated;
        }

        private void OnSuspending(object sender, SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral();

            // TODO: Save application state and stop any background activity
            deferral.Complete();
        }
    }
}