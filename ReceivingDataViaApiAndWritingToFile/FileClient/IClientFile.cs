using System.Collections.Generic;

namespace ReceivingDataViaApiAndWritingToFile.FileClient
{
    public interface IClientFile
    {
        void SaveListToFileAsString(List<Post> list);
        void SaveListToFileAsJson(List<Post> list);
    }
}