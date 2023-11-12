using System.Data;
using Dapper;
using MySqlLibrary.Models;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;

namespace MySqlLibrary.DataAccess;

public class RelationDataAccess
{

    public IConfiguration _configuration;


    public RelationDataAccess(IConfiguration configuration)
    {
        _configuration = configuration;

    }

    public async Task<List<RelationModel>> GetChildRelationsAsync(int? relationId)
    {
        if (relationId is null)
        {
                using (IDbConnection connection = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                var output = await connection.QueryAsync<RelationModel>($"SELECT * FROM mydb.Relations where parent_id IS NULL");
                return output.ToList();
                }
        }
        else
        {
            using (IDbConnection connection = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                var output = await connection.QueryAsync<RelationModel>($"SELECT * FROM mydb.Relations where parent_id = {relationId}");
                return output.ToList();
            }
        }
    }
    public RelationModel GetRelation(int? id)
    {
        using (IDbConnection connection = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection")))
        {
            var output = connection.Query<RelationModel>($"SELECT * FROM mydb.Relations where id = {id}").FirstOrDefault();
            return output ?? new RelationModel();
        }
    }
    public async Task<int> PostRelationAsync(RelationModel relation)
    {
            using (IDbConnection connection = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                var result = await connection.ExecuteAsync($"INSERT INTO `mydb`.`Relations` (`relation_name`, `role_id`, `parent_id`) VALUES ('{relation.Relation_name}', '{relation.Role_id}', '{relation.Parent_id}')");
                return result;
            }
    }
    public async Task<string> DeleteRelationAsync(int? id)
    {
        using (IDbConnection connection = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection")))
        {
            try
            {
                var result = await connection.ExecuteAsync($"DELETE FROM `mydb`.`Relations` WHERE (`id` = '{id}');");
                return "OK";
            }
            catch (Exception ex) when (ex.ToString().Contains("0x80004005"))
            {
                Console.WriteLine("Relation has child relations, cannot perform delete action");
                return ex.ToString();
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
    }
    public async Task<int> UpdateRelationAsync(RelationModel relation)
    {
        using (IDbConnection connection = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection")))
        {
            if (relation.Parent_id is null)
            {
                var result = await connection.ExecuteAsync($"UPDATE `mydb`.`Relations` SET `relation_name` = '{relation.Relation_name}' WHERE (`id` = '{relation.Id}');");
                return result;
            }
            else
            {
                var result = await connection.ExecuteAsync($"UPDATE `mydb`.`Relations` SET `relation_name` = '{relation.Relation_name}', `parent_id` = '{relation.Parent_id}' WHERE (`id` = '{relation.Id}');");
                return result;
            }
        }
    }
}