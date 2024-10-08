using CSharpFunctionalExtensions;
using FluentValidation;
using Microsoft.Extensions.Logging;
using PetFinder.Application.Features.Shared;
using PetFinder.Domain.Shared.Ids;
using PetFinder.Domain.Shared.ValueObjects;
using PetFinder.Domain.Shared;
using PetFinder.Domain.SharedKernel;
using PetFinder.Domain.Volunteer.ValueObjects;
using PetFinder.Domain.Volunteer.Models;
using PetFinder.Application.Dto;

namespace PetFinder.Application.Features.Pet.CreatePet
{
    public class CreatePetHandler(
    IPetRepository petRepository,
    ILogger<CreatePetHandler> logger,
    IValidator<CreatePetRequest> validator) : IHandler
    {
        public async Task<Result<Guid, ErrorList>> Handle(
        CreatePetRequest request,
        CancellationToken cancellationToken = default)
        {

            var petId = PetId.New();

            List<PetPhoto> photos = new List<PetPhoto>();
            foreach (var item in request.photos)
            {
                var petPhotoId = PetPhotoId.New();
                var petPhoto = PetPhoto.Create(petPhotoId, item.path, item.isMain);
                if (petPhoto.IsFailure)
                    return petPhoto.Error.ToErrorList();
                photos.Add(petPhoto.Value);
            }
            IEnumerable<PetPhoto> enumerablePhotos = photos;
            var adress = Address.Create(request.address.country, request.address.city, request.address.street, request.address.house, request.address.description);

            var speciesId = SpeciesId.Create(Guid.Parse(request.speciesBreedObject.SpeciesId));
            var breedId = BreedId.Create(Guid.Parse(request.speciesBreedObject.BreedId));
            var speciesBreedObject = SpeciesBreedObject.Create(speciesId, breedId);

            if (speciesBreedObject.IsFailure)
                return speciesBreedObject.Error.ToErrorList();

            var dateOnly = DateOnly.FromDateTime(request.birthDate);

            var createPetResult = Domain.Volunteer.Models.Pet.Create(
                      petId,
                      speciesBreedObject.Value,
                      request.name,
                      request.animalType,
                      request.generalDescription,
                      request.color,
                      request.healthInformation,
                      adress.Value,
                      request.weight,
                      request.height,
                      request.ownerPhoneNumber,
                      dateOnly,
                      request.isCastrated,
                      request.isVaccinated,
                      request.helpStatusPet,
                      DateTime.Now,
                      enumerablePhotos
                      );


            if (createPetResult.IsFailure)
                return createPetResult.Error.ToErrorList();

            await petRepository.Add(createPetResult.Value, cancellationToken);

            logger.LogInformation("Volunteer with {id} created successfully.", petId.Value);

            return petId.Value;
        }
    }
}
