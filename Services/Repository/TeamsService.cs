using System;
using metaproapp.Data;
using metaproapp.Entities;
using metaproapp.Models.Request;
using metaproapp.Models.Response;
using metaproapp.Services.Interfaces;

namespace metaproapp.Services.Repository
{
    public class TeamsService : IteamsService
    {
        private readonly IGenericRepository<Team> _teamRepo;
       
        public TeamsService(IGenericRepository<Team> teamRepo)
        {
           
            _teamRepo = teamRepo;
        }
        public ServiceResponse CreateTeams(CreateTeamsRequestModel model)
        {
            var teamsObj = new Team
            {
                Name = model.Name,
                Amount = model.Amount,
                Number = model.Number,
                DateCreated = DateTime.Now
            };
            
             bool status = _teamRepo.Insert(teamsObj) > 0 ? true : false;

            if (status)
            {
                return new ServiceResponse {status = true, message = "Created Teams successfullly", data = teamsObj};
            }

            return new ServiceResponse {status = false, message = "faile to create teams"};

        }
    }
}
