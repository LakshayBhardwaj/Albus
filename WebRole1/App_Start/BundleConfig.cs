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
            // Force optimization to be on in Release mode, regardless of Web.config debug setting
            BundleTable.EnableOptimizations = true;
#endif

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

            // Split bootstrap css to use CDN, and site css to remain local
            var bootstrapCssCdnPath = "https://ajax.aspnetcdn.com/ajax/bootstrap/3.4.1/css/bootstrap.min.css";
            bundles.Add(new StyleBundle("~/Content/bootstrap", bootstrapCssCdnPath).Include(
                      "~/Content/bootstrap.css"));

            bundles.Add(new StyleBundle("~/Content/site").Include(
                      "~/Content/site.css"));
        }
    }
}
