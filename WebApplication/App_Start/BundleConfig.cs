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
                "~/Scripts/App/app.js",
                "~/Scripts/App/Services/settings.js",
                "~/Scripts/App/Services/messenger.js",
                "~/Scripts/App/Services/data-context.js",
                "~/Scripts/App/Directives/autocomplete.js",
                "~/Scripts/App/Directives/load-image-fail.js",
                "~/Scripts/App/Directives/modal.js",
                "~/Scripts/App/Controllers/main.js"
                ));
        }
    }
}
