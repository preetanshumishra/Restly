using System.Threading;
using System.Threading.Tasks;

namespace Restly.Core.Services.Abstractions
{
    public interface IRestApiClient
    {
        Task<TResponse> GetAsync<TResponse>(
            string apiPath,
            CancellationToken cancellationToken = default) where TResponse : new();

        Task<TResponse> GetAsync<TRequest, TResponse>(
            string apiPath,
            TRequest requestModel,
            CancellationToken cancellationToken = default) where TResponse : new();

        Task<bool> PostAsync<TRequest>(
            string apiPath,
            TRequest requestModel,
            CancellationToken cancellationToken = default);

        Task<TResponse> PostAsync<TRequest, TResponse>(
            string apiPath,
            TRequest requestModel,
            CancellationToken cancellationToken = default);

        Task<bool> PutAsync<TRequest>(
            string apiPath,
            TRequest requestModel,
            CancellationToken cancellationToken = default);

        Task<TResponse> PutAsync<TRequest, TResponse>(
            string apiPath,
             TRequest requestModel,
            CancellationToken cancellationToken = default);

        Task DeleteAsync<TRequest>(
            string apiPath,
            TRequest requestModel,
            CancellationToken cancellationToken = default);
    }
}