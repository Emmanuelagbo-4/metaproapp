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

        private readonly ApplicationDbContext _dbContext;
        public TeamsService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
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

            var data = _dbContext.Add(teamsObj).Entity;
            var status = _dbContext.SaveChanges() > 0 ? true : false;

            if (status)
            {
                return new ServiceResponse {status = true, message = "Created Teams successfullly", data = data};
            }

            return new ServiceResponse {status = false, message = "faile to create teams"};

        }
    }
}
