using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.IO;
using RestSharp;
using RestSharp.Extensions;

namespace MeteorologyDownloader.DataRetrieval
{
    public class MeteoConnector : IMeteoConnector
    {
        public void DownloadFile(string endpoint, string destination)
        {
            var client = new RestClient(endpoint);
            var r = new RestRequest();          
            client.DownloadData(r).SaveAs(destination);
        }
    }
}
