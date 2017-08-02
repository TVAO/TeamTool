using System;
using System.Collections.Generic;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TeamTool.Models.Interfaces;
using TeamTool.Models.ViewModels;

namespace TeamTool.Controllers.Api
{

    [Route("api/teams")]
    public class TeamController : Controller
    {

        private ILogger<TeamController> _logger;
        private ITeamRepository _repository;

        public TeamController(ITeamRepository repository, ILoggerFactory loggerFactory)
        {
            _repository = repository;
            _logger = loggerFactory.CreateLogger<TeamController>();
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var teams = await _repository.GetAllAsync();
                return Ok(teams);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get all teams: {ex}");
                return BadRequest("Error occurred");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TeamViewModel team)
        {
            if (ModelState.IsValid)
            {
                //var newTrip = Mapper
                return Ok();
            }
            return BadRequest("Failed to save the team");
        }

    }
}
