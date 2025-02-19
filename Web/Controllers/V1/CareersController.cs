﻿using Application.Features.Careers.Models;
using Application.Features.Careers.Queries;
using Mediator;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web.Extensions;

namespace Web.Controllers.V1;

public class CareersController(ISender sender) : BaseController
{
    [AllowAnonymous]
    [HttpGet]
    [ProducesResponseType<List<CareerResponse>>(StatusCodes.Status200OK)]
    public async Task<IResult> GetAsync(CancellationToken cancellationToken)
    {
        var result = await sender.Send(new GetCareersQuery(), cancellationToken);
        
        return result.IsSuccess ? Results.Ok(result.Value) : result.ToProblemDetails();
    }

    [HttpGet("{id:int}/students")]
    [ProducesResponseType<List<CareerUserResponse>>(StatusCodes.Status200OK)]
    public async Task<IResult> GetStudentsAsync(int id, [FromQuery] string? query, CancellationToken cancellationToken)
    {
        var result = await sender.Send(new GetStudentsByIdQuery(id, query), cancellationToken);

        return result.IsSuccess ? Results.Ok(result.Value) : result.ToProblemDetails();
    }

    [HttpGet("{id:int}/teachers")]
    [ProducesResponseType<List<CareerUserResponse>>(StatusCodes.Status200OK)]
    public async Task<IResult> GetTeachersAsync(int id, [FromQuery] string? query, CancellationToken cancellationToken)
    {
        var result = await sender.Send(new GetTeachersByIdQuery(id, query), cancellationToken);

        return result.IsSuccess ? Results.Ok(result.Value) : result.ToProblemDetails();
    }
}