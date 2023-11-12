using System.Data;
using Dapper;
using MySqlLibrary.Models;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;

namespace MySqlLibrary.DataAccess;

public class DepartmentDataAccess
{
    private readonly IConfiguration _configuration;

    public DepartmentDataAccess(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public DepartmentModel GetDepartment(int? id)
    {
        using (IDbConnection connection = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection")))
        {
            var output = connection.Query<DepartmentModel>($"SELECT * FROM mydb.Departments where relation_id = {id}").FirstOrDefault();
            return output ?? new DepartmentModel();
        }
    }
    public async Task<int> UpdateDepartmentAsync(DepartmentModel department)
    {
        using (IDbConnection connection = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection")))
        {
            var result = await connection.ExecuteAsync($"UPDATE `mydb`.`Departments` SET `department_info` = {department.Department_info} WHERE (`relation_id` = {department.Relation_id});");
            return result;
        }
    }
}