using System.Web.Optimization;

namespace GigHub
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/app").Include(
                        "~/scripts/app/bootbox/dialogs.js",
                        "~/scripts/app/services/attendanceService.js",//should before controller. look for "requirejs" for better solution
                        "~/scripts/app/controllers/gigsController.js",
                        "~/scripts/app/services/followingService.js",
                        "~/scripts/app/controllers/followingsController.js",
                        "~/scripts/app/services/notificationService.js",
                        "~/scripts/app/controllers/notificationController.js",
                        "~/scripts/app/services/gigActionsService.js",
                        "~/scripts/app/controllers/gigActionsController.js",
                        "~/scripts/app/services/accountStatusService.js",
                        "~/scripts/app/controllers/accountStatusController.js",
                        "~/scripts/app/app.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/lib").Include(
                         "~/Scripts/bootstrap.js",
                         "~/Scripts/respond.js",
                         "~/Scripts/bootbox.min.js",
                         "~/Scripts/jquery-{version}.js",
                         "~/Scripts/underscore-min.js",
                         "~/Scripts/dataTables/jquery.datatables.js",
                         "~/Scripts/dataTables/datatables.bootstrap.js",
                         "~/Scripts/moment.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/datatables/css/datatables.bootstrap.css",
                "~/Content/Animate.css"));
        }
    }
}
