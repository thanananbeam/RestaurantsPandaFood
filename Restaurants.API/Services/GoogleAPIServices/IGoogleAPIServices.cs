using GoogleApi.Entities.Places.Search.Text.Request;

namespace Restaurants.API.Services.GoogleAPIServices
{
    public interface IGoogleAPIServices
    {
        string GooglePlacesTextSearch(PlacesTextSearchRequest req);
    }
}