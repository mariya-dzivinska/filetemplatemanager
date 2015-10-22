using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Data
{
	public sealed class FileIndicator
	{
		[Key]
		public string FileName { get; set; }
		public int Indicator { get; set; }
	}
}
