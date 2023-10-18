namespace ProjectManagerUI.Services
{
    public interface IEmptyClass
    {
        string? Location { get; }
        int? LocationId { get; }
        string? Department { get; }
        int? DepartmentId { get; }
        string? Project { get; }
        int? ProjectId { get; }
        string? Controller { get; }
        int? ControllerId { get; }
        string? ControlGroup { get; }
        int? ControlGroupId { get; }
        string? FunctionGroup { get; }
        int? FunctionGroupId { get; }
        string? Machine { get; }
        int? MachineId { get; }
        string? Part { get; }
        int? PartId { get; }

        void SetControlGroup(string? controlGroup, int? id);
        void SetController(string? controller, int? id);
        void SetDepartment(string? department, int? id);
        void SetFunctionGroup(string? functionGroup, int? id);
        void SetLocation(string? location, int? id);
        void SetMachine(string? machine, int? id);
        void SetPart(string? part, int? id);
        void SetProject(string? project, int? id);
    }
}