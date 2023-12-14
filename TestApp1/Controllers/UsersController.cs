using Microsoft.AspNetCore.Mvc;
using TestApp1.Models;
using TestApp1.Services;

namespace TestApp1.Controllers
{
    public class UsersController : Controller
    {
        private readonly IRegisterService _registerService;
        public UsersController(IRegisterService registerService){
            _registerService = registerService;
            }

        public IActionResult Index()
        {
            var result = _registerService.FetchAll();
            return View("List",  result);
        }

        public IActionResult Create() 
        {
            return View("AddUser");
        }

        public IActionResult AddUser(UserModel User)
        {
            _registerService.Adduser(User);
            return Index();
        }
    }
}
