using MvvmCross;
using Restly.Core.Services.Abstractions;

namespace Restly.Core.Services.Implementations
{
    public class BaseApiService
    {
        protected readonly IRestApiClient RestApiClient;

        protected string BaseUrl => Constants.ApiConstants.BaseApiUrl;

        protected BaseApiService()
        {
            RestApiClient = Mvx.IoCProvider.Resolve<IRestApiClient>();
        }
    }
}