using System.Web;
using System.Web.Optimization;

namespace WebRole1
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            // Enable CDN usage
            bundles.UseCdn = true;

            // Use CDN for jQuery
            var jqueryBundle = new ScriptBundle("~/bundles/jquery", "https://code.jquery.com/jquery-3.3.1.min.js");
            jqueryBundle.Include("~/Scripts/jquery-{version}.js");
            jqueryBundle.CdnFallbackExpression = "window.jQuery";
            bundles.Add(jqueryBundle);

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            // Use CDN for Bootstrap
            var bootstrapBundle = new ScriptBundle("~/bundles/bootstrap", "https://stackpath.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js");
            bootstrapBundle.Include("~/Scripts/bootstrap.js");
            bootstrapBundle.CdnFallbackExpression = "window.jQuery.fn.modal";
            bundles.Add(bootstrapBundle);

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
        }
    }
}
