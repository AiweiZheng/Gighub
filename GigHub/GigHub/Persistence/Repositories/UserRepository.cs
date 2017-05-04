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

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}