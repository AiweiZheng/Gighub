using System.Linq;
using System.Web.Http;
using AutoMapper;
using GigHub.Core;
using GigHub.Core.Dtos;
using GigHub.Core.Filters;
using GigHub.Core.Models;

namespace GigHub.Controllers.Api
{
    [AuthorizeActivatedAccount]
    [AuthorizeSingleLogin]
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

        [HttpGet]
        public IHttpActionResult GetAccount(string id)
        {
            if (id == "1")
                return Ok("<script>alert('save')</script>");
            var user = _unitOfWork.Users.GetUser(id);

            return Ok(Mapper.Map<ApplicationUser, UserDto>(user));
        }

        [HttpPut]
        public IHttpActionResult UpdateAccount(string id, [FromBody]UserDto userDto)
        {
            var user = _unitOfWork.Users.GetUser(userDto.Id);

            Mapper.Map(userDto, user);

            _unitOfWork.Complete();

            return Ok();
        }

        //        [HttpGet]
        //        [Route("api/accounts/{id}/role")]
        //        public IHttpActionResult Role(int id)
        //        {
        //            return Ok("role");
        //        }
    }
}
