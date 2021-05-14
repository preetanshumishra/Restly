using MvvmCross.Platforms.Ios.Core;
using MvvmCross.ViewModels;
using Restly.Core;

namespace Restly.iOS
{
    public class IosSetup : MvxIosSetup<App>
    {
        protected override IMvxApplication CreateApp()
        {
            var app = new App();
            //RegisterPlatformServices();
            return app;
        }
    }
}