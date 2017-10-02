namespace MeteorologyDownloader.DataRetrieval
{
    internal interface IStorageUplader
    {
        void UploadFileToImageStorage(string filePath);
    }
}