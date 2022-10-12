﻿using System.Web;
using System.Web.Optimization;

namespace KnowledgeHubPortal
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            // Create our own Bundles

            bundles.Add(new ScriptBundle("~/myscriptbundle")
                .Include("~/Scripts/bootstrap.js")
                .Include("~/Scripts/jquery-3.4.1.js")
                .Include("~/Scripts/jquery.validate.js")
                );

            bundles.Add(new StyleBundle("~/mystylebundle")
                .Include("~/Content/bootstrap.min.css")
                .Include("~/Content/Site.css")
                );


            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            BundleTable.EnableOptimizations = true;
        }
    }
}
