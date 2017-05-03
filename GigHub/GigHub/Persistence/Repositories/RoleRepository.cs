using System.Collections.Generic;
using System.Linq;
using GigHub.Core.Repositories;
using Microsoft.AspNet.Identity.EntityFramework;

namespace GigHub.Persistence.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly IApplicationDbContext _context;

        public RoleRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<IdentityRole> GetRoles()
        {
            return _context.Roles.ToList();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}