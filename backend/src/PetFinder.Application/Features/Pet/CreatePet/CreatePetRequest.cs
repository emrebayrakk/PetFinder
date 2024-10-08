using PetFinder.Application.Dto;
using PetFinder.Domain.Volunteer.Enums;
using PetFinder.Domain.Volunteer.Models;

namespace PetFinder.Application.Features.Pet.CreatePet
{
    public record CreatePetRequest
    (
        SpeciesBreedDto speciesBreedObject,
        AdressDto address,
        string name,
        string animalType,
        string generalDescription,
        string color,
        string healthInformation,
        string ownerPhoneNumber,
        double weight,
        double height,
        DateTime birthDate,
        bool isCastrated,
        bool isVaccinated,
        HelpStatusPet helpStatusPet,
        IEnumerable<PetPhotoDto>? photos
    );
}
