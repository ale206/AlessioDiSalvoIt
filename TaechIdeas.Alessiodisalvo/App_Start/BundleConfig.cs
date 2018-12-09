using System.Web.Optimization;

namespace TaechIdeas.Alessiodisalvo
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/js/jquery.min.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                "~/Scripts/js/modernizr.custom.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueries").Include(
                "~/Scripts/js/sidebarEffects.js",
                "~/Scripts/js/classie.js",
                "~/Scripts/js/custom.js",
                "~/Scripts/js/jquery.infinitescroll.js",
                "~/Scripts/js/jquery.ketchup.all.min.js"
                ));

            bundles.Add(new StyleBundle("~/bundles/css").Include(
                "~/Content/Css/normalize.css",
                "~/Content/Css/font-awesome.css",
                "~/Content/Css/styles.css",
                "~/Content/Css/responsive.css"));
        }
    }
}