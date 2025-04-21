
using YourProjectNamespace.Models.Db;

namespace YourProjectNamespace.Data
{
    public interface ILogRepository
    {
        Task LogRequest(Request request);

        Task<IEnumerable<Request>> GetAllAsync();
    }
}
