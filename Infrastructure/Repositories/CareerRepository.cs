﻿using Domain.Contracts;
using Domain.Entities;
using Domain.Enums;
using Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Shared;

namespace Infrastructure.Repositories;

public class CareerRepository(ApplicationDbContext context) : ICareerRepository
{
    public async Task<IEnumerable<Career>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await context.Careers
            .Include(c => c.Faculty)
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }

    public async Task<Career?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await context.Careers.FindAsync([id, cancellationToken], cancellationToken);
    }

    public async Task<bool> ExistsAsync(int id, CancellationToken cancellationToken = default)
    {
        return await context.Careers
            .AnyAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<IEnumerable<User>> GetTeachersByIdAsync(
        int id, 
        string? query,
        CancellationToken cancellationToken = default
    )
    {
        return await context.Users
            .AsNoTracking()
            .ByLookupField(query)
            .ByCareer(id)
            .ByRole(Role.Teacher)
            .ConfirmedOnly()
            .Take(Constants.Pagination.DefaultPageSize)
            .ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<User>> GetStudentsByIdAsync(
        int id,
        string? query,
        CancellationToken cancellationToken = default
    )
    {
        return await context.Users
            .AsNoTracking()
            .ByLookupField(query)
            .ByCareer(id)
            .ByRole(Role.Student)
            .ConfirmedOnly()
            .Take(Constants.Pagination.DefaultPageSize)
            .ToListAsync(cancellationToken);
    }
}