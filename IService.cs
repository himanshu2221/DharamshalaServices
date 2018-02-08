using DharamshalaServices.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace DharamshalaServices
{
    [ServiceContract]
    public interface IService
    {
        [OperationContract]
        [WebInvoke( Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "SaveProfile/")]
        void SaveUserProfile(UserProfile userProfile);

        [WebGet(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "GetAllDharamshala/")]
        List<DharamshalaDetails> GetAllDharamshala();

        [WebGet(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "GetDharamshalaByCity/{cityId}")]
        List<DharamshalaDetails> GetDharamshalaByCity(string  cityId);

        [WebGet(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "GetAllCities/")]
        List<City> GetAllCities();

        [WebGet(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "GetCitiesByState/{StateId}")]
        List<City> GetCitiesByState(string StateId);

        [WebGet(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "GetStates/")]
        List<State> GetStates();

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "Authenticate/")]
        bool Authenticate(Authenticate loginInfo);

        [WebGet(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, 
            BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "GetRoomsByDharamshala/{dharamshalaId}")]
        List<Room> GetRoomsByDharamshala(string dharamshalaId);

        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "Book/")]
        bool Book(Booking userProfile);
    }
}
