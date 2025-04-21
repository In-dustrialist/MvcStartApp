using Microsoft.EntityFrameworkCore;
using YourProjectNamespace.Data;
using YourProjectNamespace.Models.Db;

public class BlogRepository : IBlogRepository
{
    private readonly BlogContext _context;

    public BlogRepository(BlogContext context)
    {
        _context = context;
    }

    public async Task AddUser(User user)
    {
        if (_context.Entry(user).State == EntityState.Detached)
            await _context.Users.AddAsync(user);

        await _context.SaveChangesAsync();
    }

    public async Task<User[]> GetUsers()
    {
        return await _context.Users.ToArrayAsync();
    }
}
