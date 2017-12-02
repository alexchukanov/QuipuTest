using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quipu.Model
{
    class DataItem
    {
    }

    public class DataItemCountTag
    {
        public DataItemCountTag(int countTag)
        {
            CountTag = countTag;
        }

        public int CountTag
        {
            get;
            private set;
        }
    }

    public class DataItemLink
    {
        public DataItemLink(string link)
        {
            Link = link;
        }

        public string Link
        {
            get;
            private set;
        }
    }
}
