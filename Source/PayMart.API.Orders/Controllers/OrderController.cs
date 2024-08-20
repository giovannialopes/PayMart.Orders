using Microsoft.AspNetCore.Mvc;
using PayMart.Application.Orders.UseCases.Post;
using PayMart.Domain.Orders.Request;

namespace PayMart.API.Orders.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderController : ControllerBase
{
    [HttpPost]
    [Route("post")]
    public async Task<IActionResult> Post(
        [FromServices] IPostOrderUseCases useCases,
        [FromBody] RequestOrder request)
    {
        return Ok();
    }
}
