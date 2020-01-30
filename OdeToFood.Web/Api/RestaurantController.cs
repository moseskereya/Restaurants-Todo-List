using OdeTofood.Data.Modals;
using OdeTofood.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OdeToFood.Web.Api
{
    public class RestaurantController : ApiController
    {
        public RestaurantController(IRestaurantData db)
        {
            Db = db;
        }

        public IRestaurantData Db { get; }

        public IEnumerable<Restaurant> Get()
        {
            var modal = Db.GetAll();
            return modal;
        }
    }
}
