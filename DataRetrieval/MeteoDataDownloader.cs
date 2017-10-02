using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeteorologyDownloader.DataRetrieval
{
    public class MeteoDataDownloader : IMeteoDataDownloader
    {
        private INearestMinutesEstimator _nearestMinutesEstimator;
        private IRadarTilesDownloader _radarTilesDownloader;
        private ITemperatureTilesDownloader _temperatureTilesDownloader;

        public MeteoDataDownloader(
            INearestMinutesEstimator nearestMinutesEstimator,
            IRadarTilesDownloader radarTilesDownloader
            )
        {
            _nearestMinutesEstimator = nearestMinutesEstimator;
            _radarTilesDownloader = radarTilesDownloader;
        }

        public void LoadRadarData(string baseDir, int stepMinutes, int imagesBeforeCount)
        {
            var nearestMinMark = _nearestMinutesEstimator.RoundToMinutes(stepMinutes, DateTime.UtcNow);
            var nextTime = nearestMinMark;
            for (var i = 0; i < imagesBeforeCount; i++)
            {
                var forTime = nextTime.AddMinutes(-i * stepMinutes);
                _radarTilesDownloader.LoadAndSaveRadarForTime(baseDir, forTime);
            }
        }

        public void LoadTemperatureData(string baseDir)
        {
            var nearestTime = _nearestMinutesEstimator.RoundToHours(DateTime.UtcNow);
            _temperatureTilesDownloader.LoadAndSaveTemperatureForTime(nearestTime);
        }
    }
}
