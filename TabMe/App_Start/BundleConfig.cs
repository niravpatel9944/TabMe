using System.Web;
using System.Web.Optimization;

namespace TabMe
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Content/assets/js/jquery.min.js",
                        "~/Content/assets/js/tether.min.js",
                        "~/Content/assets/js/bootstrap.min.js",
                        "~/Content/assets/js/jquery.slimscroll.min.js",
                        "~/Content/assets/js/perfect-scrollbar.jquery.min.js",
                        "~/Content/assets/js/sweetalert.min.js",
                        "~/Content/assets/js/switchery.min.js",
                        "~/Content/assets/js/jquery.waypoints.min.js",
                        "~/Content/assets/js/sticky.min.js",
                        "~/Content/assets/js/jquery.counterup.min.js",
                        "~/Content/assets/js/firstlitter.js",
                        "~/Content/assets/js/video-modal.js",
                        "~/Content/assets/js/echarts.min.js",
                        "~/Content/assets/js/jquery.sparkline.min.js",
                        "~/Content/assets/js/owl.carousel.min.js",
                        "~/Content/assets/js/fileinput.min.js",
                        "~/Content/assets/js/wysihtml5-0.3.0.js",
                        "~/Content/assets/js/bootstrap-wysihtml5.js",
                        "~/Content/assets/js/moment.min.js",
                        "~/Content/assets/js/bootstrap-datepicker.min.js",
                        "~/Content/assets/js/selectize.js",
                        "~/Content/assets/js/main.js",
                        "~/Content/assets/js/site.js",
                        "~/Content/assets/js/menubar.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                    "~/Content/assets/css/font-awesome.min.css",
                    "~/Content/assets/css/material-design-iconic-font.css",
                    "~/Content/assets/css/bootstrap.css",
                    "~/Content/assets/css/animate.min.css",
                    "~/Content/assets/css/sweetalert.css",
                    "~/Content/assets/css/switchery.min.css",
                    "~/Content/assets/css/hamburgers.css",
                    "~/Content/assets/css/perfect-scrollbar.min.css",
                    "~/Content/assets/css/demos.css",
                    "~/Content/assets/css/site.css",
                    "~/Content/assets/css/fileinput.min.css",
                    "~/Content/assets/css/selectize.default.css",
                    "~/Content/assets/css/selectize.bootstrap3.css",
                    "~/Content/assets/css/dashboard.v1.css",
                    "~/Content/assets/css/bootstrap-wysihtml5.css",
                    "~/Content/assets/css/bootstrap-datepicker.min.css"));
        }
    }
}
