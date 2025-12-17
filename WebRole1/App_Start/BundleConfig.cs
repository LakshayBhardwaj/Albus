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

            // Note: CDN versions must match the local versions installed via NuGet (see packages.config).
            // If you update the NuGet packages, update these URLs accordingly.
            var jqueryCdnPath = "https://code.jquery.com/jquery-3.3.1.min.js";
            var jqueryBundle = new ScriptBundle("~/bundles/jquery", jqueryCdnPath).Include(
                        "~/Scripts/jquery-{version}.js");
            jqueryBundle.CdnFallbackExpression = "window.jQuery";
            bundles.Add(jqueryBundle);

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            var bootstrapCdnPath = "https://stackpath.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js";
            var bootstrapBundle = new ScriptBundle("~/bundles/bootstrap", bootstrapCdnPath).Include(
                      "~/Scripts/bootstrap.js");
            bootstrapBundle.CdnFallbackExpression = "window.jQuery.fn.modal";
            bundles.Add(bootstrapBundle);

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
        }
    }
}
