using Microsoft.Extensions.DependencyInjection;
using PetFinder.Application.Features;
using PetFinder.Application.Features.Pet;
using PetFinder.Infrastructure.Repositories;

namespace PetFinder.Infrastructure;

public static class Inject
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddDbContext<ApplicationDbContext>();

        services.AddScoped<IVolunteerRepository, VolunteerRepository>();
        services.AddScoped<IPetRepository, PetRepository>();

        return services;
    }
}