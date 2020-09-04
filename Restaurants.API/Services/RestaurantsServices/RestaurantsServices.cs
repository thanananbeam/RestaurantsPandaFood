using GoogleApi.Entities.Places.Search.Text.Request;
using Restaurants.API.Services.GoogleAPIServices;
using Restaurants.API.Services.GoogleAPIServices.Models;
using Restaurants.API.Services.MemoryCacheServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurants.API.Services.RestaurantsServices
{
    public class RestaurantsServices : IRestaurantsServices
    {
        private readonly IGoogleAPIServices _googleAPIService;
        private readonly IMemoryCacheServices _cache;

        public RestaurantsServices(IGoogleAPIServices googleAPI, IMemoryCacheServices cache)
        {
            _googleAPIService = googleAPI;
            _cache = cache;
        }

        public string FindRestaurant(LocationModels data)
        {
            object cacheItem = _cache.GetMemoryCache<string>(data.location);

            if (cacheItem != null) 
            {
                return cacheItem.ToString();
            }

            PlacesTextSearchRequest request = new PlacesTextSearchRequest
            {
                Query = string.Concat("restaurant+in+", data.location)
            };

            string result = _googleAPIService.GooglePlacesTextSearch(request);
            /*
            string result = @"{
                ""html_attributions"": [],
                ""next_page_token"": ""CpQCAgEAAP0Gtb6kRDDfDHlT3nfUqSmjHqvuGEnlGFbqNY9-J041kazax9QfT7kSvQTIl0jPaIvTvOX_YscCOZniaClTjKwZhvH5kCyUZKjb8jipw7-Qaue0vM-PeAggydwq1bZy-9Ex1UbtM1mLKOpzQOsl4MJ4GshyV7IlvJOeBhpRvF7tvY84DzDhIkezfo6UrCdmkEzxiiCzWq_eD5DbQ91ZU8J2J6XV8HMqJQcnGe8rmPcluRkPqUrlXD09bnKYNmnl5ySMncz01DShmXk5fjHl-QB_zjHfzcjkUM1y43maEwipZgQAzfbgyFsAxzizUOl4VoC0TRo9DKLJqvijO4b-5szOLBvDwpQTyAVIPgNFfvWyEhDNTNCNSNEQYXGJwsea4PIYGhTUwXEIBoSJR3K0E_NwxWAja_utVA"",
                ""results"": [
                    {
                        ""business_status"": ""OPERATIONAL"",
                        ""formatted_address"": ""162/1-2, 168, 10 Pracha Rat Sai 2 Rd, Bang Sue, Bangkok 10800, Thailand"",
                        ""geometry"": {
                            ""location"": {
                                ""lat"": 13.8057622,
                                ""lng"": 100.5240266
                            },
                            ""viewport"": {
                                ""northeast"": {
                                    ""lat"": 13.80740762989272,
                                    ""lng"": 100.5253767298927
                                },
                                ""southwest"": {
                                    ""lat"": 13.80470797010728,
                                    ""lng"": 100.5226770701073
                                }
                            }
                        },
                        ""icon"": ""https://maps.gstatic.com/mapfiles/place_api/icons/restaurant-71.png"",
                        ""name"": ""Cheesy Fried at Gateway Bangsue"",
                        ""opening_hours"": {
                            ""open_now"": true
                        },
                        ""place_id"": ""ChIJH_bFF6Kb4jARkWSQO1x9tN4"",
                        ""plus_code"": {
                            ""compound_code"": ""RG4F+8J Bangkok"",
                            ""global_code"": ""7P52RG4F+8J""
                        },
                        ""rating"": 0,
                        ""reference"": ""ChIJH_bFF6Kb4jARkWSQO1x9tN4"",
                        ""types"": [
                            ""restaurant"",
                            ""food"",
                            ""point_of_interest"",
                            ""establishment""
                        ],
                        ""user_ratings_total"": 0
                    },
                    {
                        ""business_status"": ""OPERATIONAL"",
                        ""formatted_address"": ""162, 1 Pracha Rat Sai 2 Rd, Bang Sue, Bangkok 10800, Thailand"",
                        ""geometry"": {
                            ""location"": {
                                ""lat"": 13.8061783,
                                ""lng"": 100.5240973
                            },
                            ""viewport"": {
                                ""northeast"": {
                                    ""lat"": 13.80703347989272,
                                    ""lng"": 100.5256561798927
                                },
                                ""southwest"": {
                                    ""lat"": 13.80433382010728,
                                    ""lng"": 100.5229565201073
                                }
                            }
                        },
                        ""icon"": ""https://maps.gstatic.com/mapfiles/place_api/icons/restaurant-71.png"",
                        ""name"": ""MK Restaurant-Gateway Bangsue"",
                        ""opening_hours"": {
                            ""open_now"": true
                        },
                        ""photos"": [
                            {
                                ""height"": 3024,
                                ""html_attributions"": [
                                    ""\u003ca href=\""https://maps.google.com/maps/contrib/114316477315605188219\""\u003eSirada Pookkasorn\u003c/a\u003e""
                                ],
                                ""photo_reference"": ""CkQ0AAAAYC1gQdI_Z8HEkdj6wjxSJb7aaUmO4wEg-OIbgkABU1z78ovZjgFSJN0TUzCWJegE_GdyhIyxI8lUtFkDJLCVixIQ4cXKSvwajmlZztWN_8VqxRoUUFv3sTQI8GSPFhl0bpCOtrA_T2Y"",
                                ""width"": 4032
                            }
                        ],
                        ""place_id"": ""ChIJdcdrnIyb4jARidxLOO6zAZs"",
                        ""plus_code"": {
                            ""compound_code"": ""RG4F+FJ Bangkok"",
                            ""global_code"": ""7P52RG4F+FJ""
                        },
                        ""price_level"": 2,
                        ""rating"": 4.1,
                        ""reference"": ""ChIJdcdrnIyb4jARidxLOO6zAZs"",
                        ""types"": [
                            ""restaurant"",
                            ""food"",
                            ""point_of_interest"",
                            ""establishment""
                        ],
                        ""user_ratings_total"": 32
                    },
                    {
                        ""business_status"": ""OPERATIONAL"",
                        ""formatted_address"": ""662 Rd, Techawanit, Bang Sue, Bangkok 10800, Thailand"",
                        ""geometry"": {
                            ""location"": {
                                ""lat"": 13.802348,
                                ""lng"": 100.534942
                            },
                            ""viewport"": {
                                ""northeast"": {
                                    ""lat"": 13.80373022989272,
                                    ""lng"": 100.5362260798927
                                },
                                ""southwest"": {
                                    ""lat"": 13.80103057010728,
                                    ""lng"": 100.5335264201073
                                }
                            }
                        },
                        ""icon"": ""https://maps.gstatic.com/mapfiles/place_api/icons/restaurant-71.png"",
                        ""name"": ""Kumamura Food.Bar"",
                        ""opening_hours"": {
                            ""open_now"": true
                        },
                        ""photos"": [
                            {
                                ""height"": 2160,
                                ""html_attributions"": [
                                    ""\u003ca href=\""https://maps.google.com/maps/contrib/112940298874092038720\""\u003epitchaya peanpensiriwong\u003c/a\u003e""
                                ],
                                ""photo_reference"": ""CkQ0AAAAE_OkeIczKeSFxeh3xJK4PTbcR79ftIVdoTtnTl0f3CJphUt8UFE1UEJMcz3mCD6DN2HQZzebeZH29a6pfNLD8RIQwGCNWBSAco4BcuDGhqJXhBoUcCKuLhtlEvAwf4R1QA_eKHYY6QQ"",
                                ""width"": 3840
                            }
                        ],
                        ""place_id"": ""ChIJdWfiWQuc4jARi2oLVe-QNGs"",
                        ""plus_code"": {
                            ""compound_code"": ""RG2M+WX Bangkok"",
                            ""global_code"": ""7P52RG2M+WX""
                        },
                        ""rating"": 4.3,
                        ""reference"": ""ChIJdWfiWQuc4jARi2oLVe-QNGs"",
                        ""types"": [
                            ""restaurant"",
                            ""food"",
                            ""point_of_interest"",
                            ""establishment""
                        ],
                        ""user_ratings_total"": 130
                    },
                    {
                        ""business_status"": ""OPERATIONAL"",
                        ""formatted_address"": ""1300, 5 Pracha Chuen Rd, Wong Sawang, Bang Sue, Bangkok 10800, Thailand"",
                        ""geometry"": {
                            ""location"": {
                                ""lat"": 13.8421541,
                                ""lng"": 100.5415515
                            },
                            ""viewport"": {
                                ""northeast"": {
                                    ""lat"": 13.84348647989272,
                                    ""lng"": 100.5429968798927
                                },
                                ""southwest"": {
                                    ""lat"": 13.84078682010728,
                                    ""lng"": 100.5402972201073
                                }
                            }
                        },
                        ""icon"": ""https://maps.gstatic.com/mapfiles/place_api/icons/restaurant-71.png"",
                        ""name"": ""Food"",
                        ""place_id"": ""ChIJDcF71Rad4jARcjtHrq3Dw6A"",
                        ""plus_code"": {
                            ""compound_code"": ""RGRR+VJ Bangkok"",
                            ""global_code"": ""7P52RGRR+VJ""
                        },
                        ""rating"": 0,
                        ""reference"": ""ChIJDcF71Rad4jARcjtHrq3Dw6A"",
                        ""types"": [
                            ""restaurant"",
                            ""food"",
                            ""point_of_interest"",
                            ""establishment""
                        ],
                        ""user_ratings_total"": 0
                    },
                    {
                        ""business_status"": ""OPERATIONAL"",
                        ""formatted_address"": ""3, 393, 393/3 Pracha Rat Sai 2 Rd, Bang Sue, Bangkok 10800, Thailand"",
                        ""geometry"": {
                            ""location"": {
                                ""lat"": 13.8065862,
                                ""lng"": 100.5210336
                            },
                            ""viewport"": {
                                ""northeast"": {
                                    ""lat"": 13.80784707989272,
                                    ""lng"": 100.5226785298927
                                },
                                ""southwest"": {
                                    ""lat"": 13.80514742010728,
                                    ""lng"": 100.5199788701073
                                }
                            }
                        },
                        ""icon"": ""https://maps.gstatic.com/mapfiles/place_api/icons/restaurant-71.png"",
                        ""name"": ""จั๊กหน่อย Jaknoi Restaurant"",
                        ""opening_hours"": {
                            ""open_now"": true
                        },
                        ""photos"": [
                            {
                                ""height"": 3036,
                                ""html_attributions"": [
                                    ""\u003ca href=\""https://maps.google.com/maps/contrib/114469118395545767440\""\u003ePatanan Ariyakornwijit\u003c/a\u003e""
                                ],
                                ""photo_reference"": ""CkQ0AAAA5Y-bE27rinz3IlOORaLcUD7NFYeloQa7UcAtbztuJWWRNuuUP6DyAK8XPiXrX59hjHjcHq56KKXDH-xvLinZ6xIQ-Igt1wz-Q9FL0FseSDSOlRoUiwsNrAbu22IHDs8vshl4hF7ejKM"",
                                ""width"": 4048
                            }
                        ],
                        ""place_id"": ""ChIJ-yZhqo2b4jARsYKjNsLniIw"",
                        ""plus_code"": {
                            ""compound_code"": ""RG4C+JC Bangkok"",
                            ""global_code"": ""7P52RG4C+JC""
                        },
                        ""rating"": 4.4,
                        ""reference"": ""ChIJ-yZhqo2b4jARsYKjNsLniIw"",
                        ""types"": [
                            ""restaurant"",
                            ""food"",
                            ""point_of_interest"",
                            ""establishment""
                        ],
                        ""user_ratings_total"": 93
                    },
                    {
                        ""business_status"": ""OPERATIONAL"",
                        ""formatted_address"": ""G floor,Foodcourt (Gateway Bangsue) ,Pracharaj2 Rd, Bang Sue, Bangkok 10800, Thailand"",
                        ""geometry"": {
                            ""location"": {
                                ""lat"": 13.806107,
                                ""lng"": 100.5240377
                            },
                            ""viewport"": {
                                ""northeast"": {
                                    ""lat"": 13.80758002989272,
                                    ""lng"": 100.5253876298927
                                },
                                ""southwest"": {
                                    ""lat"": 13.80488037010728,
                                    ""lng"": 100.5226879701073
                                }
                            }
                        },
                        ""icon"": ""https://maps.gstatic.com/mapfiles/place_api/icons/restaurant-71.png"",
                        ""name"": ""Naikun Pochana"",
                        ""opening_hours"": {
                            ""open_now"": true
                        },
                        ""place_id"": ""ChIJofLQfGOb4jARaNqWxKNEblM"",
                        ""plus_code"": {
                            ""compound_code"": ""RG4F+CJ Bangkok"",
                            ""global_code"": ""7P52RG4F+CJ""
                        },
                        ""rating"": 0,
                        ""reference"": ""ChIJofLQfGOb4jARaNqWxKNEblM"",
                        ""types"": [
                            ""restaurant"",
                            ""food"",
                            ""point_of_interest"",
                            ""establishment""
                        ],
                        ""user_ratings_total"": 0
                    },
                    {
                        ""business_status"": ""OPERATIONAL"",
                        ""formatted_address"": ""888, Big C Wongsawang, Phibun Songkham Road, Bang Sue, Khet Bang Sue, Bangkok, 10800, Thailand"",
                        ""geometry"": {
                            ""location"": {
                                ""lat"": 13.826808,
                                ""lng"": 100.5283463
                            },
                            ""viewport"": {
                                ""northeast"": {
                                    ""lat"": 13.82822302989272,
                                    ""lng"": 100.5296371798927
                                },
                                ""southwest"": {
                                    ""lat"": 13.82552337010728,
                                    ""lng"": 100.5269375201073
                                }
                            }
                        },
                        ""icon"": ""https://maps.gstatic.com/mapfiles/place_api/icons/restaurant-71.png"",
                        ""name"": ""EZ’S Kitchen"",
                        ""place_id"": ""ChIJa4T68n-b4jARHu--c7HGsms"",
                        ""plus_code"": {
                            ""compound_code"": ""RGGH+P8 Bangkok"",
                            ""global_code"": ""7P52RGGH+P8""
                        },
                        ""rating"": 0,
                        ""reference"": ""ChIJa4T68n-b4jARHu--c7HGsms"",
                        ""types"": [
                            ""restaurant"",
                            ""food"",
                            ""point_of_interest"",
                            ""establishment""
                        ],
                        ""user_ratings_total"": 0
                    },
                    {
                        ""business_status"": ""OPERATIONAL"",
                        ""formatted_address"": ""9 11 ถนน เทอดดำริห์ Bang Sue, Bangkok 10800, Thailand"",
                        ""geometry"": {
                            ""location"": {
                                ""lat"": 13.8020812,
                                ""lng"": 100.5387946
                            },
                            ""viewport"": {
                                ""northeast"": {
                                    ""lat"": 13.80340652989272,
                                    ""lng"": 100.5402081298927
                                },
                                ""southwest"": {
                                    ""lat"": 13.80070687010728,
                                    ""lng"": 100.5375084701073
                                }
                            }
                        },
                        ""icon"": ""https://maps.gstatic.com/mapfiles/place_api/icons/restaurant-71.png"",
                        ""name"": ""Bella Casa"",
                        ""opening_hours"": {
                            ""open_now"": false
                        },
                        ""photos"": [
                            {
                                ""height"": 3024,
                                ""html_attributions"": [
                                    ""\u003ca href=\""https://maps.google.com/maps/contrib/116536155265710385634\""\u003eKosit Boonroungkaw\u003c/a\u003e""
                                ],
                                ""photo_reference"": ""CkQ0AAAAoFK8ppL69IMDZrbSEamTEsTsXmhjnO9yYhEZ2dKp3cOx7xN8OL4pI2vxoqMc-Ro1CblAMPhAYbAC3bi6QCKVmBIQ59o-ITz_wvMm0uBxKH_WRBoU2YPnFJmk0QcuatZ7I-2UNhz37so"",
                                ""width"": 4032
                            }
                        ],
                        ""place_id"": ""ChIJpQIYOw2c4jARAuLothgZn9Y"",
                        ""plus_code"": {
                            ""compound_code"": ""RG2Q+RG Bangkok"",
                            ""global_code"": ""7P52RG2Q+RG""
                        },
                        ""price_level"": 2,
                        ""rating"": 4.3,
                        ""reference"": ""ChIJpQIYOw2c4jARAuLothgZn9Y"",
                        ""types"": [
                            ""restaurant"",
                            ""food"",
                            ""point_of_interest"",
                            ""establishment""
                        ],
                        ""user_ratings_total"": 364
                    },
                    {
                        ""business_status"": ""OPERATIONAL"",
                        ""formatted_address"": ""324/2 Soi Pracha Rat Sai 1 Soi20, Pracha Rat Sai 1 Road, Khwaeng Bang Sue, Khet Bang Sue, Bangkok, 10800, 10800, Thailand"",
                        ""geometry"": {
                            ""location"": {
                                ""lat"": 13.8075695,
                                ""lng"": 100.5218999
                            },
                            ""viewport"": {
                                ""northeast"": {
                                    ""lat"": 13.80889952989272,
                                    ""lng"": 100.5232503798927
                                },
                                ""southwest"": {
                                    ""lat"": 13.80619987010728,
                                    ""lng"": 100.5205507201073
                                }
                            }
                        },
                        ""icon"": ""https://maps.gstatic.com/mapfiles/place_api/icons/restaurant-71.png"",
                        ""name"": ""Khun Pichet Shop"",
                        ""place_id"": ""ChIJkzIHRoyb4jARGfRLCKh5Wdk"",
                        ""plus_code"": {
                            ""compound_code"": ""RG5C+2Q Bangkok"",
                            ""global_code"": ""7P52RG5C+2Q""
                        },
                        ""rating"": 0,
                        ""reference"": ""ChIJkzIHRoyb4jARGfRLCKh5Wdk"",
                        ""types"": [
                            ""restaurant"",
                            ""food"",
                            ""point_of_interest"",
                            ""establishment""
                        ],
                        ""user_ratings_total"": 0
                    },
                    {
                        ""business_status"": ""OPERATIONAL"",
                        ""formatted_address"": ""Gateway Bangsue 162/1-2,168/10 Pracharaj Sai 2 Raod, Bang Sue, Bangkok 10800, Thailand"",
                        ""geometry"": {
                            ""location"": {
                                ""lat"": 13.8056377,
                                ""lng"": 100.5238886
                            },
                            ""viewport"": {
                                ""northeast"": {
                                    ""lat"": 13.80702992989272,
                                    ""lng"": 100.5255146798927
                                },
                                ""southwest"": {
                                    ""lat"": 13.80433027010728,
                                    ""lng"": 100.5228150201073
                                }
                            }
                        },
                        ""icon"": ""https://maps.gstatic.com/mapfiles/place_api/icons/restaurant-71.png"",
                        ""name"": ""The Pizza Company"",
                        ""photos"": [
                            {
                                ""height"": 3024,
                                ""html_attributions"": [
                                    ""\u003ca href=\""https://maps.google.com/maps/contrib/100904235663459247298\""\u003eSu-apa Dar\u003c/a\u003e""
                                ],
                                ""photo_reference"": ""CkQ0AAAAV0dxQ0VA1FL8KVgfzj9wQ6wIa0BA9kwOBC0XrYtn0CtKeCMTE5ef6jqj71U-zFlPnxFoB3-sGi0IHxotFwp-ZhIQ-e5L7L6EURL94p5x4FtSIRoUrEKSBIlq2BpLeUo6l1bxvkOjbPI"",
                                ""width"": 4032
                            }
                        ],
                        ""place_id"": ""ChIJ_zIR4kWb4jARGqmUEOmn1c0"",
                        ""plus_code"": {
                            ""compound_code"": ""RG4F+7H Bangkok"",
                            ""global_code"": ""7P52RG4F+7H""
                        },
                        ""price_level"": 2,
                        ""rating"": 4.3,
                        ""reference"": ""ChIJ_zIR4kWb4jARGqmUEOmn1c0"",
                        ""types"": [
                            ""restaurant"",
                            ""food"",
                            ""point_of_interest"",
                            ""establishment""
                        ],
                        ""user_ratings_total"": 3
                    },
                    {
                        ""business_status"": ""OPERATIONAL"",
                        ""formatted_address"": ""168 อาคารศูนการค้าเกตเวย์แอทบางซื่อ ห้องเลขที่ 3011 ชั้นที่ 3 เลขที่ 162/1-2 10 Pracha Rat Sai 2 Rd, บางซื่อ Bang Sue, Bangkok 10800, Thailand"",
                        ""geometry"": {
                            ""location"": {
                                ""lat"": 13.8062237,
                                ""lng"": 100.5221815
                            },
                            ""viewport"": {
                                ""northeast"": {
                                    ""lat"": 13.80762057989272,
                                    ""lng"": 100.5235297298927
                                },
                                ""southwest"": {
                                    ""lat"": 13.80492092010728,
                                    ""lng"": 100.5208300701073
                                }
                            }
                        },
                        ""icon"": ""https://maps.gstatic.com/mapfiles/place_api/icons/restaurant-71.png"",
                        ""name"": ""Kousen Gateway Bangsue"",
                        ""opening_hours"": {
                            ""open_now"": true
                        },
                        ""photos"": [
                            {
                                ""height"": 3024,
                                ""html_attributions"": [
                                    ""\u003ca href=\""https://maps.google.com/maps/contrib/116367986270991281586\""\u003eTanK Casanova\u003c/a\u003e""
                                ],
                                ""photo_reference"": ""CkQ0AAAAuKTrlCVaI3YGz3DRfEwVCtA3gtpZdZIq1FgCdqLv7wqgCr0sBU9POE0ApZbLGzzN7S87MCF95shs3_oYwc6PURIQIbB7PzzSuJBhL-RLmtze_hoU_1eWf9VgvXVcQykjZa5dy2WnmDM"",
                                ""width"": 4032
                            }
                        ],
                        ""place_id"": ""ChIJT24IxGeb4jARjk_M2hJcXCg"",
                        ""plus_code"": {
                            ""compound_code"": ""RG4C+FV Bangkok"",
                            ""global_code"": ""7P52RG4C+FV""
                        },
                        ""rating"": 3.7,
                        ""reference"": ""ChIJT24IxGeb4jARjk_M2hJcXCg"",
                        ""types"": [
                            ""restaurant"",
                            ""food"",
                            ""point_of_interest"",
                            ""establishment""
                        ],
                        ""user_ratings_total"": 21
                    },
                    {
                        ""business_status"": ""OPERATIONAL"",
                        ""formatted_address"": ""Thanon Ratchawithi, Khwaeng Bang Sue, Khet Bang Sue, Bangkok 10800, Thailand"",
                        ""geometry"": {
                            ""location"": {
                                ""lat"": 13.8118838,
                                ""lng"": 100.5269769
                            },
                            ""viewport"": {
                                ""northeast"": {
                                    ""lat"": 13.81316772989272,
                                    ""lng"": 100.5283432298927
                                },
                                ""southwest"": {
                                    ""lat"": 13.81046807010728,
                                    ""lng"": 100.5256435701073
                                }
                            }
                        },
                        ""icon"": ""https://maps.gstatic.com/mapfiles/place_api/icons/restaurant-71.png"",
                        ""name"": ""ก๋วยเตี๋ยวเรือกรุงเทพ"",
                        ""place_id"": ""ChIJ6zKFJD2b4jARkBzbr7e9E4w"",
                        ""plus_code"": {
                            ""compound_code"": ""RG6G+QQ Bangkok"",
                            ""global_code"": ""7P52RG6G+QQ""
                        },
                        ""rating"": 0,
                        ""reference"": ""ChIJ6zKFJD2b4jARkBzbr7e9E4w"",
                        ""types"": [
                            ""restaurant"",
                            ""food"",
                            ""point_of_interest"",
                            ""establishment""
                        ],
                        ""user_ratings_total"": 0
                    },
                    {
                        ""business_status"": ""OPERATIONAL"",
                        ""formatted_address"": ""888, Big C Wongsawang, Phibun Songkham Road, Bang Sue, Khet Bang Sue, Bangkok, 10800, Thailand"",
                        ""geometry"": {
                            ""location"": {
                                ""lat"": 13.8267455,
                                ""lng"": 100.5283678
                            },
                            ""viewport"": {
                                ""northeast"": {
                                    ""lat"": 13.82818337989272,
                                    ""lng"": 100.5296380298927
                                },
                                ""southwest"": {
                                    ""lat"": 13.82548372010728,
                                    ""lng"": 100.5269383701073
                                }
                            }
                        },
                        ""icon"": ""https://maps.gstatic.com/mapfiles/place_api/icons/restaurant-71.png"",
                        ""name"": ""MK Restaurants"",
                        ""opening_hours"": {
                            ""open_now"": true
                        },
                        ""photos"": [
                            {
                                ""height"": 4608,
                                ""html_attributions"": [
                                    ""\u003ca href=\""https://maps.google.com/maps/contrib/111239440725254232287\""\u003eSomboon Prakitcharoensuk\u003c/a\u003e""
                                ],
                                ""photo_reference"": ""CkQ0AAAA_HJaOmaZ7KwwIOzNREEa6OZwFaTweAxvqMxDg8vrO-qZgvXy-GcSNAktVpdyo2KP7Hpu4idwGFhWoTeUucZkJRIQoEhT-ST3a67trOlpVO4JpRoUekxmqfFvE4LAfayL0Hix7UF08Sk"",
                                ""width"": 3456
                            }
                        ],
                        ""place_id"": ""ChIJ7SQB83-b4jAR66Em1dydPTA"",
                        ""plus_code"": {
                            ""compound_code"": ""RGGH+M8 Bangkok"",
                            ""global_code"": ""7P52RGGH+M8""
                        },
                        ""price_level"": 2,
                        ""rating"": 3.6,
                        ""reference"": ""ChIJ7SQB83-b4jAR66Em1dydPTA"",
                        ""types"": [
                            ""restaurant"",
                            ""food"",
                            ""point_of_interest"",
                            ""establishment""
                        ],
                        ""user_ratings_total"": 14
                    },
                    {
                        ""business_status"": ""OPERATIONAL"",
                        ""formatted_address"": ""จุด พัก รถ ทาง ด่วน ประชาชื่น, ซอย ประชาชื่น, Wong Sawang, Bang Sue, Bangkok 10800, Thailand"",
                        ""geometry"": {
                            ""location"": {
                                ""lat"": 13.8418269,
                                ""lng"": 100.5329413
                            },
                            ""viewport"": {
                                ""northeast"": {
                                    ""lat"": 13.84312972989272,
                                    ""lng"": 100.5342450298927
                                },
                                ""southwest"": {
                                    ""lat"": 13.84043007010728,
                                    ""lng"": 100.5315453701073
                                }
                            }
                        },
                        ""icon"": ""https://maps.gstatic.com/mapfiles/place_api/icons/restaurant-71.png"",
                        ""name"": ""ครัวคุณเหวิน"",
                        ""opening_hours"": {
                            ""open_now"": true
                        },
                        ""photos"": [
                            {
                                ""height"": 3024,
                                ""html_attributions"": [
                                    ""\u003ca href=\""https://maps.google.com/maps/contrib/103236700266654776321\""\u003eโค้ก ลำปลอก\u003c/a\u003e""
                                ],
                                ""photo_reference"": ""CkQ0AAAAwvJcQE6om1n91iyIUUrhHSlvfk8g_E9lhf993HdXKhmGKeAE0BtkEzIZ8-JgMbx1XIcdxyLQQxIDTADruv21xxIQ2vmsCKZLydbf15T1DLD1sRoUQHv5KVW53cCDn09F37okAqlYppQ"",
                                ""width"": 4032
                            }
                        ],
                        ""place_id"": ""ChIJdT_gR5yc4jARTaON1tPgOdY"",
                        ""plus_code"": {
                            ""compound_code"": ""RGRM+P5 Bangkok"",
                            ""global_code"": ""7P52RGRM+P5""
                        },
                        ""rating"": 3.7,
                        ""reference"": ""ChIJdT_gR5yc4jARTaON1tPgOdY"",
                        ""types"": [
                            ""restaurant"",
                            ""food"",
                            ""point_of_interest"",
                            ""establishment""
                        ],
                        ""user_ratings_total"": 26
                    },
                    {
                        ""business_status"": ""OPERATIONAL"",
                        ""formatted_address"": ""758, 2 Pracha Rat Sai 2 Rd, Bang Sue, Bangkok 10800, Thailand"",
                        ""geometry"": {
                            ""location"": {
                                ""lat"": 13.8051377,
                                ""lng"": 100.5344175
                            },
                            ""viewport"": {
                                ""northeast"": {
                                    ""lat"": 13.80649487989272,
                                    ""lng"": 100.5357702798927
                                },
                                ""southwest"": {
                                    ""lat"": 13.80379522010728,
                                    ""lng"": 100.5330706201073
                                }
                            }
                        },
                        ""icon"": ""https://maps.gstatic.com/mapfiles/place_api/icons/restaurant-71.png"",
                        ""name"": ""ราดหน้าเจ้าเก่าเตาปูน"",
                        ""photos"": [
                            {
                                ""height"": 4032,
                                ""html_attributions"": [
                                    ""\u003ca href=\""https://maps.google.com/maps/contrib/111153842073386572907\""\u003eHappy Go Lucky\u003c/a\u003e""
                                ],
                                ""photo_reference"": ""CkQ0AAAA7692s9mD9pojVuhTv-CUGcRaKBveX155eKiqkoR9K5ILrYQ89kzPo6ll-funIGvXyCjOfDPsVDErdJaG2XFQlBIQl3N6kPtFNwb7sTlSBrD7CRoUpRMdwxQAlpaSYygx3XUo442VY0U"",
                                ""width"": 3024
                            }
                        ],
                        ""place_id"": ""ChIJV911bD6d4jARcNlUEYkf4Qg"",
                        ""plus_code"": {
                            ""compound_code"": ""RG4M+3Q Bangkok"",
                            ""global_code"": ""7P52RG4M+3Q""
                        },
                        ""rating"": 4,
                        ""reference"": ""ChIJV911bD6d4jARcNlUEYkf4Qg"",
                        ""types"": [
                            ""restaurant"",
                            ""food"",
                            ""point_of_interest"",
                            ""establishment""
                        ],
                        ""user_ratings_total"": 1
                    },
                    {
                        ""business_status"": ""OPERATIONAL"",
                        ""formatted_address"": ""Sena Place Hotel Bangkok, 17 Phaholyothin Rd., Soi 11, Wong Sawang, Bang Sue, Bangkok 10800, Thailand"",
                        ""geometry"": {
                            ""location"": {
                                ""lat"": 13.826837,
                                ""lng"": 100.5198066
                            },
                            ""viewport"": {
                                ""northeast"": {
                                    ""lat"": 13.82816612989272,
                                    ""lng"": 100.5211319798927
                                },
                                ""southwest"": {
                                    ""lat"": 13.82546647010728,
                                    ""lng"": 100.5184323201073
                                }
                            }
                        },
                        ""icon"": ""https://maps.gstatic.com/mapfiles/place_api/icons/restaurant-71.png"",
                        ""name"": ""Newton Co., Ltd."",
                        ""place_id"": ""ChIJx8n9EICc4jARRNQk1cFPfmc"",
                        ""plus_code"": {
                            ""compound_code"": ""RGG9+PW Bangkok"",
                            ""global_code"": ""7P52RGG9+PW""
                        },
                        ""rating"": 1,
                        ""reference"": ""ChIJx8n9EICc4jARRNQk1cFPfmc"",
                        ""types"": [
                            ""restaurant"",
                            ""food"",
                            ""point_of_interest"",
                            ""establishment""
                        ],
                        ""user_ratings_total"": 1
                    },
                    {
                        ""business_status"": ""OPERATIONAL"",
                        ""formatted_address"": ""Gateway AT Bangsue ชั้น G 162/1-2, 168 10 Pracha Rat Sai 2 Rd, Bang Sue, Bangkok 10800, Thailand"",
                        ""geometry"": {
                            ""location"": {
                                ""lat"": 13.8058082,
                                ""lng"": 100.5239598
                            },
                            ""viewport"": {
                                ""northeast"": {
                                    ""lat"": 13.80743062989272,
                                    ""lng"": 100.5253138798927
                                },
                                ""southwest"": {
                                    ""lat"": 13.80473097010728,
                                    ""lng"": 100.5226142201073
                                }
                            }
                        },
                        ""icon"": ""https://maps.gstatic.com/mapfiles/place_api/icons/restaurant-71.png"",
                        ""name"": ""Miss Mamon"",
                        ""opening_hours"": {
                            ""open_now"": true
                        },
                        ""photos"": [
                            {
                                ""height"": 800,
                                ""html_attributions"": [
                                    ""\u003ca href=\""https://maps.google.com/maps/contrib/107001800734594849485\""\u003eA Google User\u003c/a\u003e""
                                ],
                                ""photo_reference"": ""CkQ0AAAA5dKnPsi8DqhTA-RKTKUkU4dvMwfPIm-Nt4OCCq6mZv8oJZr0QaQyuQGh9R-vIhSTeLP2fJyaiAngdjv62TwgTxIQdzPao5s20iwG3x4oC3m9SRoUZ5XhiFYf03EBvN55z048A6yBmgI"",
                                ""width"": 800
                            }
                        ],
                        ""place_id"": ""ChIJTX6sLGeb4jARYxj4IV7hJwg"",
                        ""plus_code"": {
                            ""compound_code"": ""RG4F+8H Bangkok"",
                            ""global_code"": ""7P52RG4F+8H""
                        },
                        ""rating"": 4.8,
                        ""reference"": ""ChIJTX6sLGeb4jARYxj4IV7hJwg"",
                        ""types"": [
                            ""restaurant"",
                            ""food"",
                            ""point_of_interest"",
                            ""establishment""
                        ],
                        ""user_ratings_total"": 4
                    },
                    {
                        ""business_status"": ""OPERATIONAL"",
                        ""formatted_address"": ""882,884, Bang Sue, Bangkok 10800, Thailand"",
                        ""geometry"": {
                            ""location"": {
                                ""lat"": 13.8128458,
                                ""lng"": 100.531724
                            },
                            ""viewport"": {
                                ""northeast"": {
                                    ""lat"": 13.81419847989272,
                                    ""lng"": 100.5330485298927
                                },
                                ""southwest"": {
                                    ""lat"": 13.81149882010728,
                                    ""lng"": 100.5303488701073
                                }
                            }
                        },
                        ""icon"": ""https://maps.gstatic.com/mapfiles/place_api/icons/restaurant-71.png"",
                        ""name"": ""ร้านแซบอีสาน"",
                        ""opening_hours"": {
                            ""open_now"": true
                        },
                        ""photos"": [
                            {
                                ""height"": 452,
                                ""html_attributions"": [
                                    ""\u003ca href=\""https://maps.google.com/maps/contrib/107873967421351613205\""\u003eA Google User\u003c/a\u003e""
                                ],
                                ""photo_reference"": ""CkQ0AAAA5FlqyDxb9SC58q-AgRJE_HCUSp2NgbIr86obQmzrOP69eIjRDNb7Q_PUPtDKgrsn6m82eg8qmznG2jYENXCx7RIQ-93OzxqBJeocYFSK57t4OhoU8rGcYZk6HSW2jMNeuPDAb9mYf54"",
                                ""width"": 678
                            }
                        ],
                        ""place_id"": ""ChIJ7d4HD41fHTER4RO6CjcfodI"",
                        ""plus_code"": {
                            ""compound_code"": ""RG7J+4M Bangkok"",
                            ""global_code"": ""7P52RG7J+4M""
                        },
                        ""rating"": 4.2,
                        ""reference"": ""ChIJ7d4HD41fHTER4RO6CjcfodI"",
                        ""types"": [
                            ""restaurant"",
                            ""food"",
                            ""point_of_interest"",
                            ""establishment""
                        ],
                        ""user_ratings_total"": 76
                    },
                    {
                        ""business_status"": ""OPERATIONAL"",
                        ""formatted_address"": ""162/1 Pracha Rat Sai 2 Rd, Bang Sue, Bangkok 10800, Thailand"",
                        ""geometry"": {
                            ""location"": {
                                ""lat"": 13.8056303,
                                ""lng"": 100.5236035
                            },
                            ""viewport"": {
                                ""northeast"": {
                                    ""lat"": 13.80734132989272,
                                    ""lng"": 100.5249488298927
                                },
                                ""southwest"": {
                                    ""lat"": 13.80464167010728,
                                    ""lng"": 100.5222491701073
                                }
                            }
                        },
                        ""icon"": ""https://maps.gstatic.com/mapfiles/place_api/icons/restaurant-71.png"",
                        ""name"": ""Time&Tales gateway bangsue"",
                        ""opening_hours"": {
                            ""open_now"": true
                        },
                        ""photos"": [
                            {
                                ""height"": 3968,
                                ""html_attributions"": [
                                    ""\u003ca href=\""https://maps.google.com/maps/contrib/105359838543665032930\""\u003ePty L\u003c/a\u003e""
                                ],
                                ""photo_reference"": ""CkQ0AAAA7e9PJHTZsj91_glazUOXWM2R923zCH_kkJz4KWP3jxyRkByYy8iyOnYeJkstvYqX8QSdwod9aBtmIc1y-2KCsxIQLqjhA1Vz1LXbQh9xKJODHhoU4A3iWIK6yAHt4jkA3GOb8fVBggk"",
                                ""width"": 2976
                            }
                        ],
                        ""place_id"": ""ChIJh67w6WSb4jARhDt-7y2zPEk"",
                        ""plus_code"": {
                            ""compound_code"": ""RG4F+7C Bangkok"",
                            ""global_code"": ""7P52RG4F+7C""
                        },
                        ""rating"": 4.3,
                        ""reference"": ""ChIJh67w6WSb4jARhDt-7y2zPEk"",
                        ""types"": [
                            ""restaurant"",
                            ""food"",
                            ""point_of_interest"",
                            ""establishment""
                        ],
                        ""user_ratings_total"": 10
                    },
                    {
                        ""business_status"": ""OPERATIONAL"",
                        ""formatted_address"": ""98, 92 ซอย วงศ์สว่าง 19 Wong Sawang, Bang Sue, Bangkok 10800, Thailand"",
                        ""geometry"": {
                            ""location"": {
                                ""lat"": 13.8255289,
                                ""lng"": 100.5177214
                            },
                            ""viewport"": {
                                ""northeast"": {
                                    ""lat"": 13.82691252989272,
                                    ""lng"": 100.5190799298927
                                },
                                ""southwest"": {
                                    ""lat"": 13.82421287010728,
                                    ""lng"": 100.5163802701073
                                }
                            }
                        },
                        ""icon"": ""https://maps.gstatic.com/mapfiles/place_api/icons/restaurant-71.png"",
                        ""name"": ""ซอยหมู่บ้านจงสุข ( วงศ์สว่าง19 )"",
                        ""opening_hours"": {
                            ""open_now"": true
                        },
                        ""photos"": [
                            {
                                ""height"": 400,
                                ""html_attributions"": [
                                    ""\u003ca href=\""https://maps.google.com/maps/contrib/101926940287883852230\""\u003ePimjai Santipiromkul\u003c/a\u003e""
                                ],
                                ""photo_reference"": ""CkQ0AAAAjIdBSjnwn_BfFFNg9tfHbXuHzNH0qNEl2sXwEbB2Kawn7yUR-2hBfq_hzQpkrAG8_A2Nw4yYiTPu_KbqsbenQBIQRnv_RYZpzuIhTf52tlaHqhoUJl-pPa49Nyxdk8y_v8o-dkr57lU"",
                                ""width"": 600
                            }
                        ],
                        ""place_id"": ""ChIJSU59VY6b4jARdCBVicZgssM"",
                        ""plus_code"": {
                            ""compound_code"": ""RGG9+63 Bangkok"",
                            ""global_code"": ""7P52RGG9+63""
                        },
                        ""rating"": 5,
                        ""reference"": ""ChIJSU59VY6b4jARdCBVicZgssM"",
                        ""types"": [
                            ""restaurant"",
                            ""food"",
                            ""point_of_interest"",
                            ""establishment""
                        ],
                        ""user_ratings_total"": 2
                    }
                ],
                ""status"": ""OK""
            }";
            */
            _cache.SetMemoryCache(data.location, result);

            return result;
        }
    }
}
