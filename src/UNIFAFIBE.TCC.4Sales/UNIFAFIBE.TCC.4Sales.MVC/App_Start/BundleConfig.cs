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

            bundles.Add(
                new ScriptBundle("~/bundles/validations_pt-br")
                    .Include(
                        "~/Scripts/jquery.validate.custom.pt-br*"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.bundle.min.js"));

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
                "~/Scripts/Usuario/script.js",
               "~/Scripts/StatusPedido/script.js",
               "~/Scripts/TipoPedido/script.js",
               "~/Scripts/Transportadora/script.js",
               "~/Scripts/Meta/script.js"
            ));

            bundles.Add(new ScriptBundle("~/Scripts/Dashboard").Include(
               "~/Scripts/Dashboard/chart.js",
               "~/Scripts/Dashboard/script.js"
            ));

            bundles.Add(new ScriptBundle("~/Scripts/Clientes").Include(
               "~/Scripts/Cliente/script.js",
               "~/Scripts/Segmento/script.js",
               "~/Scripts/jquery.mask.min.js"
            ));

            bundles.Add(new ScriptBundle("~/Scripts/Clientes/Alterar").Include(
                "~/Scripts/Cliente/script-alterar.js",
                "~/Scripts/jquery.mask.min.js"
            ));

            bundles.Add(new ScriptBundle("~/Scripts/Representadas").Include(
                "~/Scripts/Representada/script.js",
                "~/Scripts/jquery.mask.min.js"
            ));

            bundles.Add(new ScriptBundle("~/Scripts/Representadas/Painel").Include(
                "~/Scripts/Representada/Painel.js"
            ));

            bundles.Add(new ScriptBundle("~/Scripts/Produto").Include(
                "~/Scripts/Produto/script.js"
            ));

            bundles.Add(new ScriptBundle("~/Scripts/Usuario").Include(
                "~/Scripts/Usuario/script.js"
            ));

            bundles.Add(new ScriptBundle("~/Scripts/Pedido").Include(
                "~/Scripts/Pedido/script.js",
                "~/Scripts/jquery.mask.min.js",
                "~/Scripts/jquery.autocomplete.min.js"
            ));

            bundles.Add(new ScriptBundle("~/Scripts/Acoes").Include(
                "~/Scripts/Pedido/acoes.js",
                "~/Scripts/jquery.autocomplete.min.js"
            ));

            bundles.Add(new ScriptBundle("~/Scripts/Faturar").Include(
                "~/Scripts/Pedido/faturar.js"
            ));
        }
    }
}
