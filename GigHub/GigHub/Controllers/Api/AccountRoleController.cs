using System.Linq;
using System.Web.Http;
using GigHub.Core;
using GigHub.Core.Dtos;
using GigHub.Core.Filters;
using GigHub.Core.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace GigHub.Controllers.Api
{
    [ActivatedAccountFilter]
    [Authorize(Roles = RoleName.AccountManager)]
    public class AccountRoleController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public AccountRoleController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPut]
        public IHttpActionResult UpdateUserRole(string id, [FromBody]RoleDto roleDto)
        {
            var user = _unitOfWork.Users.GetUser(id);
            var oldRole = user.Roles.FirstOrDefault();
            user.Roles.Remove(oldRole);
            user.Roles.Add(new IdentityUserRole { RoleId = roleDto.Id, UserId = user.Id });

            _unitOfWork.Complete();

            return Ok();
        }
    }
}
