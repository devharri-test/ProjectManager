using System.Data;
using Dapper;
using MySqlLibrary.Models;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;

namespace MySqlLibrary.DataAccess;

public class LocationDataAccess
{
    private readonly IConfiguration _configuration;

    public LocationDataAccess(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public LocationModel GetLocation(int? id)
    {
        using (IDbConnection connection = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection")))
        {
            var output = connection.Query<LocationModel>($"SELECT * FROM mydb.Locations where relation_id = {id}").FirstOrDefault();
            return output ?? new LocationModel();
        }
    }
    public async Task<int> UpdateLocationAsync(LocationModel location)
    {
        using (IDbConnection connection = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection")))
        {
                var result = await connection.ExecuteAsync($"UPDATE `mydb`.`Locations` SET `location_info` = {location.Location_info}, `address` = {location.Address} WHERE (`relation_id` = {location.Relation_id});");
                return result;
        }
    }
}