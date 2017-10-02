using System;

namespace MeteorologyDownloader.DataRetrieval
{
    public interface ITemperatureTilesDownloader
    {
        void LoadAndSaveTemperatureForTime(DateTime nearestTime);
    }
}