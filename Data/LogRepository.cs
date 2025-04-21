using Microsoft.EntityFrameworkCore;
using YourProjectNamespace.Models.Db;

namespace YourProjectNamespace.Data
{
    public class LogRepository : ILogRepository
    {
        private readonly BlogContext _context;

        public LogRepository(BlogContext context)
        {
            _context = context;
        }

        public async Task LogRequest(Request request)
        {
            await _context.Requests.AddAsync(request);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Request>> GetAllAsync()
        {
            return await _context.Requests
                                 .OrderByDescending(r => r.Date)
                                 .ToListAsync();
        }
    }
}
