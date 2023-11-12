using System.Data;
using Dapper;
using MySqlLibrary.Models;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;

namespace MySqlLibrary.DataAccess;

public class ProjectDataAccess
{
    private readonly IConfiguration _configuration;

    public ProjectDataAccess(IConfiguration configuration)
	{
        _configuration = configuration;
    }

    public ProjectModel GetProject(int? id)
    {
        using (IDbConnection connection = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection")))
        {
            var output = connection.Query<ProjectModel>($"SELECT * FROM mydb.Projects where relation_id = {id}").FirstOrDefault();
            return output ?? new ProjectModel();
        }
    }
    public async Task<int> UpdateProjectAsync(ProjectModel project)
    {
        using (IDbConnection connection = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection")))
        {
            var result = await connection.ExecuteAsync($"UPDATE `mydb`.`Projects` SET `project_info` = {project.Project_info}, `project_finance_id` = {project.Project_finance_id} WHERE (`relation_id` = {project.Relation_id});");
            return result;
        }
    }
}