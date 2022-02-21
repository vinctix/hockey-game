using HockeyGame.Application.Commands;
using HockeyGame.Application.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HockeyGame.Api.Controllers;

[ApiController]
[Route("api/players")]
public class PlayersController : ControllerBase
{
    private readonly IMediator _mediator;
    public PlayersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Create a new player.
    /// </summary>
    /// <param name="command"></param>
    /// <returns>The player created or 400 if team not found</returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> CreatePlayer(CreatePlayerCommand command)
    {
        try
        {
            var player = await _mediator.Send(command);
            return new ObjectResult(player) { StatusCode = StatusCodes.Status201Created };
        }
        catch (TeamNotFoundException)
        {
            return BadRequest("The team id is invalid.");
        }
       
    }

    /// <summary>
    /// Set an existing player as captain of its team.
    /// </summary>
    /// <param name="id">player id</param>
    /// <returns>The player updated or 404 if not found</returns>
    /// <remarks>
    /// If exists, the previous captain loose this status.
    /// </remarks>
    [HttpPut("{id}/captain")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> SetCaptain(int id)
    {
        try
        {
            var player = await _mediator.Send(new SetCaptainCommand(){ Id = id});
            return Ok(player);
        }
        catch (PlayerNotFoundException)
        {
            return NotFound();
        }
    }
}
