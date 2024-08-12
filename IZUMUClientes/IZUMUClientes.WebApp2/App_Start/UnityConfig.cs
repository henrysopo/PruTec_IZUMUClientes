using IZUMUClientes.WebApp2.ServiceApi;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace IZUMUClientes.WebApp2
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IServiceApi, ServiceApi.ServiceApi>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}