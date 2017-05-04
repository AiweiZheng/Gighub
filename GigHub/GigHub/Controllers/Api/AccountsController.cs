using System.Linq;
using System.Web.Http;
using AutoMapper;
using GigHub.Core;
using GigHub.Core.Dtos;
using GigHub.Core.Filters;
using GigHub.Core.Models;

namespace GigHub.Controllers.Api
{
    [ActivatedAccountFilter]
    [Authorize(Roles = RoleName.AccountManager)]
    public class AccountsController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public AccountsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IHttpActionResult GetAccounts()
        {
            var roles = _unitOfWork.Roles.GetRoles().ToLookup(k => k.Id);

            var users = _unitOfWork.Users.GetUsers().ToList();

            users.ForEach(u => u.MapRoleToUser(u, roles));

            var accountDtos = users
                .ToList()
                .Select(Mapper.Map<ApplicationUser, UserDto>);

            return Ok(accountDtos);
        }
    }
}
