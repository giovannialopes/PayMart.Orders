using Microsoft.AspNetCore.Mvc;
using PayMart.Application.Orders.UseCases.Delete;
using PayMart.Application.Orders.UseCases.GetAll;
using PayMart.Application.Orders.UseCases.GetID;
using PayMart.Application.Orders.UseCases.Post;
using PayMart.Application.Orders.UseCases.Update;
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

    [HttpGet]
    [Route("getID/{id}")]
    public async Task<IActionResult> GetID(
        [FromRoute] int id,
        [FromServices] IGetIDOrderUseCases useCases)
    {
        var response = await useCases.Execute(id);
        return Ok(response);
    }

    [HttpPost]
    [Route("post/{userID}")]
    public async Task<IActionResult> Post(
        [FromServices] IPostOrderUseCases useCases,
        [FromBody] RequestOrder request,
        [FromRoute] int userID)
    {
        request.UserID = userID;
        var response = await useCases.Execute(request);
        if (response == null)
            return Ok("");

        return Ok(response);
    }

    [HttpPut]
    [Route("update/{id}/{userID}")]
    public async Task<IActionResult> Update(
        [FromServices] IUpdateOrderUseCases useCases,
        [FromRoute] int id, int userID,
        [FromBody] RequestOrderUpdate request)
    {
        request.ProductID = userID;
        var response = await useCases.Execute(request, id);
        if (response == null)
            return Ok("");

        return Ok(response);
    }

    [HttpDelete]
    [Route("delete/{id}")]
    public async Task<IActionResult> Delete(
        [FromServices] IDeleteOrderUseCases useCases,
        [FromRoute] int id)
    {
        await useCases.Execute(id);
        return Ok();
    }

}
