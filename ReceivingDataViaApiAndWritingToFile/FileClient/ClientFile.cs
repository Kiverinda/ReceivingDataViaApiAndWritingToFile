﻿using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace ReceivingDataViaApiAndWritingToFile.FileClient
{
    public class ClientFile : IClientFile
    {
        readonly string path = @"c:\temp\result.txt";
        public event ProgressChangeDelegate OnProgressChanged;

        public ClientFile()
        {
            OnProgressChanged += delegate {  };
        }
        

        public void SaveListToFileAsString(List<Post> list)
        {
            foreach (var post in list)
            {
                if (!File.Exists(path))
                {
                    File.WriteAllText(path, post.ToString());
                    OnProgressChanged?.Invoke(post.Id);
                }
                else
                {
                    File.AppendAllText(path, post.ToString());
                    OnProgressChanged?.Invoke(post.Id);
                }
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