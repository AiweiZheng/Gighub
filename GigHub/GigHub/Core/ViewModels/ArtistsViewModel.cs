using System.Collections.Generic;
using System.Linq;
using GigHub.Core.Models;

namespace GigHub.Core.ViewModels
{
    public class ArtistsViewModel
    {
        public IEnumerable<ApplicationUser> Artists { get; set; }
        public ILookup<string, Gig> Gigs { get; set; }
        public ILookup<int, Attendance> Attendances { get; set; }
        public ILookup<string, Following> Followings { get; set; }
        public bool ShowActions { get; set; }
    }
}