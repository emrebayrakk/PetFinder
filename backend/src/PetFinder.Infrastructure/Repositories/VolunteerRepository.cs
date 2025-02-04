using System.Linq.Expressions;
using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using PetFinder.Application.Features;
using PetFinder.Domain.Shared.Ids;
using PetFinder.Domain.Volunteer.Models;
using PetFinder.Domain.Volunteer.ValueObjects;

namespace PetFinder.Infrastructure.Repositories;

public class VolunteerRepository(ApplicationDbContext dbContext) : IVolunteerRepository
{
    private readonly ApplicationDbContext _dbContext = dbContext;

    public async Task<VolunteerId> Add(Volunteer volunteer, CancellationToken cancellationToken = default)
    {
        await _dbContext.AddAsync(volunteer, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return volunteer.Id;
    }

    public async Task<Result<Volunteer>> GetById(VolunteerId volunteerId, CancellationToken cancellationToken = default)
    {
        var volunteer = await GetBy(
            v => v.Id == volunteerId,
            cancellationToken);

        return volunteer is null
            ? Result.Failure<Volunteer>("Not not found")
            : Result.Success(volunteer);
    }

    public async Task<Result<Volunteer>> GetByEmail(Email email,
        CancellationToken cancellationToken = default)
    {
        var volunteer = await GetBy(
            v => v.Email == email,
            cancellationToken);

        return volunteer is null
            ? Result.Failure<Volunteer>("Not not found")
            : Result.Success(volunteer);
    }

    public async Task<Result<Volunteer>> GetByPhoneNumber(PhoneNumber phoneNumber,
        CancellationToken cancellationToken = default)
    {
        var volunteer = await GetBy(
            v => v.PhoneNumber == phoneNumber,
            cancellationToken);

        return volunteer is null
            ? Result.Failure<Volunteer>("Not not found")
            : Result.Success(volunteer);
    }


    private Task<Volunteer?> GetBy(Expression<Func<Volunteer, bool>> expression,
        CancellationToken cancellationToken)
    {
        return _dbContext.Volunteers
            .Include(v => v.Pets)
            .ThenInclude(p => p.Photos)
            .FirstOrDefaultAsync(expression, cancellationToken);
    }
}