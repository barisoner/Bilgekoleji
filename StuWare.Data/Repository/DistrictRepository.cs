using StuWare.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StuWare.Data.Repository
{
    public class DistrictRepository : IDistrictRepository
    {

        private StuWareContext _context;

        public DistrictRepository(StuWareContext context)
        {
            _context = context;
        }

        public IQueryable<District> Districts => _context.District;


        public void CreateDistrict(District district)
        {
            _context.District.Add(district);
            _context.SaveChanges();
        }

        public void DeleteDistrict(int districtId)
        {
            var district = GetById(districtId);

            if (district != null)
            {
                _context.District.Remove(district);
                _context.SaveChanges();
            }
        }

        public District GetById(int districtId)
        {
            return _context.District.FirstOrDefault(i => i.ID == districtId);
        }

        public List<District> GetByCityId(int cityId)
        {
            return _context.District.Where(i => i.CityID == cityId).ToList();
        }

        public void UpdateDistrict(District district)
        {
            _context.District.Update(district);
            _context.SaveChanges();
        }
    }

}
