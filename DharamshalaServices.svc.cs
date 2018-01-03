using DharamshalaServices.Model;
using DharamshalaServices.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace DharamshalaServices
{
    public class DharamshalaServices : IService
    {
        public void SaveUserProfile(UserProfile userProfile)
        {
            string sql = string.Empty;
            sql = "INSERT INTO Registration (Name, Email, Phone, City, Country) VALUES('" + userProfile.Name + "','" + userProfile.Email + "','" +
                userProfile.Phone + "','" + userProfile.City + "','" + userProfile.Country + "')";
            using (var obj = new DBHelper())
            {
                 obj.Insert(sql);
            }
        }

        public List<City> GetCities()
        {
            List<City> cities =null;
            string sql = "Select CityID, Name from City";
            using (var obj = new DBHelper())
            {
                var records = obj.Select(sql);
                if (records?.HasRows == true)
                {
                    cities = new List<City>();
                    while (records.Read())
                    {
                        City city = new City()
                        {
                            CityName = records["Name"].ToString(),
                            CityId = Convert.ToInt32(records["CityID"])
                        };
                        cities.Add(city);
                    }
                }

            }
            return cities;
        }

        public string GetDharamshlaByCity(string cityName)
        {
            return "Sorry no dharamshala";

        }
    }
}
