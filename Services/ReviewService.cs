using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

public interface IReviewService
{
    Task<IEnumerable<Review>> GetAllReviewsAsync(CancellationToken cancellationToken);
    Task<Review> GetReviewByIdAsync(int id, CancellationToken cancellationToken);
    Task<Review> CreateReviewAsync(Review review, CancellationToken cancellationToken);
    Task<Review> UpdateReviewAsync(Review review, CancellationToken cancellationToken);
    Task<bool> DeleteReviewAsync(int id, CancellationToken cancellationToken);
}



public class ReviewService : IReviewService
{
    private readonly ApplicationDbContext _context;

    public ReviewService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Review>> GetAllReviewsAsync(CancellationToken cancellationToken)
    {
        return await _context.Reviews.Include(r => r.User).Include(r => r.Product).ToListAsync(cancellationToken);
    }

    public async Task<Review> GetReviewByIdAsync(int id, CancellationToken cancellationToken)
    {
        return await _context.Reviews.Include(r => r.User).Include(r => r.Product).FirstOrDefaultAsync(r => r.Id == id, cancellationToken);
    }

    public async Task<Review> CreateReviewAsync(Review review, CancellationToken cancellationToken)
    {
        _context.Reviews.Add(review);
        await _context.SaveChangesAsync(cancellationToken);
        return review;
    }

    public async Task<Review> UpdateReviewAsync(Review review, CancellationToken cancellationToken)
    {
        _context.Reviews.Update(review);
        await _context.SaveChangesAsync(cancellationToken);
        return review;
    }

    public async Task<bool> DeleteReviewAsync(int id, CancellationToken cancellationToken)
    {
        var review = await _context.Reviews.FindAsync(id, cancellationToken);
        if (review == null) return false;

        _context.Reviews.Remove(review);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}
