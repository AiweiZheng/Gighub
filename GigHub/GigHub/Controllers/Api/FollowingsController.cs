﻿using System.Net;
using System.Web.Http;
using GigHub.Core;
using GigHub.Core.Dtos;
using GigHub.Core.Models;
using Microsoft.AspNet.Identity;

namespace GigHub.Controllers.Api
{
    [System.Web.Http.Authorize]
    public class FollowingsController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public FollowingsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [System.Web.Http.Authorize]
        [System.Web.Http.HttpPost]
        public IHttpActionResult Follow(FollowingDto followerDto)
        {
            var userId = User.Identity.GetUserId();

            if (_unitOfWork.Followings.GetFollowing(followerDto.FolloweeId, userId) != null)
                return Content(HttpStatusCode.BadRequest, "Following already exists.");

            var follower = new Following
            {
                FolloweeId = followerDto.FolloweeId,
                FollowerId = userId
            };

            _unitOfWork.Followings.Add(follower);
            _unitOfWork.Complete();

            return Ok();
        }

        [System.Web.Http.Authorize]
        [System.Web.Http.HttpDelete]
        public IHttpActionResult UnFollow(string id)
        {
            var userId = User.Identity.GetUserId();
            var following = _unitOfWork.Followings.GetFollowing(id, userId);

            if (following == null)
                return Content(HttpStatusCode.NotFound, "The following does not exist.");

            _unitOfWork.Followings.Remove(following);
            _unitOfWork.Complete();

            return Ok(id);
        }
    }
}
