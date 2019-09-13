using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web;
using System.Web.Http;

namespace ServicesSport
{
    public class TennisPlayerService : ITennisPlayerService
    {
        private ManagePlayers _managerPlayers;

        public TennisPlayerService()
        {
            string json = new WebClient().DownloadString("https://eurosportdigital.github.io/eurosport-csharp-developer-recruitment/headtohead.json");
            _managerPlayers = JsonConvert.DeserializeObject<ManagePlayers>(json);
        }

        public List<Player> GetData()
        {
            return _managerPlayers.Players.OrderBy(p => p.Id).ToList();
        }

        public Player GetPlayer(string id)
        {
            Player item = null;
            try
            {
                int idPlayer;               

                if (!int.TryParse(id, out idPlayer))
                {
                    throw new HttpResponseException(HttpStatusCode.BadRequest);
                }
                
                item = _managerPlayers.Players.FirstOrDefault(p => p.Id == idPlayer);

                if (item == null)
                {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                }
            }
            catch(HttpResponseException e)
            {
                WebOperationContext.Current.OutgoingResponse.StatusCode = e.Response.StatusCode;
            }

            return item;         
        }

        public void DeletePlayer(string id)
        {
            try
            {


                int idPlayer;

                if (!int.TryParse(id, out idPlayer))
                {
                    throw new HttpResponseException(HttpStatusCode.BadRequest);
                }

                if (!_managerPlayers.Players.Any(p => p.Id == idPlayer))
                {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                }

                _managerPlayers.Players.RemoveAll(p => p.Id.ToString() == id);
            }
            catch(HttpResponseException e)
            {
                WebOperationContext.Current.OutgoingResponse.StatusCode = e.Response.StatusCode;
            }
        }
    }
}
