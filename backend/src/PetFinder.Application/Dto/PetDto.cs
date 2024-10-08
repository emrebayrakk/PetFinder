namespace PetFinder.Application.Dto
{
    public record PetDto(string name,
        string animalType,
        string generalDescription,
        string color,
        string healthInformation,
        string ownerPhoneNumber,
        double weight,
        double height,
        DateOnly birthDate);
}
