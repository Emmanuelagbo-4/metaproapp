using System;
using metaproapp.Models.Request;
using metaproapp.Models.Response;
using metaproapp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace metaproapp.Controllers
{
    [Route ("api/teams")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        private readonly IteamsService _teamsService;

        public TeamsController(IteamsService teamsService)
        {
            _teamsService = teamsService;
        }

        /// <summary>
        /// Create Teams
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateTeams(CreateTeamsRequestModel model) 
        {
            var response =  _teamsService.CreateTeams(model);

            if (response.status)
            {
                return Ok(new ApiResponse {message = response.message, data = response.data});
            }

            return BadRequest(new ApiResponse {message = response.message, errors = "failed to create teams"});
        }
    }
}
