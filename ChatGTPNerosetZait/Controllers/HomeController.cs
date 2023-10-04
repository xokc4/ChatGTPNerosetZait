using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ChatGTPNerosetZait.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
       public static List<Message> MessagesMain = ClassChatGpt.messages;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [HttpPost]
        public void OnCreateMessage()
        {
            List<Message> messages = new  List<Message>();
            MessagesMain = messages;
     
        }
        [HttpPost]
        public async void OnPost(string user)
        {
           await ClassChatGpt.CreateMessage(user);
         

        }
        public IActionResult RegistrLogin()
        {
            return View();
        }
        public IActionResult ChatGPT()
        {
            return View();
        }
        public IActionResult Index()
        {
            return View(Bd());
        }
        public IActionResult RegistrLogin1()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }
        public static List<Message> Bd()
        {
            List<Message> messages = MessagesMain.ToList();
           return messages;
        }
    }
}