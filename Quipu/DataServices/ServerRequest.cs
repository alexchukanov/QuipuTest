using Quipu.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net.Http;

namespace Quipu.DataServices
{
    class ServerRequest
    {
        public static async Task<string> GetlinkContent(string link)
        {
            string response = await SendRequest(link);

            return response;
        }

        private static async Task<string> SendRequest(string link)
        {
            string response = null;

            using (HttpClient client = new HttpClient())
            {

                try
                {
                    response = await client.GetStringAsync(String.Format("http://{0}", link));
                    
                }
                catch (Exception)
                {
                    throw new Exception("Link reading error!");
                }
            }

            return response;
        }
    }
}
