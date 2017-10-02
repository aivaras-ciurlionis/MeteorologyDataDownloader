using System;

namespace MeteorologyDownloader.DataRetrieval
{
    public interface IRadarTileRangeDownloader
    {
        void DownloadTiles(DateTime time, int startColumn, int endColumn, int startRow, int endRow, string destinationDirectory);
    }
}