using System.Web;
using System.Web.Optimization;

namespace WebRole1
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
#if !DEBUG
            // Enable optimizations to force bundling and minification (and CDN usage if configured)
            BundleTable.EnableOptimizations = true;
#endif

            bundles.UseCdn = true;

            var jqueryCdnPath = "https://ajax.aspnetcdn.com/ajax/jQuery/jquery-3.3.1.min.js";
            bundles.Add(new ScriptBundle("~/bundles/jquery", jqueryCdnPath).Include(
                        "~/Scripts/jquery-{version}.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            var bootstrapCdnPath = "https://ajax.aspnetcdn.com/ajax/bootstrap/3.4.1/bootstrap.min.js";
            bundles.Add(new ScriptBundle("~/bundles/bootstrap", bootstrapCdnPath).Include(
                      "~/Scripts/bootstrap.js"));

            // Split bootstrap css to use CDN, and site css to remain local
            var bootstrapCssCdnPath = "https://ajax.aspnetcdn.com/ajax/bootstrap/3.4.1/css/bootstrap.min.css";
            bundles.Add(new StyleBundle("~/Content/bootstrap", bootstrapCssCdnPath).Include(
                      "~/Content/bootstrap.css"));

            bundles.Add(new StyleBundle("~/Content/site").Include(
                      "~/Content/site.css"));
        }
    }
}
