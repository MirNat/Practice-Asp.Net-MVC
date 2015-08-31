using PhotoAlbum.DAL.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhotoAlbum.PL.Controllers
{
    public class HomeController : Controller
    {
        private IApplicationUserRepository userRepository;
        private ICategoryRepository categoryRepository;
        /// <summary>
        /// Inject user repository in controller
        /// </summary>
        public HomeController(IApplicationUserRepository userRepository, 
            ICategoryRepository categoryRepository)
        {
            this.userRepository = userRepository;
            this.categoryRepository = categoryRepository;
        }

        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated) {
                return View("Authorized");
            }
            return View("~/Views/Account/Login.cshtml");
        }


        [Authorize]
        public ActionResult Authorized()
        {
            return View();
        }
 
        public ActionResult About()
        {
            //ViewBag.Message = "Your application description page.";
            //var users = userRepository.GetAll();
            //var categories = categoryRepository.GetAll();
            return PartialView();//categories);//users);
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}