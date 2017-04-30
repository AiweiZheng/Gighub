using System.Linq;
using System.Web.Mvc;
using GigHub.Models;
using GigHub.Repositories;
using GigHub.ViewModels;
using Microsoft.AspNet.Identity;

namespace GigHub.Controllers
{
    public class HomeController : Controller
    {
        private readonly AttendanceRepository _attendanceRepository;
        private readonly GigRepository _gigRepository;

        public HomeController()
        {
            var context = new ApplicationDbContext();
            _attendanceRepository = new AttendanceRepository(context);
            _gigRepository = new GigRepository(context);
        }
        public ActionResult Index(string query = null)
        {
            var upcomingGigs = _gigRepository.GetUpcomingGigs(query);

            string userId = User.Identity.GetUserId();

            var attendances = _attendanceRepository.GetFutureAttendances(userId)
                .ToLookup(a => a.GigId);

            var viewModel = new GigsViewModel
            {
                UpcomingGigs = upcomingGigs,
                ShowActions = User.Identity.IsAuthenticated,
                Heading = "Upcoming Gigs",
                SearchTerm = query,
                Attendances = attendances

            };

            return View("Gigs", viewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}