namespace ProjectManagerUI.Services
{
    public interface IEmptyClass
    {
        string? location { get; set; }
        int? locationId { get; set; }

        string? dept { get; set; }
        int? deptId { get; set; }

        string? proj { get; set; }
        int? projId { get; set; }
    }
}