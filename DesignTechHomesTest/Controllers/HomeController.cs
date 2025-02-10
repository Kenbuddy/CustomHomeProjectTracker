using DesignTechHomesTest.Interfaces;
using DesignTechHomesTest.Models;
using DesignTechHomesTest.Utilities;
using DesignTechHomesTest.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net.Http;

namespace DesignTechHomesTest.Controllers
{
    [Authorize] // Require authentication globally for this controller
    public class HomeController : Controller
    {
        #region Field Members

        private IDbRepository _dbRepository;
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly HttpClient _httpClient;

        #endregion

        #region Constructors

        public HomeController(IDbRepository dbRepository, UserManager<IdentityUser> userManager, ILogger<HomeController> logger, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _userManager = userManager;
            _dbRepository = dbRepository;
            _httpClient = httpClientFactory.CreateClient();
        }

        #endregion

        #region Pages

        #region Home Page

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var projects = await _dbRepository.GetAllProjectsAsync();

            var groupedProjects = projects.GroupBy(p => p.Status).OrderBy(g => g.Key);
            return View(groupedProjects);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        #endregion

        #region Clients Page

        public async Task<IActionResult> Clients()
        {
            var clients = await _dbRepository.GetAllClientsAsync();
            return View(clients);
        }

        [HttpGet]
        public async Task<IActionResult> EditClient(int id)
        {
            var client = await _dbRepository.GetClientAsync(id);
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
            var existingClient = await _dbRepository.GetClientNoTrackingAsync(client.Id);
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
                var clients = await _dbRepository.GetAllClientsAsync();
                ViewData["Clients"] = clients;

                return View("Clients", clients);
            }

            await _dbRepository.UpdateClientAsync(client);
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
                var clients = await _dbRepository.GetAllClientsAsync();
                ViewData["Clients"] = clients;

                return View("Clients", clients);
            }

            await _dbRepository.AddClientAsync(client);
            return RedirectToAction(nameof(Clients));
        }

        [HttpPost]
        public async Task<IActionResult> DeleteClient(int id)
        {
            await _dbRepository.DeleteClientAsync(id);
            return RedirectToAction(nameof(Clients));
        }

        #endregion

        #region Projects Page

        public async Task<IActionResult> Projects()
        {
            var projects = await GetProjectsFromApiAsync();
            //var projects = await _dbRepository.GetAllProjectsAsync();
            return View(projects);
        }

        private async Task<IEnumerable<Project>> GetProjectsFromApiAsync()
        {
            var response = await _httpClient.GetAsync("https://localhost:7152/api/Projects");
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();
            var projects = JsonConvert.DeserializeObject<IEnumerable<Project>>(responseString);
            return projects ?? new List<Project>();
        }

        [HttpGet]
        public async Task<IActionResult> EditProject(int id)
        {
            var project = await _dbRepository.GetProjectAsync(id);
            if (project == null)
            {
                return NotFound();
            }

            // Supply the SelectList for the Client dropdown
            var clients = await _dbRepository.GetAllClientsAsync();
                                    
            ViewData["Clients"] = new SelectList(clients, "Id", "FullName");

            return View(project);
        }

        [HttpPost]
        public async Task<IActionResult> EditProject(Project project)
        {
            var user = await _userManager.GetUserAsync(User);

            // Retrieve existing client to preserve CreatedBy and CreatedOn
            var existingProject = await _dbRepository.GetProjectNoTrackingAsync(project.Id);
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
                var projects = await _dbRepository.GetAllProjectsAsync();
                ViewData["Projects"] = projects;

                return View("Projects", projects);
            }

            await _dbRepository.UpdateProjectAsync(project);
            return RedirectToAction(nameof(Projects));
        }

        [HttpGet]
        public async Task<IActionResult> CreateProject()
        {
            // Must have a client defined first.
            var hasClients = await _dbRepository.HasClientsAsync();
            if (!hasClients)
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
            var clients = await _dbRepository.GetAllClientsAsync();
                                  
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
                var projects = await _dbRepository.GetAllProjectsAsync();
                ViewData["Projects"] = projects;

                return View("Projects", projects);
            }

            await _dbRepository.AddProjectAsync(project);
            return RedirectToAction(nameof(Projects));
        }

        [HttpPost]
        public async Task<IActionResult> DeleteProject(int id)
        {
            await _dbRepository.DeleteProjectAsync(id);
            return RedirectToAction(nameof(Projects));
        }

        #endregion

        #region Dashboard Page

        [Authorize]
        public async Task<IActionResult> Dashboard(DateTime? startDateFrom, DateTime? startDateTo)
        {
            var projects = await _dbRepository.GetAllProjectsAsync();

            if (startDateFrom.HasValue)
            {
                projects = projects.Where(p => p.StartDate >= startDateFrom.Value);
            }

            if (startDateTo.HasValue)
            {
                projects = projects.Where(p => p.StartDate <= startDateTo.Value);
            }

            var groupedProjects = projects
                .GroupBy(p => p.Status)
                .Select(g => new StatusGroupViewModel
                {
                    Status = g.Key.GetDescription(),
                    Projects = g
                });

            var model = new ProjectGridViewModel
            {
                StartDateFrom = startDateFrom,
                StartDateTo = startDateTo,
                GroupedProjects = groupedProjects
            };

            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                return PartialView("_ProjectGrid", model);
            }
            else
            {
                return View(model);
            }
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
