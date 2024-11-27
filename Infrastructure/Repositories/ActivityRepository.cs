﻿using Domain.Contracts;
using Domain.Entities;
using Domain.Enums;
using Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using static Domain.Contracts.IActivityRepository;

namespace Infrastructure.Repositories;

public class ActivityRepository(ApplicationDbContext context) : IActivityRepository
{
    public async Task AddAsync(Activity activity, CancellationToken cancellationToken = default)
    {
        await context.Activities.AddAsync(activity, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task<IEnumerable<Activity>> GetPagedAsync(
        ActivityFilter filters,
        CancellationToken cancellationToken = default
    )
    {
        var query = context.Activities.AsQueryable();
        
        return await query
            .AddIncludes()
            .OrderByDescending(a => a.CreatedAt)
            .ApplyFilters(filters)
            .Page(filters.PageNumber, filters.PageSize)
            .ToListAsync(cancellationToken);
    }

    public async Task<long> CountAsync(
        ActivityFilter filters,
        CancellationToken cancellationToken = default
    )
    {
        var query = context.Activities.AsQueryable();

        return await query
            .OrderByDescending(a => a.CreatedAt)
            .ApplyFilters(filters)
            .CountAsync(cancellationToken);
    }

    public async Task<bool> ExistsBySlugAsync(string slug, CancellationToken cancellationToken = default)
    {
        return await context.Activities.AnyAsync(a => a.Slug == slug, cancellationToken);
    }

    public async Task<Activity?> GetBySlugAsync(string slug, CancellationToken cancellationToken = default)
    {
        return await context.Activities
            .AddIncludes()
            .FirstOrDefaultAsync(a => a.Slug == slug, cancellationToken);
    }

    public async Task<Activity?> GetByIdAsync(
        int id,
        CancellationToken cancellationToken = default
    )
    {
        return await context.Activities
            .AddIncludes()
            .FirstOrDefaultAsync(a => a.Id == id, cancellationToken);
    }

    public async Task UpdateAsync(Activity activity, CancellationToken cancellationToken = default)
    {
        context.Activities.Update(activity);
        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task AddMemberAsync(ActivityMember activityMember, CancellationToken cancellationToken)
    {
        await context.ActivityMembers.AddAsync(activityMember, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateMemberAsync(ActivityMember activityMember, CancellationToken cancellationToken)
    {
        context.ActivityMembers.Update(activityMember);
        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task<IEnumerable<Activity>> GetMyRequestsAsync(
        UserRequestsFilter filters,
        CancellationToken cancellationToken = default
    )
    {
        var query = context.Activities.AsQueryable();
        
        return await query
            .AddIncludes()
            .OrderByDescending(a => a.CreatedAt)
            .ApplyRequestFilters(filters)
            .Page(filters.PageNumber, filters.PageSize)
            .ToListAsync(cancellationToken);
    }

    public async Task<long> CountMyRequestsAsync(
        UserRequestsFilter filters,
        CancellationToken cancellationToken = default
    )
    {
        var query = context.Activities.AsQueryable();

        return await query
            .OrderByDescending(a => a.CreatedAt)
            .ApplyRequestFilters(filters)
            .CountAsync(cancellationToken);
    }
}