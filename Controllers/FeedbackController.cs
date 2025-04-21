using Microsoft.AspNetCore.Mvc;
using MvcStartApp.Models;
using MvcStartApp.Models.Db;
using System.Diagnostics;

namespace MvcStartApp.Controllers
{
    public class FeedbackController : Controller
    {
        /// <summary>
        /// Возвращает страницу с формой отзывов
        /// </summary>
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        /// <summary>
        /// Обрабатывает AJAX-запрос с отзывом
        /// </summary>
        [HttpPost]
        public IActionResult Add(Feedback feedback)
        {
            if (string.IsNullOrWhiteSpace(feedback.From) || string.IsNullOrWhiteSpace(feedback.Text))
            {
                return BadRequest("Пожалуйста, заполните все поля.");
            }

            return StatusCode(200, $"{feedback.From}, спасибо за отзыв!");
        }

        /// <summary>
        /// Метод для отображения ошибок
        /// </summary>
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
