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
        public string SaveUserProfile(UserProfile userProfile)
        {
            string sql = string.Empty;
            sql = "INSERT INTO Registration (Name, Email, Phone, City, Country) VALUES('" + userProfile.Name + "','" + userProfile.Email + "','" +
                userProfile.Phone + "','" + userProfile.City + "','" + userProfile.Country + "')";
            return DBHelper.Instance.Insert(sql);
        }

        public string GetDharamshlaByCity(string cityName)
        {
            return "Sorry no dharamshala";

        }
    }
}
