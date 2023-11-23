using MediatR;
using Microsoft.AspNetCore.Mvc;
using VerticalSliceArch.Common.Helpers;
using VerticalSliceArch.Features.Pokemon.Application.Queries;
using VerticalSliceArch.Features.Pokemon.Domain.DTOs;

namespace VerticalSliceArch.Features.Pokemon.Presentation;

public class PokemonController: ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ILogger<PokemonController> _logger;
    public PokemonController(IMediator mediator, ILogger<PokemonController> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var query = new GetPokemonQuery { PokemonId = id };
    
        try
        {
            var pokemon = await _mediator.Send(query);
            return Ok(new CustomResponse<PokemonDto>(){StatusCode = 200, Results = pokemon});
        }
        catch (PokemonNotFoundException ex)
        {
            var response = new CustomResponse<PokemonDto>
            {
                StatusCode = 404,
                Messages = new List<string> { ex.Message }
            };
            return NotFound(response);
        }
        catch (Exception ex)
        {
            var errorId = Guid.NewGuid();
            _logger.LogError(ex, $"An error occurred while processing your request, Reference Id: {errorId}");
            return StatusCode(500, new CustomResponse<PokemonDto>(500, ex, errorId.ToString(), new List<string>(){"An error occurred while processing your request"}));
        }
    }
    
}