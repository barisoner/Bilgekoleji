using StuWare.Model;
using System.Collections.Generic;
using System.Linq;

namespace StuWare.Data.Repository
{
    public interface ICityRepository
    {
        IQueryable<City> Cities { get; }

        void CreateCity(City city);


        void DeleteCity(int cityId);


        City GetById(int cityId);

        void UpdateCity(City city);

    }
}
