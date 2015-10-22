using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FileTemplateManager.Tests
{
	[TestClass]
	public class ApiTests
	{
		[TestMethod]
		public void PostFile()
		{
			int questionId = 1;
			int expectedFileCount = 50;
			string path = Path.GetFullPath(Path.Combine("..\\..\\..\\", "FileTemplateManager", "App_Data"));

			foreach (string file in Directory.GetFiles(path))
			{
				File.Delete(file);
			}

			IEnumerable<int> counts = Enumerable.Range(0, expectedFileCount);
			Parallel.ForEach(
				counts,
				new ParallelOptions()
				{
					MaxDegreeOfParallelism = 30
				},
				i =>
				{
					RestClient client = new RestClient("http://localhost/FileTemplateManager/");
					IRestRequest request = new RestRequest("api/Upload/{id}", Method.POST);
					request.AddUrlSegment("id", questionId.ToString());

					request.AddFile(
						"test.jpeg",
						(Stream x) =>
						{
							StreamWriter sw = new StreamWriter(x);
							sw.WriteLine("This is an image.");
						},
						"test.jpeg"
					);

					IRestResponse response = client.Execute(request);

					string content = response.Content;

					Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
					Assert.AreEqual("ok", content);
				});

			int count = Directory.GetFiles(path).Count();
			Assert.AreEqual(expectedFileCount, count);
		}
	}
}
