using System.Web.Optimization;

namespace TestDemo
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery-ui-1.10.4.custom.js",
                        "~/Scripts/i18n/grid.locale-en.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/spin").Include(
                       "~/Scripts/spin.js*"));

            bundles.Add(new ScriptBundle("~/bundles/grid").Include(
                      "~/Scripts/jquery.jqGrid.js"));

            bundles.Add(new ScriptBundle("~/bundles/home").Include(
                     "~/Scripts/Home/home.js"));

            bundles.Add(new ScriptBundle("~/bundles/potionrecipie").Include(
                   "~/Scripts/PotionRecipie/PotionRecipie.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/themes/base/jquery-ui-1.10.4.custom.css",
                      "~/Content/jquery.jqGrid/ui.jqgrid.css"));

            // Set EnableOptimizations to false for debugging. For more information,
            // visit http://go.microsoft.com/fwlink/?LinkId=301862
            BundleTable.EnableOptimizations = true;
        }
    }
}
