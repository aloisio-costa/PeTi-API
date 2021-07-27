using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PeTiAPI.Dtos.Reviews;
using PeTiAPI.Models;
using PeTiAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeTiAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly IReviewRepo _reviewRepository;
        private readonly IMapper _mapper;

        public ReviewsController(IReviewRepo reviewRepository, IMapper mapper)
        {
            _reviewRepository = reviewRepository;
            _mapper = mapper;
        }   

        [HttpGet]
        public ActionResult<IEnumerable<ReviewReadDTO>> GetReviews()
        {
            var reviews = _reviewRepository.Get();
            return Ok(_mapper.Map<IEnumerable<ReviewReadDTO>>(reviews));
        }

        [HttpGet("{id}")]
        public ActionResult<IEnumerable<ReviewReadDTO>> GetAllSameId(Guid id)
        {
            var review = _reviewRepository.GetAllSameId(id);
            if (review != null)
            {
                return Ok(_mapper.Map<IEnumerable<ReviewReadDTO>>(review));
            }

            return NotFound();
        }

        [HttpPost]
        public ActionResult<Review> CreateReviews([FromBody] ReviewCreateDTO review)
        {
            var ReviewModel = _mapper.Map<Review>(review);
            _reviewRepository.Create(ReviewModel);
            _reviewRepository.SaveChanges();

            var newReview = _mapper.Map<ReviewReadDTO>(ReviewModel);

            return CreatedAtAction(nameof(GetReviews), new { id = newReview.Id }, newReview);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            var reviewToDelete = _reviewRepository.Get(id);
            if (reviewToDelete == null)
            {
                return NotFound();
            }

            _reviewRepository.Delete(reviewToDelete.Id);
            _reviewRepository.SaveChanges();

            return NoContent();
        }
    }
}
