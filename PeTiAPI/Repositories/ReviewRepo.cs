using Microsoft.EntityFrameworkCore;
using PeTiAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeTiAPI.Repositories
{
    public class ReviewRepo : IReviewRepo
    {
        private readonly PeTiContext _context;
        public ReviewRepo(PeTiContext context)
        {
            _context = context;
        }
        public void Create(Review review)
        {
            if (review == null)
            {
                throw new ArgumentNullException(nameof(review));
            }
            _context.Reviews.Add(review);
        }

        public async void Delete(Guid id)
        {
            var reviewToDelete = await _context.Reviews.FindAsync(id);
            _context.Reviews.Remove(reviewToDelete);
        }

        public IEnumerable<Review> Get()
        {
            return _context.Reviews.ToList();
        }
        public Review Get(Guid id)
        {
            return _context.Reviews.FirstOrDefault(p => p.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
        public IEnumerable<Review> GetAllSameId(Guid id)
        {
            return _context.Reviews.Where(c => c.PetSitterId == id).ToList();
        }
    }
}
