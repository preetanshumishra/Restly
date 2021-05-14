using MvvmCross.Platforms.Android.Core;
using MvvmCross.ViewModels;
using Restly.Core;

namespace Restly.Droid
{
    public class DroidSetup : MvxAndroidSetup<App>
    {
        protected override IMvxApplication CreateApp()
        {
            var app = new App();
            //RegisterPlatformServices();
            return app;
        }
    }
}