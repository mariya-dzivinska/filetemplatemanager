using Bussiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace FileTemplateManager.Providers
{
	public class ProjectMultipartFormDataStreamProviderFactory : IProjectMultipartFormDataStreamProviderFactory
	{
		IProjectService projectService;

		public ProjectMultipartFormDataStreamProviderFactory(IProjectService projectService)
		{
			this.projectService = projectService;
		}

		public MultipartFormDataStreamProvider Create(int questionId, string root)
		{
			ProjectMultipartFormDataStreamProvider provider = new ProjectMultipartFormDataStreamProvider(projectService, questionId, root);
			return provider;
		}
	}
}