using System;
using metaproapp.Models.Request;
using metaproapp.Models.Response;

namespace metaproapp.Services.Interfaces
{
    public interface IteamsService
    {
        ServiceResponse CreateTeams(CreateTeamsRequestModel model);

        ServiceResponse GetAllTeams();

        ServiceResponse GetTeamById(long id);

        ServiceResponse DeleteTeam(long id);
    }
}
