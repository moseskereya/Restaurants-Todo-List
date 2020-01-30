using OdeTofood.Data.Modals;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OdeTofood.Data.Services
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        List<Restaurant> restaurants;
        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant {ID = 1, Name = "Moses Pizza", Cuisine = CuisineType.Ameican},
                new Restaurant {ID = 2, Name = "ScottCate`s Burger Hut", Cuisine = CuisineType.Italian},
                new Restaurant {ID = 3, Name = "Jamie`s Fast Food", Cuisine = CuisineType.Indian}

            };
        }

        public void Update(Restaurant restaurant)
        {
            var existing = Get(restaurant.ID);
            if (existing != null)
            {
                existing.Name = restaurant.Name;
                existing.Cuisine = restaurant.Cuisine;
            }
        }
      public  void Add(Restaurant restaurant )
        {
            restaurants.Add(restaurant);
            restaurant.ID = restaurants.Max(r => r.ID) + 1;
        }
       
        public Restaurant Get(int id)
        {
            return restaurants.FirstOrDefault(r => r.ID == id);
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return restaurants.OrderBy(restaurants => restaurants.Name);
        }

        public void Delete(int id)
        {
            var restaurant = Get(id);
            if (restaurant != null)
            {
                restaurants.Remove(restaurant);
            }
        }
    }
}
