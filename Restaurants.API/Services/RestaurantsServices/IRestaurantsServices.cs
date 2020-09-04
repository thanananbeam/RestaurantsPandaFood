using Restaurants.API.Services.GoogleAPIServices.Models;

namespace Restaurants.API.Services.RestaurantsServices
{
    public interface IRestaurantsServices
    {
        string FindRestaurant(LocationModels data);
    }
}