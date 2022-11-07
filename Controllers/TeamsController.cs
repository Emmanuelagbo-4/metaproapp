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

        /// <summary>
        /// Get All Teams
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllTeams()
        {
            var response = _teamsService.GetAllTeams();

            if (response.status)
            {
               return Ok(new ApiResponse {message = response.message, data = response.data}); 
            }
            return BadRequest(new ApiResponse {message = response.message, errors = "failed to get all teams"});
        }
        
        /// <summary>
        /// Get Team By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetTeamById(long id)
        {
            var response = _teamsService.GetTeamById(id);

            if (response.status)
            {
               return Ok(new ApiResponse {message = response.message, data = response.data}); 
            }
            return BadRequest(new ApiResponse {message = response.message, errors=response.message});
        }

        /// <summary>
        /// Delete Team
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>    
        [HttpDelete]
         public async Task<IActionResult> DeleteTeam(long id) 
        {
            var response =  _teamsService.DeleteTeam(id);

            if (response.status)
            {
                
                return Ok(new ApiResponse {message = response.message, data = response.data});
            }

            return BadRequest(new ApiResponse {message = response.message, errors = "failed to delete teams"});
        }

    }
}
