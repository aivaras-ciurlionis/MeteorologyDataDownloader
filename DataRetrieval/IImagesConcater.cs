namespace MeteorologyDownloader.DataRetrieval
{
    public interface IImagesConcater
    {
        void ConcatImagesInDirectory(string directory, string outputFile);
    }
}