namespace MySqlLibrary.Models;

public class RelationModel
{
    public int Id { get; set; }
    public string? Relation_name { get; set; }
    public int Role_id { get; set; }
    public int? Parent_id { get; set; }
}

