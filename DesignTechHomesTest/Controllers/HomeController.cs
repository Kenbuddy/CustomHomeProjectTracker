using System.Diagnostics;
using System.Reflection;
using DesignTechHomesTest.Data;
using DesignTechHomesTest.Models;
using DesignTechHomesTest.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace DesignTechHomesTest.Controllers
{
    [Authorize] // Require authentication globally for this controller
    public class HomeController : Controller
    {
        #region Field Members

        private readonly ApplicationDbContext _context;
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<IdentityUser> _userManager;

        #endregion

        #region Constructors

        public HomeController(ApplicationDbContext context, UserManager<IdentityUser> userManager, ILogger<HomeController> logger)
        {
            _context = context;
            _logger = logger;
            _userManager = userManager;
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

        public async Task<IActionResult> Clients()
        {
            var clients = await _context.Clients.ToListAsync();
            return View(clients);
        }

        [HttpGet]
        public async Task<IActionResult> EditClient(int id)
        {
            var client = await _context.Clients.FindAsync(id);
            if (client == null)
            {
                return NotFound();
            }
          
            return View(client);
        }

        [HttpPost]
        public async Task<IActionResult> EditClient(Client client)
        {
            var user = await _userManager.GetUserAsync(User);

            // Retrieve existing client to preserve CreatedBy and CreatedOn
            var existingClient = await _context.Clients.AsNoTracking().FirstOrDefaultAsync(c => c.Id == client.Id);
            if (existingClient == null)
            {
                return NotFound();
            }

            client.CreatedBy = existingClient.CreatedBy;
            client.CreatedOn = existingClient.CreatedOn;

            client.ModifiedBy = user?.UserName ?? "Unknown";
            client.ModifiedOn = DateTime.Now;

            if (!TryValidateModel(client))
            {
                // Reload clients to pass back to view
                var clients = await _context.Clients.ToListAsync();
                ViewData["Clients"] = clients;

                return View("Clients", clients);
            }

             _context.Update(client);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Clients));
        }

        [HttpGet]
        public async Task<IActionResult> CreateClient()
        {
            var user = await _userManager.GetUserAsync(User);
            var client = new Client
            {
                CreatedBy = user?.UserName ?? "Unknown",
                CreatedOn = DateTime.Now,
                ModifiedBy = user?.UserName ?? "Unknown",
                ModifiedOn = DateTime.Now
            };
            
            return View("EditClient", client);
        }

        [HttpPost]
        public async Task<IActionResult> CreateClient(Client client)
        {
            var user = await _userManager.GetUserAsync(User);
            client.CreatedBy = user?.UserName ?? "Unknown";
            client.CreatedOn = DateTime.Now;
            client.ModifiedBy = user?.UserName ?? "Unknown";
            client.ModifiedOn = DateTime.Now;

            if (!TryValidateModel(client))
            {
                DiagnosticUtils.GetModelStateErrors(this, nameof(CreateClient));

                // Reload clients to pass back to view
                var clients = await _context.Clients.ToListAsync();
                ViewData["Clients"] = clients;

                return View("Clients", clients);
            }

            _context.Add(client);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Clients));
        }

        [HttpPost]
        public async Task<IActionResult> DeleteClient(int id)
        {
            var client = await _context.Clients.FindAsync(id);
            if (client != null)
            {
                _context.Clients.Remove(client);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Clients));
        }

        #endregion

        #region Projects Page

        public async Task<IActionResult> Projects()
        {
            var projects = await _context.Projects.Include(p => p.Client).ToListAsync();
            return View(projects);
        }

        [HttpGet]
        public async Task<IActionResult> EditProject(int id)
        {
            var project = await _context.Projects.FindAsync(id);
            if (project == null)
            {
                return NotFound();
            }

            // Supply the SelectList for the Client dropdown
            var clients = await _context.Clients
                                    .OrderBy(c => c.LastName)
                                    .ThenBy(c => c.FirstName)
                                    .ToListAsync();
            ViewData["Clients"] = new SelectList(clients, "Id", "FullName");

            return View(project);
        }

        [HttpPost]
        public async Task<IActionResult> EditProject(Project project)
        {
            var user = await _userManager.GetUserAsync(User);

            // Retrieve existing client to preserve CreatedBy and CreatedOn
            var existingProject = await _context.Projects.AsNoTracking().FirstOrDefaultAsync(c => c.Id == project.Id);
            if (existingProject == null)
            {
                return NotFound();
            }

            project.CreatedBy = existingProject.CreatedBy;
            project.CreatedOn = existingProject.CreatedOn;

            project.ModifiedBy = user?.UserName ?? "Unknown";
            project.ModifiedOn = DateTime.Now;

            if (!TryValidateModel(project))
            {
                DiagnosticUtils.GetModelStateErrors(this, nameof(EditProject));

                // Reload projects to pass back to view
                var projects = await _context.Projects.Include(p => p.Client).ToListAsync();
                ViewData["Projects"] = projects;

                return View("Projects", projects);
            }

            _context.Update(project);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Projects));
        }

        [HttpGet]
        public async Task<IActionResult> CreateProject()
        {
            // Must have a client defined first.
            if (!_context.Clients.Any())
            {
                TempData["NoClientsMessage"] = "No clients available. Please add a client before creating a project.";
                return RedirectToAction(nameof(Projects));
            }

            var user = await _userManager.GetUserAsync(User);
            var project = new Project
            {
                CreatedBy = user?.UserName ?? "Unknown",
                CreatedOn = DateTime.Now,
                ModifiedBy = user?.UserName ?? "Unknown",
                ModifiedOn = DateTime.Now,
                Status = ProjectStatus.NotStarted,
                StartDate = DateTime.Today
            };

            // Supply the SelectList for the Client dropdown
            var clients = await _context.Clients
                                    .OrderBy(c => c.LastName)
                                    .ThenBy(c => c.FirstName)
                                    .ToListAsync();
            ViewData["Clients"] = new SelectList(clients, "Id", "FullName");
            return View("EditProject", project);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProject(Project project)
        {
            var user = await _userManager.GetUserAsync(User);
            project.CreatedBy = user?.UserName ?? "Unknown";
            project.CreatedOn = DateTime.Now;
            project.ModifiedBy = user?.UserName ?? "Unknown";
            project.ModifiedOn = DateTime.Now;

            if (!TryValidateModel(project))
            {
                DiagnosticUtils.GetModelStateErrors(this, nameof(CreateProject));

                // Reload projects to pass back to view
                var projects = await _context.Projects.ToListAsync();
                ViewData["Projects"] = projects;

                return View("Projects", projects);
            }

            _context.Add(project);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Projects));
        }

        [HttpPost]
        public async Task<IActionResult> DeleteProject(int id)
        {
            var project = await _context.Projects.FindAsync(id);
            if (project != null)
            {
                _context.Projects.Remove(project);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Projects));
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
