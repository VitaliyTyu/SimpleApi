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
    public async Task<ActionResult<IEnumerable<Review>>> GetReviews()
    {
        var reviews = await _reviewService.GetAllReviewsAsync();
        return Ok(reviews);
    }

    /// <summary>
    /// Gets a review by ID.
    /// </summary>
    /// <param name="id">The ID of the review.</param>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(Review), 200)]
    [ProducesResponseType(404)]
    public async Task<ActionResult<Review>> GetReview(int id)
    {
        var review = await _reviewService.GetReviewByIdAsync(id);
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
    public async Task<ActionResult<Review>> CreateReview(Review review)
    {
        var createdReview = await _reviewService.CreateReviewAsync(review);
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
    public async Task<IActionResult> UpdateReview(int id, Review review)
    {
        if (id != review.Id)
        {
            return BadRequest();
        }

        var existingReview = await _reviewService.GetReviewByIdAsync(id);
        if (existingReview == null)
        {
            return NotFound();
        }

        await _reviewService.UpdateReviewAsync(review);
        return NoContent();
    }

    /// <summary>
    /// Deletes a review by ID.
    /// </summary>
    /// <param name="id">The ID of the review.</param>
    [HttpDelete("{id}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> DeleteReview(int id)
    {
        var result = await _reviewService.DeleteReviewAsync(id);
        if (!result)
        {
            return NotFound();
        }

        return NoContent();
    }
}
