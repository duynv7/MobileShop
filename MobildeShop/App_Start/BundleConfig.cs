using System.Web.Optimization;

namespace IdentitySample
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/plugins/jquery-slimscroll/jquery.slimscroll.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js",
                      "~/Content/plugins/bootstrap-select/js/bootstrap-select.js"
                      ));

            bundles.Add(new ScriptBundle("~/bundles/otherjs").Include(
                      "~/Content/js/admin.js",
                      "~/Content/js/demo.js",
                      "~/Content/js/helper.js",
                      "~/Content/js/script.js",
                      "~/Scripts/respond.js"
                      ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/css/bootstrap.min.css",
                      "~/Content/css/style.css",
                      "~/Content/css/themes/all-themes.css",
                      "~/Content/plugins/node-waves/waves.css",
                      "~/Content/plugins/animate-css/animate.css",
                      "~/Content/plugins/morrisjs/morris.css"
                      ));
        }
    }
}
