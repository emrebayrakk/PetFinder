using Microsoft.AspNetCore.Mvc;
using PetFinder.API.Extensions;
using PetFinder.Application.Features.Pet.CreatePet;

namespace PetFinder.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PetController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create(
            [FromServices] CreatePetHandler handler,
            [FromBody] CreatePetRequest createPetRequest,
            [FromServices] ILogger<PetController> logger,
            CancellationToken cancellationToken = default)
        {
            var result = await handler.Handle(createPetRequest, cancellationToken);

            return result.IsFailure
                ? result.Error.ToResponse()
                : Ok(result.Value);
        }
    }
}
