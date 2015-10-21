using Bussiness;
using FileTemplateManager.Providers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace FileTemplateManager.Controllers
{
	public sealed class UploadController : ApiController
	{
		private readonly HttpContextBase httpContextBase;
		private readonly IProjectService projectService;
		private readonly IProjectMultipartFormDataStreamProviderFactory factory;

		public UploadController(
			IProjectService projectService,
			HttpContextBase httpContextBase,
			IProjectMultipartFormDataStreamProviderFactory factory
		)
		{
			this.projectService = projectService;
			this.httpContextBase = httpContextBase;
			this.factory = factory;
		}

		public async Task<HttpResponseMessage> PostFile(int id)
		{
			if (!Request.Content.IsMimeMultipartContent())
			{
				throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
			}

			int questionId = id;
			string root = httpContextBase.Server.MapPath("~/App_Data");
			MultipartFormDataStreamProvider provider = factory.Create(questionId, root);

			try
			{
				await Request.Content.ReadAsMultipartAsync(provider);

				MultipartFileData file = provider.FileData.SingleOrDefault();
				if (file == null)
				{
					throw new HttpResponseException(HttpStatusCode.BadRequest);
				}

				FileInfo fileInfo = new FileInfo(file.LocalFileName);

				projectService.SaveAnswerByQuestion(questionId);

				return new HttpResponseMessage()
				{
					Content = new StringContent("ok")
				};
			}
			catch (Exception ex)
			{
				return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
			}
		}
	}
}
