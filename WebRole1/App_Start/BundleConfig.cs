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
            var modernizrBundle = new ScriptBundle("~/bundles/modernizr", "https://cdnjs.cloudflare.com/ajax/libs/modernizr/2.8.3/modernizr.min.js");
            modernizrBundle.Include("~/Scripts/modernizr-*");
            modernizrBundle.CdnFallbackExpression = "window.Modernizr";
            bundles.Add(modernizrBundle);

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
