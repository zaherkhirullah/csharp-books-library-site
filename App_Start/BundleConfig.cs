using System.Web;
using System.Web.Optimization;

namespace ZHYR_Library
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/Scripts").Include(
                    "~/Scripts/js/main.js",
                    "~/Scripts/js/material.min.js",
                    "~/Scripts/js/vendor/imagesloaded.pkgd.min.js",
                    "~/Scripts/js/vendor/isotope.pkgd.min.js",
                    "~/Scripts/js/vendor/slick.min.js",
                    "~/Scripts/js/contact.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                    "~/Content/bootstrap.css"));

            bundles.Add(new StyleBundle("~/Content/Styles").Include(
                      "~/Content/Styles/chocolat.css",
                      "~/Content/Styles/font-awesome.min.css",
                      "~/Content/Styles/main.css",
                      "~/Content/Styles/material-kit.css",
                      "~/Content/Styles/slick.css",
                      "~/Content/site.css"
                      ));

            /// Admin Layouyt 
               bundles.Add(new StyleBundle("~/Content/admin/css").Include(
            "~/Content/bootstrap.css",
            "~/Content/admin/material-dashboard.css",
            "~/Content/admin/demo.css"
            ));
            bundles.Add(new ScriptBundle("~/bundles/admin/Scripts").Include(
             "~/Scripts/admin/chartist.min.js",
             "~/Scripts/admin/bootstrap-notify.js",
             "~/Scripts/admin/material-dashboard.js",
             "~/Scripts/admin/demo.js"));


        }
    }
}
