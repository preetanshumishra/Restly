using System;
using System.Threading.Tasks;
using Restly.Core.Models;
using Restly.Core.Services.Abstractions;

namespace Restly.Core.Services.Implementations
{
    public class ProductService : BaseApiService, IProductService
    {
        public Task<RestaurantDataModel> GetMenuList()
        {
            try
            {

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return null;
        }

        public Task<RestaurantDataModel> GetProductById()
        {
            try
            {

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return null;
        }

        public Task<RestaurantDataModel> InitRestaurantMenu()
        {
            try
            {

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return null;
        }
    }
}