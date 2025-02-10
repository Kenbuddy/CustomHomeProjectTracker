using DesignTechHomesTest.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesignTechHomesTest.Data.RestApi
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        #region Field Members

        private readonly IDbRepository _dbRepository;

        #endregion

        #region Constructor

        public ProjectsController(IDbRepository dbRepository)
        {
            _dbRepository = dbRepository;
        }

        #endregion

        #region Actions

        [HttpGet]
        public async Task<IActionResult> GetAllProjects()
        {
            var projects = await _dbRepository.GetAllProjectsAsync();
            return Ok(projects);
        }

        [HttpGet("start-date-filter")]
        public async Task<IActionResult> GetProjectsByStartDate([FromQuery] DateTime? startDateFrom, [FromQuery] DateTime? startDateTo)
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

            return Ok(projects);
        }

        #endregion
    }
}
