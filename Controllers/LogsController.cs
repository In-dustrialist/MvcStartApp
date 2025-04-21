using Microsoft.AspNetCore.Mvc;
using YourProjectNamespace.Data;


namespace YourProjectNamespace.Controllers
{
    public class LogsController : Controller
    {
        private readonly ILogRepository _logRepository;

        public LogsController(ILogRepository logRepository)
        {
            _logRepository = logRepository;
        }

        public async Task<IActionResult> Index()
        {
            var logs = await _logRepository.GetAllAsync();
            return View(logs);
        }
    }
}
