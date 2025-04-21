using YourProjectNamespace.Models.Db;

namespace YourProjectNamespace.Data
{
    public interface IBlogRepository
    {
        Task<User[]> GetUsers();
        Task AddUser(User user);
    }
}
