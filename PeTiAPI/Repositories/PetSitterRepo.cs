using Microsoft.EntityFrameworkCore;
using PeTiAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeTiAPI.Repositories
{
    public class PetSitterRepo : IPetSitterRepo
    {
        private readonly PeTiContext _context;

        public PetSitterRepo(PeTiContext context)
        {
            _context = context;
        }

        public void Create(PetSitter petSitter)
        {
            if (petSitter == null)
            {
                throw new ArgumentNullException(nameof(petSitter));
            }
            _context.PetSitters.Add(petSitter);
        }

        public async void Delete(Guid id)
        {
            var petSitterToDelete = await _context.PetSitters.FindAsync(id);
            _context.PetSitters.Remove(petSitterToDelete);
        }

        public IEnumerable<PetSitter> Get()
        {
            return _context.PetSitters.Include(p => p.Reviews).ToList();
        }

        public PetSitter Get(Guid id)
        {
            //_context.Reviews.include
            return _context.PetSitters.Include(p => p.Reviews).FirstOrDefault(p => p.Id == id);
        }
        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
        public void Update(PetSitter petSitter)
        {
            _context.Entry(petSitter).State = EntityState.Modified;
        }
    }
}
