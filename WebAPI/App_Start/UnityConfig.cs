using Business;
using Business.Interface;
using Business.RepositoryHelper;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace WebAPI
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IPassengerManager, PassengerManager>();
            container.AddNewExtension<RepositoryHelper>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}