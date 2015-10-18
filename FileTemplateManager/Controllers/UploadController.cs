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
	public class UploadController : ApiController
	{
		public async Task<HttpResponseMessage> PostFile()
		{
			if (!Request.Content.IsMimeMultipartContent())
			{
				throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
			}

			string root = HttpContext.Current.Server.MapPath("~/App_Data");
			var provider = new MultipartFormDataStreamProvider(root);

			try
			{
				await Request.Content.ReadAsMultipartAsync(provider);

				string selectedProject = provider.FormData["selectedProject"];
				string selectedQuestion = provider.FormData["selectedQuestion"];

				MultipartFileData file = provider.FileData.SingleOrDefault();
				if (file == null)
				{
					throw new HttpResponseException(HttpStatusCode.BadRequest);
				}

				FileInfo fileInfo = new FileInfo(file.LocalFileName);

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
