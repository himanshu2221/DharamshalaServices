using DharamshalaServices.Model;
using DharamshalaServices.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using static DharamshalaServices.Model.Booking;

namespace DharamshalaServices
{
    public class DharamshalaServices : IService
    {

        public bool Authenticate(Authenticate loginInfo)
        {
            bool isLoginSucessFull = false;
            var sql = "select * from Login where UserId='" + loginInfo.UserId + "' and Password='" + loginInfo.Password + "'";
            using (var dbCon = new DBHelper())
            {
                var records = dbCon.Select(sql);
                if (records?.HasRows == true)
                {
                    isLoginSucessFull = true;
                }
            }
            return isLoginSucessFull;
        }

        public void SaveUserProfile(UserProfile userProfile)
        {
            var UserProfileSql = "INSERT INTO Registration (Name, Email, Phone, City, Country) VALUES('" + userProfile.Name + "','" + userProfile.Email + "','" +
                userProfile.Phone + "','" + userProfile.City + "','" + userProfile.Country + "')";
            var loginSQL = "INSERT INTO Login (UserId, Password) VALUES('" + userProfile.UserId + "','" + userProfile.Password + "')";
            using (var obj = new DBHelper())
            {
                 obj.Insert(UserProfileSql);
                obj.Insert(loginSQL);
            }
        }

        public List<City> GetCitiesByState(string StateId)
        {
           string sql = "Select CityID, Name from City where StateID = " + Convert.ToInt32(StateId);
           return GetCities(sql);
        }


        public List<City> GetAllCities()
        {
          string  sql = "Select CityID, Name from City";
          return GetCities(sql);
        }

        private List<City> GetCities(string query)
        {
            List<City> cities =null;
            using (var obj = new DBHelper())
            {
                var records = obj.Select(query);
                if (records?.HasRows == true)
                {
                    cities = new List<City>();
                    while (records.Read())
                    {
                        City city = new City()
                        {
                            Name = records["Name"].ToString(),
                            CityId = Convert.ToInt32(records["CityID"])
                        };
                        cities.Add(city);
                    }
                }

            }
            return cities;
        }

        public List<State> GetStates()
        {
            List<State> states = null;
            string sql = "Select StateID, Name from State";
            using (var obj = new DBHelper())
            {
                var records = obj.Select(sql);
                if (records?.HasRows == true)
                {
                    states = new List<State>();
                    while (records.Read())
                    {
                        State state = new State()
                        {
                            Name = records["Name"].ToString(),
                            StateId = Convert.ToInt32(records["StateID"])
                        };
                        states.Add(state);
                    }
                }

            }
            return states;
        }


        private List<DharamshalaDetails> GetDharamshala(string query)
        {
            List<DharamshalaDetails> dhamaShalaDetails = null;
            using (var obj = new DBHelper())
            {
                var records = obj.Select(query);
                if (records?.HasRows == true)
                {
                    dhamaShalaDetails = new List<DharamshalaDetails>();
                    while (records.Read())
                    {
                        var dharamshala = new DharamshalaDetails()
                        {
                            Name = records["Name"].ToString(),
                            Address = records["Address"].ToString(),
                            Email = records["Email"].ToString(),
                            PhoneNumber = Convert.ToInt64(records["Phone"].ToString()),
                            DharamshalaId = Convert.ToInt32(records["DharamshalaID"])

                        };
                        dhamaShalaDetails.Add(dharamshala);
                    }
                }

            }
            return dhamaShalaDetails;
        }

        public List<DharamshalaDetails> GetAllDharamshala()
        {
            var sql = "select * from Dharamshala_Details";
            return GetDharamshala(sql);

        }

        public List<DharamshalaDetails> GetDharamshalaByCity(string CityId)
        {
            var sql = "select * from Dharamshala_Details where CityID =" + Convert.ToInt32(CityId);
            return GetDharamshala(sql);

        }

        public List<Room> GetRoomsByDharamshala(string dharamshalaId)
        {
            List<Room> rooms = null; 
            var sql = "select * from Room where DharamshalaID =" + Convert.ToInt32(dharamshalaId);

            using (var obj = new DBHelper())
            {
                var records = obj.Select(sql);
                if (records?.HasRows == true)
                {
                    rooms = new List<Room>();
                    while (records.Read())
                    {
                        var room = new Room()
                        {
                            Price = Convert.ToInt32(records["Price"].ToString()),
                            RoomType = records["RoomType"].ToString(),
                            MaxPeopleAllowed = Convert.ToInt32(records["MaxPeopleAllowed"].ToString()),
                            ImageUrl = records["ImageUrl"].ToString()
                        };
                        rooms.Add(room);
                    }
                }
            }
            return rooms;
        }

        public bool Book(Booking booking)
        {
            bool isBookingSucessFull = false;
            int bookingReference;
            var bookingSql = "INSERT INTO Booking (UserID, DharamshalaID, CheckInDate, CheckOutDate, " +
                "ConvenienceFee, TokenAmount, TotalAmount, State) VALUES(" + booking.UserId + "," + booking.DharamshalaId + "," +
              Convert.ToDateTime(booking.CheckInDate).ToString("MM/dd/yyyy") + "," + 
              Convert.ToDateTime(booking.CheckOutDate).ToString("MM/dd/yyyy") + "," + 
              booking.ConvenienceFee + "," + booking.TokenAmount 
              + "," + booking.TokenAmount + "," + (int) booking.state + ")";
            using (var obj = new DBHelper())
            {
                bookingReference=  obj.Insert(bookingSql);
            }

            foreach (var room in booking.rooms)
            {
                var roomSql = "INSERT INTO BookedRooms (BookingID, RoomID) Values (" + bookingReference + "," + room.Id + ")";
                using (var obj = new DBHelper())
                {
                    obj.Insert(roomSql);
                }
            }

            return isBookingSucessFull;
        }

    }
}
