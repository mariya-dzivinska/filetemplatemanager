using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FileTemplateManager.Providers
{
	public interface IProjectMultipartFormDataStreamProviderFactory
	{
		MultipartFormDataStreamProvider Create(int questionId, string root);
	}
}
