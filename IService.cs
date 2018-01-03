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
        [WebInvoke( Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "SaveProfile/")]
        string SaveUserProfile(UserProfile userProfile);

        [WebGet(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "GetDharamshalaByCity/{cityName}")]
        string GetDharamshlaByCity(string  cityName);
    }
}
