namespace PetFinder.Application.Dto
{
    public record AdressDto(
        string country,
        string city,
        string street,
        string house,
        string? description);
}
