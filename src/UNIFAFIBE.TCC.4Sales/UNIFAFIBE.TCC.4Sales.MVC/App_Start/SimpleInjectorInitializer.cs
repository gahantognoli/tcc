[assembly: WebActivatorEx.PostApplicationStartMethod(typeof(UNIFAFIBE.TCC._4Sales.MVC.App_Start.SimpleInjectorInitializer), "Initialize")]

namespace UNIFAFIBE.TCC._4Sales.MVC.App_Start
{
    using SimpleInjector;
    using SimpleInjector.Integration.Web;
    using SimpleInjector.Integration.Web.Mvc;
    using System.Reflection;
    using System.Web.Mvc;
    using UNIFAFIBE.TCC._4Sales.Transversal;

    public static class SimpleInjectorInitializer
    {
        public static void Initialize()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            InitializeContainer(container);

            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
            //container.RegisterMvcIntegratedFilterProvider();

            container.Verify();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }

        private static void InitializeContainer(Container container)
        {
            //Método criado na camada de CrossCutting,
            //pois de acordo com a regra do DDD,
            //ela conhece todas as outras camadas.
            SimpleInjectorMapping.Register(container);
        }
    }
}