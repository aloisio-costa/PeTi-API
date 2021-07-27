using Microsoft.EntityFrameworkCore;
using PeTiAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeTiAPI.Repositories
{
    public class ServiceRequestRepo : IServiceRequestRepo
    {
        private readonly PeTiContext _context;

        public ServiceRequestRepo(PeTiContext context)
        {
            _context = context;
        }

        public async Task<ServiceRequest> Create(ServiceRequest serviceRequest)
        {
            if (serviceRequest == null)
            {
                throw new ArgumentNullException(nameof(serviceRequest));
            }
            _context.ServiceRequests.Add(serviceRequest);
            await _context.SaveChangesAsync();

            return serviceRequest;
        }

        public async Task Delete(Guid id)
        {
            var serviceRequestToDelete = await _context.ServiceRequests.FindAsync(id);
            _context.ServiceRequests.Remove(serviceRequestToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ServiceRequest>> Get()
        {
            return await _context.ServiceRequests.ToListAsync();
        }

        public async Task<ServiceRequest> Get(Guid id)
        {
            return await _context.ServiceRequests.FindAsync(id);
        }

        public async Task Update(ServiceRequest serviceRequest)
        {
            _context.Entry(serviceRequest).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
