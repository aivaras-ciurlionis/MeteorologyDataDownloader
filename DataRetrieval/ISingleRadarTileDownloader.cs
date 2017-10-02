using System;

namespace MeteorologyDownloader.DataRetrieval
{
    public interface ISingleRadarTileDownloader
    {
        void DownloadTile(DateTime time, int x, int y, string downloadPath);
    }
}