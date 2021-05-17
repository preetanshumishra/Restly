using System.Threading.Tasks;
using Restly.Core.Models;

namespace Restly.Core.Services.Abstractions
{
    public interface IProductService
    {
        Task<RestaurantDataModel> InitRestaurantMenu();

        Task<RestaurantDataModel> GetMenuList();

        Task<RestaurantDataModel> GetProductById();
    }
}