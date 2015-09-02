﻿using System.Web;
using System.Web.Optimization;

namespace disk.web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js", "~/Scripts/jquery.validate*"));

            //bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
            //            "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.min.js",
                      "~/Scripts/respond.js"));
            
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/css/bootstrap.min.css",
                      "~/Content/css/bootstrap-theme.min.css",
                      "~/Content/css/site.css"));
            

            //index
            bundles.Add(new ScriptBundle("~/bundles/index").Include(
                     "~/Scripts/jquery.easyui.min.js",
                     "~/Scripts/jquery.ztree.core-{version}.js",
                     "~/Scripts/Index.js"));
            bundles.Add(new StyleBundle("~/Content/css/index").Include(
                      "~/Content/css/site.css",
                      "~/Content/css/themes/bootstrap/easyui.css",
                      "~/Content/css/themes/themes/icon.css",
                      "~/Content/css/zTreeStyle/zTreeStyle.css"));
        }
    }
}
