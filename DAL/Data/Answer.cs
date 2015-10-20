using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Data
{
	public sealed class Answer
	{
		public int AnswerId { get; set; }
		public Question Question { get; set; }
		public string FileName { get; set; }
		public int Image { get; set; }
	}
}
