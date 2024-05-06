using System.Web.Mvc;
using Unity;
using Unity.Mvc5;
using TaskManagement.Repository.Interface;
using TaskManagement.Repository.Services;

namespace TaskManagement
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
          container.RegisterType<IUserPanelInterface, UserPanelService>();
            
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}