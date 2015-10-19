using DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FileTemplateManager.Models
{
	public class TemplateModel
	{
		public TemplateModel() :
			this(
				1,
				selectedFields: new[]
				{
					AvaliableFields.ProjectId,
					AvaliableFields.QuestionId
				},
				separator: Separators.Dash
			)
		{
		}

		public TemplateModel(int projectId, AvaliableFields[] selectedFields, Separators separator)
		{
			SelectedFields = selectedFields.ToList();

			Separator = separator;

			Projects = new List<Project>()
			{
				new Project()
				{
					ProjectId = 1,
					ProjectName = "Test project 1"
				},
				new Project()
				{
					ProjectId = 2,
					ProjectName = "Test project 2"
				}
			};

			SelectedProjectId = Projects.First(x => x.ProjectId == projectId).ProjectId;
		}


		public List<AvaliableFields> SelectedFields { get; set; }

		public List<FieldInfo> Fields
		{
			get
			{
				return Enum.GetValues(typeof(AvaliableFields))
					.Cast<AvaliableFields>()
					.Select(x => new FieldInfo
					{
						Field = x,
						IsUsed = SelectedFields.Contains(x)
					})
					.ToList();
			}
		}

		public Separators Separator { get; set; }

		public string SampleFileName
		{
			get
			{
				string[] selectedFields = SelectedFields
					.Select(f => f.ToString())
					.ToArray();

				string separatorString = (Separator == Separators.Dot)
					? "."
					: "-";
				var result = string.Join(separatorString, selectedFields);

				return result;
			}
		}

		public int SelectedProjectId { get; set; }

		public IEnumerable<Project> Projects { get; set; }
	}

}