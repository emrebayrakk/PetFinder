using CSharpFunctionalExtensions;
using PetFinder.Domain.Shared.Ids;

namespace PetFinder.Application.Features.Pet
{
    public interface IPetRepository
    {
        Task<PetId> Add(Domain.Volunteer.Models.Pet pet,
        CancellationToken cancellationToken);

        Task<Result<Domain.Volunteer.Models.Pet>> GetById(PetId petId,
        CancellationToken cancellationToken);

        Task<Result<List<Domain.Volunteer.Models.Pet>>> GetAll(
        CancellationToken cancellationToken);

    }
}
