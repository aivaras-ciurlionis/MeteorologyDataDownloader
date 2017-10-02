using System;

namespace MeteorologyDownloader.DataRetrieval
{
    public interface IRadarTilesDownloader
    {
        void LoadAndSaveRadarForTime(string baseDir, DateTime time);
    }
}