using HockeyGame.Application.Exceptions;
using HockeyGame.Application.Queries;
using HockeyGame.Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HockeyGame.Api.Controllers;

[ApiController]
[Route("api/teams")]
public class TeamsController : ControllerBase
{
    private readonly IMediator _mediator;
    public TeamsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Get a team from year.
    /// </summary>
    /// <param name="year">Example : 2021</param>
    /// <returns>The related team or 404 if not found</returns>
    [HttpGet("{year}")]
    [ProducesResponseType(typeof(Team), StatusCodes.Status200OK)]
    [ProducesResponseType( StatusCodes.Status404NotFound)]

    public async Task<ActionResult> GetTeamByYear(int year)
    {
        try
        {
            var team = await _mediator.Send(new GetTeamByYearQuery(){ Year = year });
            return Ok(team);
        }
        catch (TeamNotFoundException)
        {
            return NotFound();
        }
    }
}
