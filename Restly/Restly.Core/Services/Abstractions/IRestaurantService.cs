using System.Threading.Tasks;
using Restly.Core.Models;

namespace Restly.Core.Services.Abstractions
{
    public interface IRestaurantService
    {
        Task<RestaurantDataModel> InitRestaurants();

        Task<RestaurantDataModel> GetRestaurants();
    }
}