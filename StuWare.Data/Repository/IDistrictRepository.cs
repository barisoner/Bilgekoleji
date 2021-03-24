using StuWare.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StuWare.Data.Repository
{
    public interface IDistrictRepository
    {

        public IQueryable<District> Districts { get; }


        public void CreateDistrict(District district);


        public void DeleteDistrict(int districtId);



        public District GetById(int districtId);

        public List<District> GetByCityId(int cityId);

        public void UpdateDistrict(District district);

    }
}

