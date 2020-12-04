using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KlaipedaCity.Models;

namespace KlaipedaCity.Repos
{
    public class CuisineRepository : ICuisineRepository
    {
        public IQueryable<Cuisine> Cuisines => throw new NotImplementedException();

        public void CreateCuisine(Cuisine cuisine)
        {
            throw new NotImplementedException();
        }

        public void DeleteCuisine(Cuisine cuisine)
        {
            throw new NotImplementedException();
        }

        public void UpdateCuisine(Cuisine cuisine)
        {
            throw new NotImplementedException();
        }
    }
}
