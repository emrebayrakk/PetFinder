using FluentValidation;
using PetFinder.Application.Extensions;

namespace PetFinder.Application.Features.Pet.CreatePet
{
    public class CreatePetValidator : AbstractValidator<CreatePetRequest>
    {
        public CreatePetValidator() 
        {
        }
    }
}
