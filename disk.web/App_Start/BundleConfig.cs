using System.Web;
using System.Web.Optimization;

namespace disk.web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Content/js/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Content/js/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Content/js/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Content/js/bootstrap.min.js",
                      "~/Content/js/respond.js"));
            
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/css/bootstrap.min.css",
                      "~/Content/css/bootstrap-theme.min.css",
                      "~/Content/css/themes/default/easyui.css",
                      "~/Content/css/themes/icon.css",
                      "~/Content/css/site.css"));
            

            //index
            bundles.Add(new ScriptBundle("~/bundles/index").Include(
                     "~/Content/js/jquery.easyui.min.js",
                     "~/Content/js/Index.js"));
            bundles.Add(new StyleBundle("~/Content/css/index").Include(
                      "~/Content/css/site.css",
                      "~/Content/css/themes/bootstrap/easyui.css",
                      "~/Content/css/themes/icon.css"));

            //easyui
            bundles.Add(new ScriptBundle("~/bundles/easyui").Include(
                     "~/Content/js/jquery.easyui.min.js"));

            //ueditor
            bundles.Add(new ScriptBundle("~/bundles/ueditor").Include(
                    "~/Content/ueditor/ueditor.config.js",
                    "~/Content/ueditor/ueditor.all.min.js"));
        }
    }
}
