using System.Web;
using System.Web.Optimization;

namespace OnlineShopTEDU
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {

            bundles.Add(new ScriptBundle("~/bundles/jscore").Include(
                        "~/Assets/Client/js/jquery-3.4.1.min.js",
                        "~/Assets/Client/js/jquery-ui.js",
                       "~/Assets/Client/js/bootstrap.min.js",
                       "~/Assets/Client/js/move-top.js",
                       "~/Assets/Client/js/easing.js",
                       "~/Assets/Client/js/startstop-slider.js"));

            bundles.Add(new ScriptBundle("~/bundles/controller").Include(
                        "~/Assets/Client/js/controller/baseController.js"));

            bundles.Add(new StyleBundle("~/bundles/core").Include(
                      "~/Assets/Client/css/bootstrap.css",
                      "~/Assets/Client/css/all.css",
                      "~/Assets/Client/css/fontawesome.css",
                      "~/Assets/Client/css/style.css",
                      "~/Assets/Client/css/slider.css",
                      "~/Assets/Client/css/bootstrap-social.css",
                      "~/Assets/Client/css/jquery-ui.css",
                      "~/Content/site.css"));

            BundleTable.EnableOptimizations = true;

        }
    }
}
