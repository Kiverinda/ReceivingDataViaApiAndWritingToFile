using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ReceivingDataViaApiAndWritingToFile.ApiClient
{
    public delegate void ProgressChangeDelegate(int number);
    public interface IClientApi
    {
        Task<List<Post>> GetListPosts(CancellationToken cancellationToken);
        Task<Post> GetPost(int number);
        event ProgressChangeDelegate OnProgressChanged;
    }
}