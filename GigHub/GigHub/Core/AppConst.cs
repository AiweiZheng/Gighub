
using System.Security.Cryptography.X509Certificates;

namespace GigHub.Core
{
    public static class AppConst
    {
        //veb view 
        public const string UnfollowText = "Follow";
        public const string FollowingText = "Following";
        public const string NotGoingYetText = "Going ?";
        public const string GoingText = "Going";

        public const int PageSizeLg = 20;
        public const int PageSizeMd = 15;
        public const int PageSizeSm = 10;
        public const int PageSizeXs = 5;
        public const int CountOfGigPerLoad = 3;

        //web mvc controller
        public const string GigCannotBeNull = "Gig cannot be null";

        //bootstrap class wrapper
        public const string BsHide = "hide";
        public const string BsShow = "show";
    }
}