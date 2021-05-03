using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ReceivingDataViaApiAndWritingToFile.ApiClient;
using ReceivingDataViaApiAndWritingToFile.FileClient;

namespace ReceivingDataViaApiAndWritingToFile
{
    public class App : IHostedService
    {
        private readonly IClientApi _clientApi;
        private readonly IClientFile _clientFile;
        private readonly ILogger<App> _logger;
        public App(IClientApi clientApi, IClientFile clientFile, ILogger<App> logger)
        {
            _clientApi = clientApi;
            _clientFile = clientFile;
            _logger = logger;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            try
            {
                _clientApi.OnProgressChanged += ViewGetPost;
                var posts = await _clientApi.GetListPosts(cancellationToken);
                _clientFile.OnProgressWriteChanged += ViewWritePost;
                _clientFile.SaveListToFileAsString(posts);
                // _clientFile.SaveListToFileAsJson(posts);
              //  _logger.Log(LogLevel.Info, " Ok Test");
            }
            catch (Exception e)
            {
              //  _logger.Log(LogLevel.Info, e, "Exception Test");
                Console.WriteLine(e);
                throw;
            }
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