using Application.Features.Activities.Models;
using Application.Features.Activities.Queries;
using Application.Features.Users.Models;
using Application.Features.Users.Queries;
using Domain.Contracts;
using Mediator;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web.Extensions;

namespace Web.Controllers.V1;

public class UsersController(ISender sender) : BaseController
{
    [HttpGet("me")]
    [ProducesResponseType<UserResponse>(StatusCodes.Status200OK)]
    public async Task<IResult> GetAsync(CancellationToken cancellationToken)
    {
        var result = await sender.Send(new GetCurrentUserQuery(), cancellationToken);
        return result.IsSuccess ? Results.Ok(result.Value) : result.ToProblemDetails();
    }

    [HttpGet("my-requests")]
    [ProducesResponseType<List<MyActivityResponse>>(StatusCodes.Status200OK)]
    public async Task<IResult> GetRequestsAsync(CancellationToken cancellationToken)
    {
        var result = await sender.Send(new GetMyRequestsQuery(), cancellationToken);
        return result.IsSuccess ? Results.Ok(result.Value) : result.ToProblemDetails();
    }

    [HttpGet("my-activities")]
    [ProducesResponseType<List<UserActivitiesResponse>>(StatusCodes.Status200OK)]
    public async Task<IResult> GetActivitiesAsync(CancellationToken cancellationToken)
    {
        var result = await sender.Send(new UserActivitiesQuery(), cancellationToken);
        return result.IsSuccess ? Results.Ok(result.Value) : result.ToProblemDetails();
    }

    [HttpGet("by-role")]
    [ProducesResponseType<List<UsersByRoleResponse>>(StatusCodes.Status200OK)]
  
    public async Task<IResult> GetUsersByRoleAsync([FromQuery] UserFilter filters, CancellationToken cancellationToken)
    {
        var result = await sender.Send(new GetUsersByRoleQuery(filters), cancellationToken);
        return result.IsSuccess ? Results.Ok(result.Value) : result.ToProblemDetails();
    }
    
    
}