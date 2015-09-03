using System.Web;
using System.Web.Optimization;

namespace PhotoAlbum.PL
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/angularjs").Include(
                      "~/Scripts/angularjs/angular.min.js",
                      "~/Scripts/angularjs/checklist-model.js",
                //"~/Scripts/angularjs/angular-ui/ui-bootstrap.min.js",
                //"~/Scripts/angularjs/angular-ui/ui-bootstrap-tpls.min.js",
                      "~/Scripts/angularjs/angular-ui-router.js"/*,
                      "~/Scripts/angularjs/angular-route.min.js"*/));

            bundles.Add(new ScriptBundle("~/bundles/angularjs-api").Include(
                      "~/Scripts/angularjs-api/app.module.js",
                      "~/Scripts/angularjs-api/app-config.js",
                      "~/Scripts/angularjs-api/controllers/album-controller.js",
                      "~/Scripts/angularjs-api/controllers/category-controller.js",
                      "~/Scripts/angularjs-api/controllers/manage-tab-controller.js",
                      "~/Scripts/angularjs-api/controllers/photo-controller.js",
                      "~/Scripts/angularjs-api/controllers/user-controller.js",
                      "~/Scripts/angularjs-api/services/album-service.js",
                      "~/Scripts/angularjs-api/services/category-service.js",
                      "~/Scripts/angularjs-api/services/photo-service.js",
                      "~/Scripts/angularjs-api/services/user-service.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/darkly.bootstrap.min.css",
                //"~/Content/site.css",
                      "~/Content/styles.css"
                      ));
            bundles.Add(new StyleBundle("~/Content/custom-css").Include(
                     "~/Content/darkly.bootstrap.min.css",
                     "~/Content/esenin-script-two.css",
                     "~/Content/andantino-script.css",
                     "~/Content/styles.css"
                     ));
        }
    }
}
