using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using Restly.Core.Services.Abstractions;

namespace Restly.Core.Services.Implementations
{
    public class RestlyNavigationService : MvxNavigationService, IRestlyNavigationService
    {
        public RestlyNavigationService(
            IMvxNavigationCache navigationCache,
            IMvxViewModelLoader viewModelLoader)
            : base(navigationCache, viewModelLoader)
        {

        }
    }
}