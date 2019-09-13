using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ServicesSport
{
    [DataContract]
    public class Player
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public string ShortName { get; set; }
        [DataMember]
        public string Sex { get; set; }
        [DataMember]
        public Country Country { get; set; }
        [DataMember]
        public string Picture { get; set; }
        [DataMember]
        public Data Data { get; set; }
    }
}