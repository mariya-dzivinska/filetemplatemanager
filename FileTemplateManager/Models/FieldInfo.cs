using Bussiness;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FileTemplateManager.Models
{
	public class FieldInfo
	{
		public AvaliableFields Field { get; set; }

		public bool IsUsed { get; set; }

	}
}