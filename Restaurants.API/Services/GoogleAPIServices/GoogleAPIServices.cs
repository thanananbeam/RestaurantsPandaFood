using GoogleApi.Entities.Places.Search.Text.Request;
using GoogleApi.Entities.Places.Search.Text.Response;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurants.API.Services.GoogleAPIServices
{
    public class GoogleAPIServices : IGoogleAPIServices
    {
        private readonly IConfiguration _configuration;

        public GoogleAPIServices(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GooglePlacesTextSearch(PlacesTextSearchRequest request)
        {
            request.Key = _configuration["ApiKey"];
            PlacesTextSearchResponse response = GoogleApi.GooglePlaces.TextSearch.Query(request);
            return response.RawJson;
        }
    }
}
