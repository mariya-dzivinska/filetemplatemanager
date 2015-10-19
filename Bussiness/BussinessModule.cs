using Autofac;
using Bussiness.Default;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness
{
	public class BussinessModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			base.Load(builder);

			builder.RegisterType<ProjectService>()
				.As<IProjectService>()
				.InstancePerLifetimeScope();
		}
	}
}
