using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeteorologyDownloader.DataRetrieval
{
    public interface IMeteoConnector
    {
        void DownloadFile(string endpoint, string destination);
    }
}
