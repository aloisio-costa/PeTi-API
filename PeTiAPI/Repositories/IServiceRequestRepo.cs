using PeTiAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeTiAPI.Repositories
{
    public interface IServiceRequestRepo
    {
        Task<IEnumerable<ServiceRequest>> Get();
        Task<ServiceRequest> Get(Guid id);
        Task<ServiceRequest> Create(ServiceRequest petSitter);
        Task Update(ServiceRequest petSitter);
        Task Delete(Guid id);
    }
}
