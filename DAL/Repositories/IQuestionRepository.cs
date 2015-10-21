﻿using DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
	public interface IQuestionRepository
	{
		Question GetById(int questionId);

		void SaveAnswer(int questionId);
	}
}
