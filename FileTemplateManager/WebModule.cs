using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FileTemplateManager.Providers;

namespace FileTemplateManager
{
	public class WebModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			base.Load(builder);

			builder
				.RegisterType<ProjectMultipartFormDataStreamProviderFactory>()
				.As<IProjectMultipartFormDataStreamProviderFactory>()
				.InstancePerLifetimeScope();
		}
	}
}