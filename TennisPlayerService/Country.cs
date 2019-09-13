using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ServicesSport
{
    [DataContract]
    public class Country
    {
        [DataMember]
        public string Picture { get; set; }
        [DataMember]
        public string Code { get; set; }
    }
}