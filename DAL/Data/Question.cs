using System.Collections.Generic;

namespace DAL.Data
{
	public sealed class Question
	{
		public int QuestionId { get; set; }
		public string Text { get; set; }
		public Project Project { get; set; }
		public Location Location { get; set; }

		public List<Answer> Answers { get; set; }

	}
}