using System;

namespace MeteorologyDownloader.DataRetrieval
{
    public interface INearestMinutesEstimator
    {
        DateTime RoundToMinutes(int step, DateTime fromTime);
        DateTime RoundToHours(DateTime utcNow);
    }
}