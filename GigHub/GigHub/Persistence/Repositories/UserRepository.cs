using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using GigHub.Core.Models;
using GigHub.Core.Repositories;

namespace GigHub.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IApplicationDbContext _context;

        public UserRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<ApplicationUser> GetUsers()
        {
            return _context.Users.Include(u => u.Roles).ToList();
        }

        public ApplicationUser GetUser(string id)
        {
            return _context.Users.Include(u => u.Roles).FirstOrDefault(u => u.Id == id);
        }

        public IEnumerable<ApplicationUser> GetUsersByRoleId(string roleId)
        {
            return _context.Users
                .Where(
                    u => u.Activated
                    && u.Roles.Any(r => r.RoleId == roleId)
                ).ToList();
        }

        public string GetUserDescriptionBy(string id)
        {
            return _context.Users.Single(u => u.Id == id).Description;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}