﻿using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
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
			builder.RegisterApiControllers(typeof(MvcApplication).Assembly);
			builder.RegisterModule<AutofacWebTypesModule>();
			builder.RegisterModule<WebModule>();
			builder.RegisterModule<BussinessModule>();
			builder.RegisterModule<DALModule>();

			IContainer container = builder.Build();

			DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
			GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
		}
	}
}
