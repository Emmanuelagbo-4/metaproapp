using Microsoft.AspNetCore.Mvc;

namespace metaproapp.Controllers;

[ApiController]
[Route("[controller]")]
public class ApexGamesController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "BunnyHopping", "JumpSpamming", "SlideJumping", "WorldsEdge", "KingsCanyon", "BattleRoyal", "TDM", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<ApexGamesController> _logger;

    public ApexGamesController(ILogger<ApexGamesController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IEnumerable<ApexGames> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new ApexGames
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }
}
