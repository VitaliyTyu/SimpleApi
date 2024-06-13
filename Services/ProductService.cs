using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

public interface IProductService
{
    Task<IEnumerable<Product>> GetAllProductsAsync(CancellationToken cancellationToken);
    Task<Product> GetProductByIdAsync(int id, CancellationToken cancellationToken);
    Task<Product> CreateProductAsync(Product product, CancellationToken cancellationToken);
    Task<Product> UpdateProductAsync(Product product, CancellationToken cancellationToken);
    Task<bool> DeleteProductAsync(int id, CancellationToken cancellationToken);
}


public class ProductService : IProductService
{
    private readonly ApplicationDbContext _context;

    public ProductService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Product>> GetAllProductsAsync(CancellationToken cancellationToken)
    {
        return await _context.Products.Include(p => p.ProductInfo).ToListAsync(cancellationToken);
    }

    public async Task<Product> GetProductByIdAsync(int id, CancellationToken cancellationToken)
    {
        return await _context.Products.Include(p => p.ProductInfo).FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
    }

    public async Task<Product> CreateProductAsync(Product product, CancellationToken cancellationToken)
    {
        _context.Products.Add(product);
        await _context.SaveChangesAsync(cancellationToken);
        return product;
    }

    public async Task<Product> UpdateProductAsync(Product product, CancellationToken cancellationToken)
    {
        _context.Products.Update(product);
        await _context.SaveChangesAsync(cancellationToken);
        return product;
    }

    public async Task<bool> DeleteProductAsync(int id, CancellationToken cancellationToken)
    {
        var affectedRows = await _context.Orders.Where(o => o.Id == id).ExecuteDeleteAsync(cancellationToken);

        return affectedRows != 0;
    }
}
