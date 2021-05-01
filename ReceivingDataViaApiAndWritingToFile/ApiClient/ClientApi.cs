using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ReceivingDataViaApiAndWritingToFile.ApiClient
{
    public class ClientApi : IClientApi
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ClientApi(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<List<Post>> GetListPosts(CancellationToken cancellationToken)
        {
            var tasks = new List<Task<Post>>();
            for (var i = 4; i < 14; i++) tasks.Add(GetPost(i));
            await Task.WhenAll(tasks);
            var allposts = new List<Post>();
            foreach (var task in tasks) allposts.Add(await task);
            return allposts;
        }

        public async Task<Post> GetPost(int number)
        {
            var httpClient = _httpClientFactory.CreateClient("JsonplaceholderClient");
            var response = await httpClient.GetAsync($"/posts/{number}");
            return JsonConvert.DeserializeObject<Post>(
                await response.Content.ReadAsStringAsync());
        }
    }
}