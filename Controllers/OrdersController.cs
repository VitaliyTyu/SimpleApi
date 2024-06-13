using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class OrdersController : ControllerBase
{
    private readonly IOrderService _orderService;

    public OrdersController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    /// <summary>
    /// Gets all orders.
    /// </summary>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<Order>), 200)]

    public async Task<ActionResult<IEnumerable<Order>>> GetOrders(CancellationToken cancellationToken)
    {
        var orders = await _orderService.GetAllOrdersAsync(cancellationToken);
        return Ok(orders);
    }

    /// <summary>
    /// Gets a order by ID.
    /// </summary>
    /// <param name="id">The ID of the order.</param>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(Order), 200)]
    [ProducesResponseType(404)]
    public async Task<ActionResult<Order>> GetOrder(int id, CancellationToken cancellationToken)
    {
        var order = await _orderService.GetOrderByIdAsync(id, cancellationToken);
        if (order == null)
        {
            return NotFound();
        }
        return Ok(order);
    }

    /// <summary>
    /// Creates a new order.
    /// </summary>
    /// <param name="order">The order to create.</param>
    [HttpPost]
    [ProducesResponseType(typeof(Order), 201)]
    [ProducesResponseType(400)]
    public async Task<ActionResult<Order>> CreateOrder(Order order, CancellationToken cancellationToken)
    {
        var createdOrder = await _orderService.CreateOrderAsync(order, cancellationToken);
        return CreatedAtAction(nameof(GetOrder), new { id = createdOrder.Id }, createdOrder);
    }

    /// <summary>
    /// Updates an existing order.
    /// </summary>
    /// <param name="id">The ID of the order.</param>
    /// <param name="order">The updated order.</param>
    [HttpPut("{id}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> UpdateOrder(int id, Order order, CancellationToken cancellationToken)
    {
        if (id != order.Id)
        {
            return BadRequest();
        }

        await _orderService.UpdateOrderAsync(order, cancellationToken);
        return NoContent();
    }

    /// <summary>
    /// Deletes a order by ID.
    /// </summary>
    /// <param name="id">The ID of the order.</param>
    [HttpDelete("{id}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> DeleteOrder(int id, CancellationToken cancellationToken)
    {
        var result = await _orderService.DeleteOrderAsync(id, cancellationToken);
        if (!result)
        {
            return NotFound();
        }

        return NoContent();
    }
}
