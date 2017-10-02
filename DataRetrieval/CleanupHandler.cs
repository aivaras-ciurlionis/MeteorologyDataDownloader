using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MeteorologyDownloader.DataRetrieval
{
    public class CleanupHandler : ICleanupHandler
    {
        public void RemoveDirectory(string directoryPath)
        {
            Directory.Delete(directoryPath, true);
        }

        public void RemoveFile(string filePath)
        {
            File.Delete(filePath);
        }
    }
}
