using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TeamTool.Models.Entities;
using TeamTool.Models.Interfaces;
using TeamTool.Models.ViewModels;

namespace TeamTool.Controllers.Web
{

    /// <summary>
    /// This controller is responsible for the team page and is used to add, modify and delete teams and their members. 
    /// </summary>
    public class TeamController : Controller
    {
        private ILogger<TeamController> _logger;
        private IMapper _mapper;
        private ITeamRepository _repository;

        public TeamController(ILoggerFactory loggerFactory, IMapper mapper, ITeamRepository repository)
        {
            _logger = loggerFactory.CreateLogger<TeamController>();
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<IActionResult> Teams()
        {
            var teams = await _repository.GetAllAsync();

            if (teams == null)
            {
                return View("/Error");
            }

            var model = _mapper.Map<IQueryable<Team>, IEnumerable<TeamViewModel >> (teams);

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> EditTeam(int id)
        {
            var teamToEdit = await _repository.FindAsync(id);

            if (teamToEdit == null)
            {
                return View("/Error");
            }

            var model = _mapper.Map<TeamViewModel>(teamToEdit);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditTeam(TeamViewModel teamViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(teamViewModel);
            }

            if (teamViewModel == null)
            {
                return View("/Error");
            }

            var model = _mapper.Map<Team>(teamViewModel);

            var isSuccess = await _repository.UpdateAsync(model);

            if (!isSuccess)
            {
                return View("/Error");
            }

            return RedirectToAction(nameof(Teams));
        }

        public async Task<IActionResult> DeleteTeam(int id)
        {
            var isSuccess = await _repository.DeleteAsync(id);

            if (!isSuccess)
            {
                return View("/Error");
            }

            return RedirectToAction(nameof(Teams)); 
        }

        [HttpGet]
        public IActionResult CreateTeam()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateTeam(CreateTeamViewModel teamViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(teamViewModel);
            }

            if (teamViewModel == null)
            {
                return View("/Error");
            }

            var model = _mapper.Map<Team>(teamViewModel);

            var teamId = await _repository.CreateAsync(model);

            if(teamId < 1)
            {
                return View("/Error");
            }

            var newTeam = _mapper.Map<TeamViewModel>(await _repository.FindAsync(teamId));

            if (newTeam == null)
            {
                return View("/Error");
            }

            return RedirectToAction(nameof(Teams));
            //return RedirectToAction(nameof(EditTeam), newTeam);
        }
    }
}
