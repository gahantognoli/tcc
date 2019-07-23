using System.Web;
using System.Web.Optimization;

namespace UNIFAFIBE.TCC._4Sales.MVC
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/style.css",
                      "~/Content/notification.css"));

            bundles.Add(new ScriptBundle("~/Scripts/Global").Include(
                "~/Scripts/Global.js",
                "~/Scripts/script.js",
                "~/Scripts/bootstrap-notify.min.js"
             ));

            bundles.Add(new ScriptBundle("~/Scripts/MeusDados").Include(
               "~/Scripts/StatusPedido/script.js",
               "~/Scripts/TipoPedido/script.js",
               "~/Scripts/Transportadora/script.js"
            ));

            bundles.Add(new ScriptBundle("~/Scripts/Dashboard").Include(
               "~/Scripts/Dashboard/chart.js"
            ));
        }
    }
}
