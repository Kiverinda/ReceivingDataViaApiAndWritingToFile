using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using ReceivingDataViaApiAndWritingToFile.ApiClient;
using ReceivingDataViaApiAndWritingToFile.FileClient;

namespace ReceivingDataViaApiAndWritingToFile
{
    public class App : IHostedService
    {
        private readonly IClientApi _clientApi;
        private readonly IClientFile _clientFile;

        public App(IClientApi clientApi, IClientFile clientFile)
        {
            _clientApi = clientApi;
            _clientFile = clientFile;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            _clientApi.OnProgressChanged += ViewGetPost;
            var posts = await _clientApi.GetListPosts(cancellationToken);
            _clientFile.OnProgressChanged += ViewWritePost;
            _clientFile.SaveListToFileAsString(posts);
           // _clientFile.SaveListToFileAsJson(posts);
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        private void ViewGetPost(int number)
        {
            Console.WriteLine($"Post {number} ..... Get Ok");   
        }
        
        private void ViewWritePost(int number)
        {
            Console.WriteLine($"Post {number} ..... Write Ok");   
        }
    }
}