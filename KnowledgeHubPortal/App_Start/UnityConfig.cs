using KnowledgeHubPortal.Models.Data;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace KnowledgeHubPortal
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType < ICatagoriesRepository, CatagoriesRepository >();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));

            container.RegisterType<ICatagoriesRepository, CatagoriesRepository>();
            //container.RegisterType<IArticleRepository, ArticleRepository>();
            
            container.RegisterType<IArticleRepository, DummyArticleRepo>();

        }
    }
}