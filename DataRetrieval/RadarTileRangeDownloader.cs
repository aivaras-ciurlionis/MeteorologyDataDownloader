using System;
using System.IO;

namespace MeteorologyDownloader.DataRetrieval
{
    public class RadarTileRangeDownloader : IRadarTileRangeDownloader
    {
        private ISingleRadarTileDownloader _singleRadarTileDownloader;

        public RadarTileRangeDownloader(
            ISingleRadarTileDownloader singleRadarTileDownloader
            )
        {
            _singleRadarTileDownloader = singleRadarTileDownloader;
        }

        public void DownloadTiles(DateTime time, int startColumn, int endColumn, int startRow, int endRow, string destinationDirectory)
        {
            Directory.CreateDirectory(destinationDirectory);
            var n = 0;
            for(var x = startColumn; x <= endColumn; x++)
            {
                for(var y = startRow; y <= endRow; y++)
                {
                    _singleRadarTileDownloader.DownloadTile(time, x, y, Path.Combine(destinationDirectory, $"{n}.png"));
                    n++;
                }
            }
        }
    }
}
