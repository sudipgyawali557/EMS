using EmployeeManagement.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult About()
        {
            return View();
        }
        public ViewResult MainPage()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();

        }
     
       
        public ViewResult Create()
        {
            return View();
        }
        public ViewResult Display()
        {
            return View();
        }
        public ViewResult Details()
        {
            return View();
        }
        public ViewResult Departments()
        {
            return View();
        }
    }
}
