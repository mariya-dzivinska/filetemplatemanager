using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FileTemplateManager.Controllers;
using Moq;
using Bussiness;
using System.Threading.Tasks;
using System.Web.Http.Results;
using System.Net.Http;
using System.Net;
using Autofac;
using System.Web;
using System.IO;
using System.Collections.Generic;
using FileTemplateManager.Providers;
using System.Collections.ObjectModel;
using System.Net.Http.Headers;

namespace FileTemplateManager.Tests
{
	[TestClass]
	public class UploadControllerTests
	{
		private UploadController controller;
		private int questionId = 3;

		[TestInitialize]
		public void TestInitialize()
		{
			Mock<IProjectService> projectServiceMock = new Mock<IProjectService>();
			var tempPath = GetTemporaryDirectory();
			Mock<HttpContextBase> httpContextMock = new Mock<HttpContextBase>();
			httpContextMock
				.Setup(x => x.Server.MapPath(It.IsAny<string>()))
				.Returns(tempPath);

			MultipartFormDataStreamProvider provider = new MultipartFormDataStreamProviderMock(tempPath);
			Mock<IProjectMultipartFormDataStreamProviderFactory> factoryMock = new Mock<IProjectMultipartFormDataStreamProviderFactory>();
			factoryMock
				.Setup(x => x.Create(questionId, It.IsAny<string>()))
				.Returns(provider);
			controller = new UploadController(projectServiceMock.Object, httpContextMock.Object, factoryMock.Object);
			controller.Request = new HttpRequestMessage()
			{
				Content = new MultipartContent()
			};
		}

		[TestMethod]
		public void TestStatusCodeOK()
		{
			Task<HttpResponseMessage> resultTask = controller.PostFile(questionId);
			HttpResponseMessage result = resultTask.Result;

			HttpStatusCode expectedResult = HttpStatusCode.OK;
			Assert.IsNotNull(result);
			Assert.AreEqual(expectedResult, resultTask.Result.StatusCode);
		}

		public string GetTemporaryDirectory()
		{
			string tempDirectory = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
			Directory.CreateDirectory(tempDirectory);
			return tempDirectory;
		}

		private class MultipartFormDataStreamProviderMock : MultipartFormDataStreamProvider
		{
			public MultipartFormDataStreamProviderMock(string rootPath)
				: base(rootPath)
			{
			}

			public override Task ExecutePostProcessingAsync()
			{
				int i;
				Task task = new Task(() => i = 1);
				task.Start();
				MultipartFormDataContent content = new MultipartFormDataContent();
				this.FileData.Add(new MultipartFileData(content.Headers, "Filename"));
				return task;
			}

			public override Stream GetStream(HttpContent parent, HttpContentHeaders headers)
			{
				Stream stream = null;
				ContentDispositionHeaderValue contentDisposition = headers.ContentDisposition;
				if (contentDisposition != null)
				{
					if (!String.IsNullOrEmpty(contentDisposition.FileName))
					{
						FileData.Add(new MultipartFileData(headers, contentDisposition.FileName));
						stream = new MemoryStream();
					}
					else
					{
						stream = base.GetStream(parent, headers);
					}
				}

				return stream;
			}
		}
	}
}
