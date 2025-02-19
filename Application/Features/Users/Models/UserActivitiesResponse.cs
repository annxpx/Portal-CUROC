using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using Domain.Enums;
using Microsoft.AspNetCore.Diagnostics;

namespace Application.Features.Users.Models;

public record UserActivitiesResponse(
    int Id,
    string Name,
    string Description,
    List<ActivitiesScopeResponse> MemberScopes,
    List<ActivitiesScopeResponse> ActivityScopes,
    DateTime StartDate,
    DateTime EndDate,
    string Slug,
    ActivityStatus ActivityStatus
);

public record struct ActivitiesScopeResponse(

    ActivityScopes Scope,
    int Hours

);