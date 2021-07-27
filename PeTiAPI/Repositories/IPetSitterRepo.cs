using PeTiAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeTiAPI.Repositories
{
    public interface IPetSitterRepo
    {
        IEnumerable<PetSitter> Get();
        PetSitter Get(Guid id);
        void Create(PetSitter petSitter);
        void Update(PetSitter petSitter);
        void Delete(Guid id);
        bool SaveChanges();
    }
}

