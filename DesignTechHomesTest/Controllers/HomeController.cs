using System.Diagnostics;
using DesignTechHomesTest.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DesignTechHomesTest.Controllers
{
    [Authorize] // Require authentication globally for this controller
    public class HomeController : Controller
    {
        #region Field Members

        private readonly ILogger<HomeController> _logger;

        #endregion

        #region Constructors

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        #endregion

        #region Pages

        #region Home Page

        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        #endregion

        #region Clients Page

        public IActionResult Clients()
        {
            return View();
        }

        #endregion

        #region Projects Page

        public IActionResult Projects()
        {
            return View();
        }

        #endregion

        #region Dashboard Page

        public IActionResult Dashboard()
        {
            return View();
        }

        #endregion

        #region About Page

        public IActionResult About()
        {
            return View();
        }

        #endregion

        #region Other Pages

        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        #endregion

        #endregion Pages
    }
}
