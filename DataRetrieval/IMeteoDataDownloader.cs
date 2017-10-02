using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeteorologyDownloader.DataRetrieval
{
    public interface IMeteoDataDownloader
    {
        void LoadRadarData(string baseDir, int stepMinutes, int imagesBeforeCount);
        void LoadTemperatureData(string baseDir);
    }
}
