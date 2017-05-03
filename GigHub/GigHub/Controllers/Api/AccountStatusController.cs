using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using GigHub.Core;
using GigHub.Core.Dtos;

namespace GigHub.Controllers.Api
{
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
                return Content(HttpStatusCode.BadRequest, "No User found.");

            user.ChangeUserStatus(userDto.Activated);

            _unitOfWork.Complete();

            return Ok();
        }
    }
}
