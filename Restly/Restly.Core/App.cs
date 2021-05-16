using MvvmCross;
using MvvmCross.IoC;
using MvvmCross.ViewModels;
using Restly.Core.Services.Abstractions;
using Restly.Core.Services.Implementations;
using Xamarin.Essentials.Implementation;
using Xamarin.Essentials.Interfaces;

namespace Restly.Core
{
    public class App : MvxApplication
    {
        public App()
        {
            RegisterServices();
            RegisterEssentialsServices();
        }

        public override void Initialize()
        {
            RegisterCustomAppStart<AppStart>();
        }

        private void RegisterServices()
        {
            var ioCProvider = Mvx.IoCProvider;
            ioCProvider.LazyConstructAndRegisterSingleton<IRestlyNavigationService, RestlyNavigationService>();
            ioCProvider.LazyConstructAndRegisterSingleton<IRestApiClient, RestApiClient>();
            ioCProvider.LazyConstructAndRegisterSingleton<IRestaurantService, RestaurantService>();
            ioCProvider.LazyConstructAndRegisterSingleton<IProductService, ProductService>();
        }

        private void RegisterEssentialsServices()
        {
            var ioCProvider = Mvx.IoCProvider;
            ioCProvider.LazyConstructAndRegisterSingleton<IConnectivity, ConnectivityImplementation>();
        }
    }
}