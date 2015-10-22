using Bussiness;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;

namespace FileTemplateManager.Providers
{

	public class ProjectMultipartFormDataStreamProvider : MultipartFormDataStreamProvider
	{
		private readonly IProjectService projectService;
		private readonly int questionId;

		public ProjectMultipartFormDataStreamProvider(IProjectService projectService, int questionId, string rootPath)
			: base(rootPath)
		{
			this.projectService = projectService;
			this.questionId = questionId;
		}

		public override string GetLocalFileName(HttpContentHeaders headers)
		{
			string fileName = projectService.GetFileName(questionId);
			string extension = Path.GetExtension(headers.ContentDisposition.FileName.Replace("\"", ""));

			fileName = fileName + extension;

			return fileName;
		}

		//private string GetNextFileName(string pattern, string extention)
		//{
		//	string fileName = string.Format(pattern, string.Empty, extention);
		//	int i = 1;
		//	while (File.Exists(Path.Combine(this.RootPath, fileName)))
		//	{
		//		string incrementer = "." + (i++);
		//		fileName = string.Format(pattern, incrementer, extention);
		//	}

		//	return fileName;
		//}
	}
}