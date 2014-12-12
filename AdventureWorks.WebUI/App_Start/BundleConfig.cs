using System.Web.Optimization;

namespace AdventureWorks.WebUI
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/css").Include("~/css/bootstrap.css")
                                                .Include("~/css/amelia.bootstrap.css")
                                                .Include("~/css/font-awesome.css")
                                                .Include("~/css/site.css")
                                                .Include("~/css/angular-block-ui.css"));

            bundles.Add(new ScriptBundle("~/scripts/angular").Include("~/scripts/angular.js")
                                                             .Include("~/scripts/angular-route.js")
                                                             .Include("~/scripts/jquery-2.1.1.js")
                                                             .Include("~/scripts/bootstrap.js")
                                                             .Include("~/scripts/angular-ui/ui-bootstrap.js")
                                                             .Include("~/scripts/angular-ui/ui-bootstrap-tpls.js"));


            bundles.Add(new ScriptBundle("~/scripts/app").IncludeDirectory("~/app", "*.js", true));
        }
    }
}