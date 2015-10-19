using Autofac;
using DAL.Repositories;
using DAL.Repositories.Default;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
	public sealed class DALModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			base.Load(builder);

			builder
				.RegisterType<ProjectRepository>()
				.As<IProjectRepository>()
				.InstancePerLifetimeScope();
		}
	}
}
