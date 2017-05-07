using System.Collections.Generic;
using GigHub.Core.Models;

namespace GigHub.Core.Repositories
{
    public interface IUserRepository
    {
        IEnumerable<ApplicationUser> GetUsers();
        ApplicationUser GetUser(string id);
        IEnumerable<ApplicationUser> GetUsersByRoleId(string roleId);
        string GetUserDescriptionBy(string id);
        void Dispose();
    }
}