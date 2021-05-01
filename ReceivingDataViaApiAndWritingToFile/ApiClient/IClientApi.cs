using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ReceivingDataViaApiAndWritingToFile.ApiClient
{
    public interface IClientApi
    {
        Task<List<Post>> GetListPosts(CancellationToken cancellationToken);
        Task<Post> GetPost(int number);
    }
}