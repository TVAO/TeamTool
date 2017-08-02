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
    /// Controller used to handle project requests.
    /// NB: only support overview and creation of projects - requests are currently not sent to the respective team.
    /// </summary>
    public class ProjectController : Controller
    {
        private ILogger<ProjectController> _logger;
        private IMapper _mapper;
        private IProjectRepository _repository;

        public ProjectController(ILoggerFactory loggerFactory, IMapper mapper, IProjectRepository repository)
        {
            _logger = loggerFactory.CreateLogger<ProjectController>();
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<IActionResult> Projects()
        {
            try
            {
                var projects = await _repository.GetAllAsync();
                var model = _mapper.Map<IQueryable<Project>, IEnumerable<ProjectViewModel>>(projects);
                return View(model);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get projects in Index page: {ex.Message}");
                return Redirect("/Error");
            }
        }

        [HttpGet]
        public IActionResult RequestProject()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RequestProject(ProjectRequestViewModel projectViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(projectViewModel);
            }

            if (projectViewModel == null)
            {
                return View("/Error");
            }

            var model = _mapper.Map<Project>(projectViewModel);

            var projectId = await _repository.CreateAsync(model);

            if (projectId < 1)
            {
                return View("/Error");
            }

            // TODO: Edit Project Page + Logging

            return RedirectToAction(nameof(Projects));
        }

        // TODO 
        public IActionResult EditProject()
        {
            throw new NotImplementedException();
        }

        public async Task<IActionResult> DeleteProject(int id)
        {
            try
            {
                var isSuccess = await _repository.DeleteAsync(id);
                return RedirectToAction(nameof(Projects));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to delete project: {ex}");
                return Redirect("/Error");
            }
        }
    }
}
