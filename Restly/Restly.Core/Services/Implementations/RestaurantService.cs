using System;
using System.Threading.Tasks;
using Restly.Core.Models;
using Restly.Core.Services.Abstractions;

namespace Restly.Core.Services.Implementations
{
    public class RestaurantService : BaseApiService, IRestaurantService
    {
        public Task<RestaurantDataModel> InitRestaurants()
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

        public Task<RestaurantDataModel> GetRestaurants()
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