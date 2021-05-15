namespace Restly.Core
{
    public class Constants
    {
        public static class ApiConstants
        {
            public const int ApiTimeOut = 90;

            public const string BaseApiUrl = "api";

            public static string BaseRestaurantUrl = $"{BaseApiUrl}/Restaurant";
            public static string InitRestaurantUrl = $"{BaseRestaurantUrl}/InitRestaurants";
            public static string GetRestaurantUrl = $"{BaseRestaurantUrl}/GetRestaurants";

            public static string BaseProductUrl = $"{BaseApiUrl}/Product";
            public static string InitRestaurantMenuUrl = $"{BaseProductUrl}/InitRestaurantMenu";
            public static string GetProductByIdUrl = $"{BaseProductUrl}/GetProductById";
            public static string GetMenuListUrl = $"{BaseProductUrl}/GetMenuList";
        }
    }
}