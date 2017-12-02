using Quipu.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quipu.Model
{
    public interface IDataService
    {   
        void CountLinkTag(Action<DataItemCountTag, Exception> callback, string link, string tag);
        void LoadLink(Action<DataItemLink, Exception> callback);
    }
}
