using DAL.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Default
{
	public class FileRepository : IFileRepository
	{
		public int GetIndicator(string fileName)
		{
			string query = @"
						BEGIN TRANSACTION

						IF(NOT EXISTS(
										SELECT FileName 
										FROM FileIndicators WITH(TABLOCKX)
										WHERE FileName = @Name
									)
						)
							INSERT INTO FileIndicators(FileName, Indicator)
							VALUES (@Name, 0)
						ELSE
							UPDATE FileIndicators
							SET Indicator = Indicator + 1
							WHERE FileName = @Name
	
						SELECT 
							FileName
							,Indicator
						FROM FileIndicators 
						WHERE FileName = @Name

						COMMIT TRANSACTION
					";
			using (DataContext context = new DataContext())
			{
				FileIndicator fileIndicator = context
					.FileIndicators
					.SqlQuery(query, new SqlParameter("@Name", fileName))
					.Single();

				return fileIndicator.Indicator;
			}
		}
	}
}
