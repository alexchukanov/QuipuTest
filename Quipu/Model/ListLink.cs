using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace Quipu.Model
{
    public class LinkList
    {        
        [JsonProperty("data")]
        public List<Link> Data
        {
            get;
            set;
        }
     }     
}
