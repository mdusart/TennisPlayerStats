using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ServicesSport
{
    [ServiceContract]
    public interface ITennisPlayerService
    {

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate="/Players", ResponseFormat =WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        List<Player> GetData();

        [OperationContract]
        [WebInvoke(Method = "GET",UriTemplate = "/Player/{id}", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        Player GetPlayer(string id);

        [OperationContract]
        [WebInvoke(Method="DELETE",UriTemplate = "/Player/{id}", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        void DeletePlayer(string id);
    }
    
}
