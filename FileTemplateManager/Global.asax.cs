using Autofac;
using Autofac.Integration.Mvc;
using Bussiness;
using DAL;
using FileTemplateManager.App_Start;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace FileTemplateManager
{
	public class MvcApplication : System.Web.HttpApplication
	{
		protected void Application_Start()
		{
			AreaRegistration.RegisterAllAreas();
			GlobalConfiguration.Configure(WebApiConfig.Register);
			RouteConfig.RegisterRoutes(RouteTable.Routes);

			ContainerBuilder builder = new ContainerBuilder();
			builder.RegisterControllers(typeof(MvcApplication).Assembly);
			builder.RegisterModule<BussinessModule>();
			builder.RegisterModule<DALModule>();
			IContainer container = builder.Build();
			DependencyResolver.SetResolver( new AutofacDependencyResolver(container)); 
		}
	}
}
