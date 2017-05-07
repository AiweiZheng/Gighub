using System.Net;
using System.Web.Http;
using GigHub.Core;
using GigHub.Core.Dtos;
using GigHub.Core.Filters;
using GigHub.Core.Models;
using WebGrease.Css.Extensions;

namespace GigHub.Controllers.Api
{
    [AuthorizeActivatedAccount]
    [AuthorizeSingleLogin]
    [Authorize(Roles = RoleName.AccountManager)]
    public class AccountStatusController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public AccountStatusController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPut]
        public IHttpActionResult ChangeAccountStatus(string id, [FromBody]UserDto userDto)
        {
            var user = _unitOfWork.Users.GetUser(id);

            if (user == null)
                return Content(HttpStatusCode.BadRequest, ErrorMsg.NoUserFound);

            user.ChangeUserStatus(userDto.Activated);

            if (!userDto.Activated)
                _unitOfWork.Gigs.GetUpcomingGigsByArtist(id).ForEach(g => g.Cancel());

            _unitOfWork.Complete();

            return Ok();
        }
    }
}
