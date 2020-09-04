using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurants.API.Models
{
    public class ResponseModels
    {
        public string msg { get; set; }
        public object data { get; set; }
        public bool status { get; set; } = false;
    }
}
