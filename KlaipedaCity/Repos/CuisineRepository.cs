using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KlaipedaCity.Models;

namespace KlaipedaCity.Repos
{
    public class CuisineRepository : ICuisineRepository
    {
        private KlaipedaDbContext context;

        // Constructor
        public CuisineRepository(KlaipedaDbContext c)
        {
            context = c;
        }

        public IQueryable<Cuisine> Cuisines { get { return context.Cuisines; } }

        public void CreateCuisine(Cuisine cuisine)
        {
            context.Add(cuisine);
            context.SaveChanges();
        }

        public void DeleteCuisine(Cuisine cuisine)
        {
            var cuisineToDel = context.Cuisines.Find(cuisine.CuisineID);
            context.Remove(cuisineToDel);
            context.SaveChanges();
        }

        public void UpdateCuisine(Cuisine cuisine)
        {
            var oldCuisine = context.Cuisines.Find(cuisine.CuisineID);
            // Updating individual values
            oldCuisine.CuisineID = cuisine.CuisineID;
            oldCuisine.CuisineName = cuisine.CuisineName;
            context.SaveChanges();
        }
    }
}
