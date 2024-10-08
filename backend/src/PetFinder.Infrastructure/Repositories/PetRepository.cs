using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using PetFinder.Application.Features.Pet;
using PetFinder.Domain.Shared.Ids;
using System.Linq.Expressions;

namespace PetFinder.Infrastructure.Repositories
{
    public class PetRepository(ApplicationDbContext dbContext) : IPetRepository
    {
        private readonly ApplicationDbContext _dbContext = dbContext;
        public async Task<PetId> Add(Domain.Volunteer.Models.Pet pet, CancellationToken cancellationToken)
        {
            await _dbContext.AddAsync(pet, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return pet.Id;
        }

        public async Task<Result<List<Domain.Volunteer.Models.Pet>>> GetAll(CancellationToken cancellationToken)
        {
            var pets = await GetAllPets(cancellationToken);
            return pets is null
                ? Result.Failure<List<Domain.Volunteer.Models.Pet>>("Not not found")
                : Result.Success(pets);
        }

        public async Task<Result<Domain.Volunteer.Models.Pet>> GetById(PetId petId, CancellationToken cancellationToken)
        {
            var pet = await GetBy(
            v => v.Id == petId,
            cancellationToken);

            return pet is null
                ? Result.Failure<Domain.Volunteer.Models.Pet>("Not not found")
                : Result.Success(pet);
        }
        private Task<Domain.Volunteer.Models.Pet?> GetBy(Expression<Func<Domain.Volunteer.Models.Pet, bool>> expression,
        CancellationToken cancellationToken)
        {
            return _dbContext.Pets
                .FirstOrDefaultAsync(expression, cancellationToken);
        }
        private Task<List<Domain.Volunteer.Models.Pet>> GetAllPets(CancellationToken cancellationToken)
        {
            return _dbContext.Pets
                .ToListAsync(cancellationToken);
        }
    }
}
