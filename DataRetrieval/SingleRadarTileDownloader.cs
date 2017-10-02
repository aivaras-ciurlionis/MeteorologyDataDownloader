using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeteorologyDownloader.DataRetrieval
{
    public class SingleRadarTileDownloader : ISingleRadarTileDownloader
    {
        private IMeteoConnector _meteoConnector;

        public SingleRadarTileDownloader(
            IMeteoConnector meteoConnector
            )
        {
            _meteoConnector = meteoConnector;
        }

        public void DownloadTile(DateTime time, int x, int y, string downloadPath)
        {
            var formedTime = time.ToString("yyyy-MM-ddTHH:mm:ssZ");
            var url = "http://www.meteo.lt/mapsfree?" +
                "&SERVICE=WMS" +
                "&VERSION=1.3.0" +
                "&REQUEST=GetGTile" +
                "&CRS=EPSG:900913" +
                $"&TILEZOOM=7&TILEROW={y}" +
                $"&TILECOL={x}&TRANSPARENT=true" +
                "&DPI=72" +
                "&LAYER=NP2_radar" +
                "&TIMESTAMP=0" +
                $"&time={formedTime}" +
                "&DIM_=";

            _meteoConnector.DownloadFile(url, downloadPath);
        }
    }
}
