namespace MeteorologyDownloader.DataRetrieval
{
    public interface ICleanupHandler
    {
        void RemoveDirectory(string directoryPath);
        void RemoveFile(string filePath);
    }
}