using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ServicesSport
{
    [DataContract]
    public class Data
    {
        [DataMember]
        public int Rank { get; set; }
        [DataMember]
        public int Points { get; set; }
        [DataMember]
        public int Weight { get; set; }
        [DataMember]
        public int Height { get; set; }
        [DataMember]
        public int Age { get; set; }
        [DataMember]
        public List<int> Last { get; set; }
    }
}