using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

public interface IReviewService
{
    Task<IEnumerable<Review>> GetAllReviewsAsync();
    Task<Review> GetReviewByIdAsync(int id);
    Task<Review> CreateReviewAsync(Review review);
    Task<Review> UpdateReviewAsync(Review review);
    Task<bool> DeleteReviewAsync(int id);
}



public class ReviewService : IReviewService
{
    private readonly ApplicationDbContext _context;

    public ReviewService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Review>> GetAllReviewsAsync()
    {
        return await _context.Reviews.Include(r => r.User).Include(r => r.Product).ToListAsync();
    }

    public async Task<Review> GetReviewByIdAsync(int id)
    {
        return await _context.Reviews.Include(r => r.User).Include(r => r.Product).FirstOrDefaultAsync(r => r.Id == id);
    }

    public async Task<Review> CreateReviewAsync(Review review)
    {
        _context.Reviews.Add(review);
        await _context.SaveChangesAsync();
        return review;
    }

    public async Task<Review> UpdateReviewAsync(Review review)
    {
        _context.Reviews.Update(review);
        await _context.SaveChangesAsync();
        return review;
    }

    public async Task<bool> DeleteReviewAsync(int id)
    {
        var review = await _context.Reviews.FindAsync(id);
        if (review == null) return false;

        _context.Reviews.Remove(review);
        await _context.SaveChangesAsync();
        return true;
    }
}
