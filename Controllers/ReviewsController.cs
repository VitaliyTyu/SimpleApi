using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class ReviewsController : ControllerBase
{
    private readonly IReviewService _reviewService;

    public ReviewsController(IReviewService reviewService)
    {
        _reviewService = reviewService;
    }

    /// <summary>
    /// Gets all reviews.
    /// </summary>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<Review>), 200)]
    public async Task<ActionResult<IEnumerable<Review>>> GetReviews(CancellationToken cancellationToken)
    {
        var reviews = await _reviewService.GetAllReviewsAsync(cancellationToken);
        return Ok(reviews);
    }

    /// <summary>
    /// Gets a review by ID.
    /// </summary>
    /// <param name="id">The ID of the review.</param>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(Review), 200)]
    [ProducesResponseType(404)]
    public async Task<ActionResult<Review>> GetReview(int id, CancellationToken cancellationToken)
    {
        var review = await _reviewService.GetReviewByIdAsync(id, cancellationToken);
        if (review == null)
        {
            return NotFound();
        }
        return Ok(review);
    }

    /// <summary>
    /// Creates a new review.
    /// </summary>
    /// <param name="review">The review to create.</param>
    [HttpPost]
    [ProducesResponseType(typeof(Review), 201)]
    [ProducesResponseType(400)]
    public async Task<ActionResult<Review>> CreateReview(Review review, CancellationToken cancellationToken)
    {
        var createdReview = await _reviewService.CreateReviewAsync(review, cancellationToken);
        return CreatedAtAction(nameof(GetReview), new { id = createdReview.Id }, createdReview);
    }

    /// <summary>
    /// Updates an existing review.
    /// </summary>
    /// <param name="id">The ID of the review.</param>
    /// <param name="review">The updated review.</param>
    [HttpPut("{id}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> UpdateReview(int id, Review review, CancellationToken cancellationToken)
    {
        if (id != review.Id)
        {
            return BadRequest();
        }

        var existingReview = await _reviewService.GetReviewByIdAsync(id, cancellationToken);
        if (existingReview == null)
        {
            return NotFound();
        }

        await _reviewService.UpdateReviewAsync(review, cancellationToken);
        return NoContent();
    }

    /// <summary>
    /// Deletes a review by ID.
    /// </summary>
    /// <param name="id">The ID of the review.</param>
    [HttpDelete("{id}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> DeleteReview(int id, CancellationToken cancellationToken)
    {
        var result = await _reviewService.DeleteReviewAsync(id, cancellationToken);
        if (!result)
        {
            return NotFound();
        }

        return NoContent();
    }
}
