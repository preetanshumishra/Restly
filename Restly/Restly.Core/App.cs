using MvvmCross.ViewModels;

namespace Restly.Core
{
    public class App : MvxApplication
    {
        public App()
        {
            RegisterServices();
        }

        public override void Initialize()
        {
            RegisterCustomAppStart<AppStart>();
        }

        private void RegisterServices()
        {

        }
    }
}