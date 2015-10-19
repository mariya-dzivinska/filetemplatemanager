using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL.Data
{
	public sealed class Location
	{
		[Key]
		public int ClientId { get; set; }
		public string RetailerName { get; set; }
		public string Address { get; set; }
		public string LocationName { get; set; }
		public List<Question> Questions { get; set; }
	}
}