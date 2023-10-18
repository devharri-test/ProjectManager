using System.Data;
using Dapper;
using MySqlLibrary.Models;
using MySql.Data.MySqlClient;

namespace MySqlLibrary.DataAccess;

public static class RelationDataAccess
{
    private static readonly string connectionString = "Server=127.0.0.1;Port=3306;Database=mydb;Uid=root;Pwd=admin;";

    public static List<RelationModel> GetChildRelations(int? relationId)
    {
        if (relationId is null)
        {

                using (IDbConnection connection = new MySqlConnection(connectionString))
                {
                    var output = connection.Query<RelationModel>($"SELECT * FROM mydb.Relations where parent_id IS NULL").ToList();
                    return output;
                }
        }
        else
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                var output = connection.Query<RelationModel>($"SELECT * FROM mydb.Relations where parent_id = {relationId}").ToList();
                return output;
            }
        }
    }
    public static RelationModel GetRelation(int? id)
    {
        using (IDbConnection connection = new MySqlConnection(connectionString))
        {
            var output = connection.Query<RelationModel>($"SELECT * FROM mydb.Relations where id = {id}").FirstOrDefault();
            return output ?? new RelationModel();
        }
    }
    public static async Task<int> PostRelationAsync(RelationModel relation)
    {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                var result = await connection.ExecuteAsync($"INSERT INTO `mydb`.`Relations` (`relation_name`, `role_id`, `parent_id`) VALUES ('{relation.Relation_name}', '{relation.Role_id}', '{relation.Parent_id}')");
                return result;
            }
    }
    public static async Task<int> DeleteRelationAsync(int? id)
    {

        using (IDbConnection connection = new MySqlConnection(connectionString))
        {
            var result = await connection.ExecuteAsync($"DELETE FROM `mydb`.`Relations` WHERE (`id` = '{id}');");
            return result;
        }
    }
    public static async Task<int> UpdateRelationAsync(int? id, string? name)
    {

        using (IDbConnection connection = new MySqlConnection(connectionString))
        {
            var result = await connection.ExecuteAsync($"UPDATE `mydb`.`Relations` SET `relation_name` = '{name}' WHERE (`id` = '{id}');");
            return result;
        }
    }
}