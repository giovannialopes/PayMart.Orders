using PayMart.Domain.Orders.Model;
using System.Text.Json;
using static PayMart.Domain.Orders.Model.ModelOrder;
using static PayMart.Domain.Orders.Model.ModelProduct;

namespace PayMart.Domain.Orders.Http.Product;

public class HttpProduct
{
    private static HttpClient _http;

    static HttpProduct()
    {
        _http = new HttpClient();
    }

    public static async Task GetSumProducts(CreateOrderRequest request)
    {
        var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
        var host = environment == "Development" ? "localhost" : "paymart-products";

        var httpResponse = await _http.GetStringAsync($"http://{host}:5002/api/Product/getAll");
        var responseProduct = FormatterGetAll(httpResponse);
        var filteredProducts = responseProduct
            .Where(product => request.ProductIds.Contains(product.Id))
            .ToList();
        var totalPrice = filteredProducts.Sum(product => product.Price);

        var takeId = string.Empty;
        foreach (var product in filteredProducts) 
        {
            if (!string.IsNullOrEmpty(takeId))
            {
                takeId += ";";
            }
            takeId += product.Id.ToString();
        }

        request.ProductId = takeId;
        request.Price = totalPrice;
    }

    private static List<ProductResponse> FormatterGetAll(string json)
    {

        using var jsonDocument = JsonDocument.Parse(json);
        var productsArray = jsonDocument.RootElement.GetProperty("products");

        var productsResponses = productsArray.EnumerateArray()
            .Select(product => new ModelProduct.ProductResponse
            {
                Id = product.GetProperty("id").GetInt32(),
                Description = product.GetProperty("description").GetString() ?? string.Empty,
                Name = product.GetProperty("name").GetString() ?? string.Empty,
                Price = product.GetProperty("price").GetDecimal(),
                Status = product.GetProperty("status").GetString() ?? string.Empty,
                StockQuantity = product.GetProperty("stockQuantity").GetInt32()
            })
            .ToList();

        return productsResponses;


    }

}
