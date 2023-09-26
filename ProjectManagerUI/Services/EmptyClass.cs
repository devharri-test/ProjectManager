namespace ProjectManagerUI.Services;

public class EmptyClass : IEmptyClass
{
    public string? location { get; set; } = "";
    public int? locationId { get; set; } = 0;

    public string? dept { get; set; } = "";
    public int? deptId { get; set; } = 0;

    public string? proj { get; set; } = "";
    public int? projId { get; set; } = 0;
}

