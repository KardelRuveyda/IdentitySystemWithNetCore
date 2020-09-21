using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentitySystemWithNetCore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdentitySystemWithNetCore.Controllers
{
    public class AdminController : Controller
    {
        private UserManager<AppUser> userManager { get; }

        //dependcy injection sayesinde yapıldı.
        //Interface ile de doldurulabilirdi.
        public AdminController(UserManager<AppUser> userManager)
        {
            this.userManager = userManager;
        }
        public IActionResult Index()
        {
            return View(userManager.Users.ToList());
        }
    }
}
