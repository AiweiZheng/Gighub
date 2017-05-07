using System.Web.Http;
using GigHub.Core;
using GigHub.Core.Models;

namespace GigHub.Controllers.Api
{
    [Authorize(Roles = RoleName.AccountManager)]
    public class AccountDescriptionController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public AccountDescriptionController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IHttpActionResult GetDescription(string id)
        {
            var userDescription = _unitOfWork.Users.GetUserDescriptionBy(id);

            return Ok(userDescription);
        }
        //
        //
        //        [HttpPut]
        //        public IHttpActionResult UpdateDescription(int id, [FromBody]string description)
        //        {
        //            var userDescription = _unitOfWork.UserDescriptions.GetUserDescriptionBy(id);
        //
        //            if (userDescription == null)
        //                return Content(HttpStatusCode.NotFound, ErrorMsg.NotUserDescriptionFound);
        //
        //            userDescription.Descr = description;
        //
        //            _unitOfWork.Complete();
        //
        //            return Ok();
        //        }

    }
}
