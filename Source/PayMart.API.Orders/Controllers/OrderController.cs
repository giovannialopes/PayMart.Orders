using Microsoft.AspNetCore.Mvc;
using PayMart.Domain.Orders.Model;
using PayMart.Domain.Orders.Services.Delete;
using PayMart.Domain.Orders.Services.GetAll;
using PayMart.Domain.Orders.Services.GetID;
using PayMart.Domain.Orders.Services.Post;
using PayMart.Domain.Orders.Services.Update;

namespace PayMart.API.Orders.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderController : ControllerBase
{
    [HttpGet]
    [Route("getAll")]
    public async Task<IActionResult> GetAll(
        [FromServices] IGetAllOrder useCases)
    {
        var response = await useCases.Execute();
        return Ok(response);
    }


    [HttpGet]
    [Route("getID/{id}")]
    public async Task<IActionResult> GetID(
        [FromRoute] int id,
        [FromServices] IGetOrderByID useCases)
    {
        var response = await useCases.Execute(id);
        return Ok(response);
    }

    [HttpPost]
    [Route("post/{userID}")]
    public async Task<IActionResult> Post(
        [FromServices] IRegisterOrder useCases,
        [FromBody] ModelOrder.CreateOrderRequest request,
        [FromRoute] int userID)
    {
        request.UserId = userID;
        var response = await useCases.Execute(request);
        if (response == null)
            return Ok("");

        return Ok(response);
    }

    [HttpPut]
    [Route("update/{id}/{userID}")]
    public async Task<IActionResult> Update(
        [FromServices] IUpdateOrder useCases,
        [FromRoute] int id, int userID,
        [FromBody] ModelOrder.UpdateOrderRequest request)
    {
        request.ProductId = userID;
        var response = await useCases.Execute(request, id);
        if (response == null)
            return Ok("");

        return Ok(response);
    }

    [HttpDelete]
    [Route("delete/{id}")]
    public async Task<IActionResult> Delete(
        [FromServices] IDeleteOrder useCases,
        [FromRoute] int id)
    {
        var response = await useCases.Execute(id);
        if (response == null)
            return Ok("");

        return Ok();
    }

}
