using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ServicesSport
{
    [DataContract]
    public class ManagePlayers
    { 
        [DataMember]
        public List<Player> Players { get; set; }
    }
}