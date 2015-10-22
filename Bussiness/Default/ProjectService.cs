using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Data;
using DAL.Repositories;

namespace Bussiness.Default
{
	internal sealed class ProjectService : IProjectService
	{
		private readonly IProjectRepository projectRepository;
		private readonly IQuestionRepository questionRepository;
		private readonly IFileRepository fileRepository;

		public ProjectService(IProjectRepository projectRepository, IQuestionRepository questionRepository, IFileRepository fileRepository)
		{
			this.projectRepository = projectRepository;
			this.questionRepository = questionRepository;
			this.fileRepository = fileRepository;
		}

		public IEnumerable<Project> GetProjects()
		{
			return projectRepository.GetAll();
		}

		public Project GetProjectById(int id)
		{
			var project = projectRepository.GetById(id);
			return project;
		}

		public Project UpdateProjectTemplate(int projectId, string template)
		{
			var project = projectRepository.GetById(projectId);
			project.Template = template;
			var updatedProject = projectRepository.Update(project);
			return updatedProject;
		}

		public string GetFileName(int questionId)
		{
			string fileName = GetFilledTempelete(questionId);

			int index = GetFileIndex(fileName);

			if (index > 0)
			{
				fileName = fileName + "." + index;
			}

			return fileName;
		}


		public AvaliableFields[] GetTempleteItems(string template, out Separators separator)
		{
			List<AvaliableFields> result = new List<AvaliableFields>();
			string[] data = template.Split(';');

			separator = (Separators)Enum.Parse(typeof(Separators), data[0]);

			for (int i = 1; i < data.Length; i++)
			{
				AvaliableFields field = (AvaliableFields)Enum.Parse(typeof(AvaliableFields), data[i]);
				result.Add(field);
			}

			return result.ToArray();
		}

		public void SaveAnswerByQuestion(int questionId)
		{
			questionRepository.SaveAnswer(questionId);
		}

		private string GetFilledTempelete(int questionId)
		{

			Question question = questionRepository.GetById(questionId);

			Separators separator;
			AvaliableFields[] fields = GetTempleteItems(question.Project.Template, out separator);

			List<string> result = new List<string>();

			foreach (var item in fields)
			{
				switch (item)
				{
					case AvaliableFields.ProjectId:
						result.Add(question.Project.ProjectId.ToString());
						break;
					case AvaliableFields.ClientId:
						result.Add(question.Location.ClientId.ToString());
						break;
					case AvaliableFields.QuestionId:
						result.Add(question.QuestionId.ToString());
						break;
					case AvaliableFields.LocationName:
						result.Add(question.Location.LocationName);
						break;
					case AvaliableFields.RetailerName:
						result.Add(question.Location.RetailerName);
						break;
					case AvaliableFields.Address:
						result.Add(question.Location.Address);
						break;
				}
			}

			string template = string.Join(separator == Separators.Dash ? "-" : ".", result);

			return template;
		}


		public int GetFileIndex(string fileName)
		{
			int index = fileRepository.GetIndicator(fileName);

			return index;
		}
	}
}
