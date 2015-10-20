using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Data;
using System.Data.Entity;

namespace DAL.Repositories.Default
{
	public class QuestionRepository : IQuestionRepository
	{
		public Question GetById(int questionId)
		{
			using (DataContext context = new DataContext())
			{
				var question = context.Questions
					.Include(x => x.Project)
					.Include(x => x.Location)
					.Single(x => x.QuestionId == questionId);

				return question;
			}
		}
	}
}
