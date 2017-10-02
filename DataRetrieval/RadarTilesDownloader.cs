using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MeteorologyDownloader.DataRetrieval
{
    public class RadarTilesDownloader : IRadarTilesDownloader
    {
        private IRadarTileRangeDownloader _radarTileRangeDownloader;
        private IImagesConcater _imagesConcater;
        private IStorageUplader _storageUploader;
        private ICleanupHandler _cleanupHandler;

        public RadarTilesDownloader(
            IRadarTileRangeDownloader radarTileRangeDownloader,
            IImagesConcater imagesConcater,
            ICleanupHandler cleanupHandler
            )
        {
            _radarTileRangeDownloader = radarTileRangeDownloader;
            _imagesConcater = imagesConcater;
            _cleanupHandler = cleanupHandler;            
        }

        const int startColumn = 71;
        const int endColumn = 73;

        const int startRow = 39;
        const int endRow = 41;

        public void LoadAndSaveRadarForTime(string baseDir, DateTime time)
        {
            var workingDirectory = Path.Combine(baseDir, time.ToString("yyyy-dd-M--HH-mm-ss"));
            var resultFile = Path.Combine(baseDir, time.ToString("yyyy-dd-M--HH-mm-ss") + ".png");
            _radarTileRangeDownloader.DownloadTiles(time, startColumn, endColumn, startRow, endRow, workingDirectory);
            _imagesConcater.ConcatImagesInDirectory(workingDirectory, resultFile);
            // _storageUploader.UploadFileToImageStorage(resultFile);
           // _cleanupHandler.RemoveDirectory(workingDirectory);
           // _cleanupHandler.RemoveFile(resultFile);
        }

    }
}
