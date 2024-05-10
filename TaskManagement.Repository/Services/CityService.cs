using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Helper.CityHelper;
using TaskManagement.Models.DBContext;
using TaskManagement.Models.ViewModel;
using TaskManagement.Repository.Interface;

namespace TaskManagement.Repository.Services
{
    public class CityServices : ICityInterface
    {
        public List<CityModel> GetCityByStateId(int id)
        {
            TaskManagement_452Entities _DBContext = new TaskManagement_452Entities();
            try
            {
                List<CityModel> cityModelList = new List<CityModel>();
                List<Cities> cityList = _DBContext.Cities.Where(m => m.StateID == id).ToList();

                cityModelList = CityHelper.ConvertCityToCityModel(cityList);
                return cityModelList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
