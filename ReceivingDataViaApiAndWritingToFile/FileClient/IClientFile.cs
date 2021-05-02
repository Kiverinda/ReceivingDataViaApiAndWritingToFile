using System.Collections.Generic;

namespace ReceivingDataViaApiAndWritingToFile.FileClient
{
    public delegate void ProgressChangeDelegate(int number);
    public interface IClientFile
    {
        void SaveListToFileAsString(List<Post> list);
        void SaveListToFileAsJson(List<Post> list);
        event ProgressChangeDelegate OnProgressChanged;
    }
}