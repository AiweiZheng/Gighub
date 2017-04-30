using System.Collections.Generic;
using GigHub.Models;

namespace GigHub.Repositories
{
    public interface IGigRepository
    {
        Gig GetGigWithAttendantees(int gigId);
        IEnumerable<Gig> GetUpcomingGigsByArtist(string userId);
        IEnumerable<Gig> GetUpcomingGigs(string filter = null);
        Gig GetGig(int gigId);
        IEnumerable<Gig> GetGigsUserAttending(string userId);
        Gig GetAttendancesInGig(int gigId, string artistId);
        void Add(Gig gig);
    }
}