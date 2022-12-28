using CityGuide.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CityGuide.Repository
{
    public interface ICitiesRepository
    {
        IEnumerable<Cities> GetCities();
        Cities GetCitiesById(int id);
    }
}
