using Microsoft.AspNetCore.Mvc;
using PayMart.Domain.Orders.Http.Product;
using PayMart.Domain.Orders.Model;
using PayMart.Domain.Orders.Services;

namespace PayMart.API.Orders.Controllers;

[Route("api/[Controller]")]
[ApiController]
public class OrderController : ControllerBase
{
    [HttpGet]
    [Route("getAll")]
    public async Task<IActionResult> GetAllOrder(
        [FromServices] IOrderServices services)
    {
        var response = await services.GetOrders();
        if(response.Response != null)
            return Ok(response.Response);

        return Ok(response.Error);
    }

    [HttpGet]
    [Route("getID/{id}")]
    public async Task<IActionResult> GetOrderByID(
        [FromRoute] int id,
        [FromServices] IOrderServices services)
    {
        var response = await services.GetOrderById(id);
        if (response.Response != null)
            return Ok(response.Response);

        return Ok(response.Error);
    }

    [HttpPost]
    [Route("post/{userID}")]
    public async Task<IActionResult> RegisterListOrder(
        [FromServices] IOrderServices services,
        [FromBody] ModelOrder.CreateOrderRequest request,
        [FromRoute] int userID)
    {
        await HttpProduct.GetSumProducts(request);
        request.UserId = userID;

        var response = await services.RegisterOrder(request);
        return Ok(response);
    }

    [HttpDelete]
    [Route("delete/{id}")]
    public async Task<IActionResult> DeleteOrder(
        [FromServices] IOrderServices services,
        [FromRoute] int id)
    {
        var response = await services.DeleteOrder(id);
        return Ok();
    }

}
