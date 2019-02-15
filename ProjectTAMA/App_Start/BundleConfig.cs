using System.Web;
using System.Web.Optimization;

namespace ProjectTAMA
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            //bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            //            "~/Scripts/jquery-{version}.js"));

            //bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
            //            "~/Scripts/jquery.validate*"));

            //// Use the development version of Modernizr to develop with and learn from. Then, when you're
            //// ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            //bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            //            "~/Scripts/modernizr-*"));

            //bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
            //          "~/Scripts/bootstrap.js",
            //          "~/Scripts/respond.js"));

            //bundles.Add(new StyleBundle("~/Content/css").Include(
            //          "~/Content/bootstrap.css",
            //          "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Theme/tour/css").Include(
                     "~/Theme/tour/css/animate.css",
                     "~/Theme/tour/css/icomoon.css",
                     "~/Theme/tour/css/bootstrap.css",
                    //" ~/Theme / tour / css / magnific - popup.css",
                    "~/Theme/tour/css/flexslider.css",
                    "~/Theme/tour/css/owl.carousel.min.css",
                    "~/Theme/tour/css/owl.theme.default.min.css",
                    "~/Theme/tour/css/style.css"));

            bundles.Add(new StyleBundle("~/Theme/tour/fonts").Include(
                    //"~/Theme / tour / css / bootstrap-datepicker.css",
                   "~/Theme/tour/fonts/flaticon/font/flaticon.css"
                   ));

            bundles.Add(new ScriptBundle("~/Theme/tour/js").Include(
                     "~/Theme/tour/js/jquery.min.js",
                    "~/Theme/tour/js/jquery.easing.1.3.js",
                    "~/Theme/tour/js/bootstrap.min.js",
                    "~/Theme/tour/js/jquery.waypoints.min.js",
                    "~/Theme/tour/js/jquery.flexslider-min.js",
                    "~/Theme/tour/js/owl.carousel.min.js",
                    "~/Theme/tour/js/jquery.magnific-popup.min.js",
                    "~/Theme/tour/js/magnific-popup-options.js",
                    "~/Theme/tour/js/bootstrap-datepicker.js",
                    "~/Theme/tour/js/jquery.stellar.min.js",
                    "~/Theme/tour/js/main.js"
                    ));
        }
    }
}
