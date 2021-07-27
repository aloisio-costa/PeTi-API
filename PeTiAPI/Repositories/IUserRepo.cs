using PeTiAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeTiAPI.Repositories
{
    public interface IUserRepo
    {
        User Create(User user);
        User GetByEmail(string email);
        User GetById(Guid id);
    }
}
