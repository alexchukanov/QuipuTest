using Quipu.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Text.RegularExpressions;
using Microsoft.Win32;
using System.IO;

using Quipu.Utils;
using System.Threading;

namespace Quipu.DataServices
{
    public class DataService : IDataService
    {
        string linkContent = null;
       

        public async void CountLinkTag(Action<DataItemCountTag, Exception> callback, string link, string tag)
        {
            int countTag = 0;
            Exception errorEx = null;

            try
            {   
                linkContent = await ServerRequest.GetlinkContent(link);

                //make a delay
                linkContent = await ServerRequest.GetlinkContent(link);
                linkContent = await ServerRequest.GetlinkContent(link);
                linkContent = await ServerRequest.GetlinkContent(link);
                linkContent = await ServerRequest.GetlinkContent(link);
                linkContent = await ServerRequest.GetlinkContent(link);
                linkContent = await ServerRequest.GetlinkContent(link);
                linkContent = await ServerRequest.GetlinkContent(link);
                linkContent = await ServerRequest.GetlinkContent(link);
                linkContent = await ServerRequest.GetlinkContent(link);
                linkContent = await ServerRequest.GetlinkContent(link);
                linkContent = await ServerRequest.GetlinkContent(link);
                linkContent = await ServerRequest.GetlinkContent(link);
                linkContent = await ServerRequest.GetlinkContent(link);
                linkContent = await ServerRequest.GetlinkContent(link);
                               
                Regex newReg = new Regex("<" + tag);
                MatchCollection matches = newReg.Matches(linkContent);

                countTag = matches.Count;

            }
            catch (Exception ex)
            {
                errorEx = ex;
            }

            var item = new DataItemCountTag(countTag);

            callback(item, errorEx);
        }

        public string ReadFilePath()
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.DefaultExt = ".txt";
            dlg.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            
            string path = System.Environment.CurrentDirectory;
            string fileName = "TestData.txt";

            if (dlg.ShowDialog() == true)
            {
                path = dlg.FileName;
                fileName = dlg.SafeFileName;
            }
            else
            {
                throw( new Exception("Select file TestData.txt"));
            }

            return path;
        }

        public async void LoadLink(Action<DataItemLink, Exception> callback)
        {
            string link = "";
            Exception errorEx = null;

            try
            {
                string path = ReadFilePath();

                using (var streamReader = new StreamReader(path, Encoding.UTF8))
                {
                    //link = streamReader.ReadLine() ?? "empty";
                     link = await streamReader.ReadLineAsync() ?? "empty";                    
                }

                if (!Util.IsUrlValid(link))
                {
                    errorEx = new Exception(String.Format("Bad link: {0}", link ));                    
                }

            }
            catch (Exception ex)
            {
                errorEx = ex;
            }

            var item = new DataItemLink(link);
            callback(item, errorEx);
        }
    }        
}
