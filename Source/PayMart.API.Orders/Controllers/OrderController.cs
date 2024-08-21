using Microsoft.AspNetCore.Mvc;
using PayMart.Application.Orders.UseCases.GetAll;
using PayMart.Application.Orders.UseCases.Post;
using PayMart.Domain.Orders.Request;

namespace PayMart.API.Orders.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderController : ControllerBase
{
    [HttpGet]
    [Route("getAll")]
    public async Task<IActionResult> GetAll(
        [FromServices] IGetAllOrderUseCases useCases)
    {
        var response = await useCases.Execute();
        return Ok(response);
    }


    [HttpPost]
    [Route("post")]
    public async Task<IActionResult> Post(
        [FromServices] IPostOrderUseCases useCases,
        [FromBody] RequestOrder request)
    {
        var response = await useCases.Execute(request);
        return Ok(response);    
    }


}
