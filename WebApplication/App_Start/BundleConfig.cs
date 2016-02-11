using System.Web.Optimization;

namespace WebApplication
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/site.css"));

            bundles.Add(new ScriptBundle("~/bundles/app").Include(
                "~/Scripts/bootstrap3-typeahead.js",
                "~/Scripts/app/app.js",
                "~/Scripts/app/services/settings.js",
                "~/Scripts/app/services/data-context.js",
                "~/Scripts/app/directives/autocomplete.js",
                "~/Scripts/app/directives/modal.js",
                "~/Scripts/app/controllers/main.js"
                ));
        }
    }
}
