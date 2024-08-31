using Microsoft.AspNetCore.Mvc;
using PayMart.Domain.Orders.Http.Product;
using PayMart.Domain.Orders.Model;
using PayMart.Domain.Orders.Services.Delete;
using PayMart.Domain.Orders.Services.GetAll;
using PayMart.Domain.Orders.Services.GetID;
using PayMart.Domain.Orders.Services.Post;

namespace PayMart.API.Orders.Controllers;

[Route("api/[Controller]")]
[ApiController]
public class OrderController : ControllerBase
{
    [HttpGet]
    [Route("getAll")]
    public async Task<IActionResult> GetAllOrder(
        [FromServices] IGetAllOrder services)
    {
        var response = await services.Execute();
        return Ok(response);
    }

    [HttpGet]
    [Route("getID/{id}")]
    public async Task<IActionResult> GetOrderByID(
        [FromRoute] int id,
        [FromServices] IGetOrderByID services)
    {
        var response = await services.Execute(id);
        return Ok(response);
    }

    [HttpPost]
    [Route("post/{userID}")]
    public async Task<IActionResult> RegisterListOrder(
        [FromServices] IRegisterOrder services,
        [FromBody] ModelOrder.CreateOrderRequest request,
        [FromRoute] int userID)
    {
        await GetPriceProduct.GetSumProducts(request);
        request.UserId = userID;

        var response = await services.Execute(request);
        if (response == null)
            return Ok("");

        return Ok(response);
    }

    [HttpDelete]
    [Route("delete/{id}")]
    public async Task<IActionResult> DeleteOrder(
        [FromServices] IDeleteOrder services,
        [FromRoute] int id)
    {
        var response = await services.Execute(id);
        if (response == null)
            return Ok("");

        return Ok();
    }

}
