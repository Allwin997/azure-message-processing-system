using AzureMessageProcessing.Api.Interfaces;
using AzureMessageProcessing.Shared.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace AzureMessageProcessing.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
    private readonly IOrderService _orderService;

    public OrdersController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateOrder(CreateOrderRequest request)
    {
        var response = await _orderService.CreateOrderAsync(request);

        return Ok(response);
    }
}