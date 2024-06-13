using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

public interface IOrderService
{
    Task<IEnumerable<Order>> GetAllOrdersAsync(CancellationToken cancellationToken);
    Task<Order> GetOrderByIdAsync(int id, CancellationToken cancellationToken);
    Task<Order> CreateOrderAsync(Order order, CancellationToken cancellationToken);
    Task<Order> UpdateOrderAsync(Order order, CancellationToken cancellationToken);
    Task<bool> DeleteOrderAsync(int id, CancellationToken cancellationToken);
}


public class OrderService : IOrderService
{
    private readonly ApplicationDbContext _context;

    public OrderService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Order>> GetAllOrdersAsync(CancellationToken cancellationToken)
    {
        return await _context.Orders.Include(o => o.OrderItems).ToListAsync(cancellationToken);
    }

    public async Task<Order> GetOrderByIdAsync(int id, CancellationToken cancellationToken)
    {
        return await _context.Orders.Include(o => o.OrderItems).FirstOrDefaultAsync(o => o.Id == id, cancellationToken);
    }

    public async Task<Order> CreateOrderAsync(Order order, CancellationToken cancellationToken)
    {
        _context.Orders.Add(order);
        await _context.SaveChangesAsync(cancellationToken);
        return order;
    }

    public async Task<Order> UpdateOrderAsync(Order order, CancellationToken cancellationToken)
    {
        _context.Orders.Update(order);
        await _context.SaveChangesAsync(cancellationToken);
        return order;
    }

    public async Task<bool> DeleteOrderAsync(int id, CancellationToken cancellationToken)
    {
        var order = await _context.Orders.FindAsync(id);
        if (order == null) return false;

        _context.Orders.Remove(order);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}
