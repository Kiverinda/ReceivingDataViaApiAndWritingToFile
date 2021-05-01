using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace ReceivingDataViaApiAndWritingToFile.FileClient
{
    public class ClientFile : IClientFile
    {
        readonly string path = @"c:\temp\result.txt";

        public void SaveListToFileAsString(List<Post> list)
        {
            if (!File.Exists(path))
            {
                foreach (var post in list)
                {
                    File.WriteAllText(path, post.ToString());
                }
            }
            foreach (var post in list)
            {
                File.AppendAllText(path, post.ToString());
            }
        }

        public void SaveListToFileAsJson(List<Post> list)
        {
            string json = JsonConvert.SerializeObject(list, Formatting.Indented);
            
            if (!File.Exists(path))
            {
                File.WriteAllText(path, json);
            }
            File.AppendAllText(path, json);
        }
    }
}