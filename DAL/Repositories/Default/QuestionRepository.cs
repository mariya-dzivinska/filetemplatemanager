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

		public void SaveAnswer(int questionId)
		{
			using (DataContext context = new DataContext())
			{
				var questionToUpdate = context.Questions.FirstOrDefault(q => q.QuestionId == questionId);
				var answer = new Answer()
				{
					Question = questionToUpdate
				};
				context.Answers.Add(answer);
				context.SaveChanges();
			}
		}
	}
}
