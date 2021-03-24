using StuWare.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StuWare.Data.Repository
{
    public class CityRepository : ICityRepository
    {
        private StuWareContext _context;

        public CityRepository(StuWareContext context)
        {
            _context = context;
        }

        public IQueryable<City> Cities => _context.City;


        public void CreateCity(City city)
        {
            _context.City.Add(city);
            _context.SaveChanges();
        }

        public void DeleteCity(int cityId)
        {
            var city = GetById(cityId);

            if (city != null)
            {
                _context.City.Remove(city);
                _context.SaveChanges();
            }
        }

        public City GetById(int cityId)
        {
            return _context.City.FirstOrDefault(i => i.ID == cityId);
        }

        public void UpdateCity(City city)
        {
            _context.City.Update(city);
            _context.SaveChanges();
        }
    }
}
