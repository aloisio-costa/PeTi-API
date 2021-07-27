using System;
using PeTiAPI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeTiAPI.Repositories
{
    public interface IReviewRepo
    {
        IEnumerable<Review> Get();
        IEnumerable<Review> GetAllSameId(Guid id);
        Review Get(Guid id);
        void Create(Review review);
        void Delete(Guid id);
        bool SaveChanges();
    }
}
