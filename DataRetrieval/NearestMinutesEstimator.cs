using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeteorologyDownloader.DataRetrieval
{
    public class NearestMinutesEstimator : INearestMinutesEstimator
    {
        public DateTime RoundToHours(DateTime time)
        {
            return new DateTime(time.Year, time.Month, time.Day, time.Hour, 0, 0, time.Kind);
        }

        public DateTime RoundToMinutes(int step, DateTime time)
        {
            var minutes = time.Minute;
            var passedMinuteIntervals = minutes / step;
            var roundedMinutes = step * passedMinuteIntervals;
            var tempTime = new DateTime(time.Year, time.Month, time.Day, time.Hour, roundedMinutes, 0, time.Kind);
            return tempTime.AddMinutes(-3 * step);
        }
    }
}
