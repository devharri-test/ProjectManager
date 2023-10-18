namespace ProjectManagerUI.Services;

public class EmptyClass : IEmptyClass
{
    private string? _Location;
    public string? Location { get => _Location; }
    private int? _LocationId;
    public int? LocationId { get => _LocationId; }

    private string? _Department;
    public string? Department { get => _Department; }
    private int? _DepartmentId;
    public int? DepartmentId { get => _DepartmentId; }

    private string? _Project;
    public string? Project { get => _Project; }
    private int? _ProjectId;
    public int? ProjectId { get => _ProjectId; }

    private string? _Controller;
    public string? Controller { get => _Controller; }
    private int? _ControllerId;
    public int? ControllerId { get => _ControllerId; }

    private string? _ControlGroup;
    public string? ControlGroup { get => _ControlGroup; }
    private int? _ControlGroupId;
    public int? ControlGroupId { get => _ControlGroupId; }

    private string? _FunctionGroup;
    public string? FunctionGroup { get => _FunctionGroup; }
    private int? _FunctionGroupId;
    public int? FunctionGroupId { get => _FunctionGroupId; }

    private string? _Machine;
    public string? Machine { get => _Machine; }
    private int? _MachineId;
    public int? MachineId { get => _MachineId; }

    private string? _Part;
    public string? Part { get => _Part; }
    private int? _PartId;
    public int? PartId { get => _PartId; }

    public EmptyClass()
    {

    }

    public void SetLocation(string? location, int? id)
    {
        _Location = location;
        _LocationId = id;
        _Department = null;
        _DepartmentId = null;
        _Project = null;
        _ProjectId = null;
        _Controller = null;
        _ControllerId = null;
        _ControlGroup = null;
        _ControlGroupId = null;
        _FunctionGroup = null;
        _FunctionGroupId = null;
        _Machine = null;
        _MachineId = null;
        _Part = null;
        _PartId = null;
    }

    public void SetDepartment(string? department, int? id)
    {
        _Department = department;
        _DepartmentId = id;
        _Project = null;
        _ProjectId = null;
        _Controller = null;
        _ControllerId = null;
        _ControlGroup = null;
        _ControlGroupId = null;
        _FunctionGroup = null;
        _FunctionGroupId = null;
        _Machine = null;
        _MachineId = null;
        _Part = null;
        _PartId = null;
    }
    public void SetProject(string? project, int? id)
    {
        _Project = project;
        _ProjectId = id;
        _Controller = null;
        _ControllerId = null;
        _ControlGroup = null;
        _ControlGroupId = null;
        _FunctionGroup = null;
        _FunctionGroupId = null;
        _Machine = null;
        _MachineId = null;
        _Part = null;
        _PartId = null;
    }
    public void SetController(string? controller, int? id)
    {
        _Controller = controller;
        _ControllerId = id;
        _ControlGroup = null;
        _ControlGroupId = null;
        _FunctionGroup = null;
        _FunctionGroupId = null;
        _Machine = null;
        _MachineId = null;
        _Part = null;
        _PartId = null;
    }
    public void SetControlGroup(string? controlGroup, int? id)
    {
        _ControlGroup = controlGroup;
        _ControlGroupId = id;
        _FunctionGroup = null;
        _FunctionGroupId = null;
        _Machine = null;
        _MachineId = null;
        _Part = null;
        _PartId = null;
    }
    public void SetFunctionGroup(string? functionGroup, int? id)
    {
        _FunctionGroup = functionGroup;
        _FunctionGroupId = id;
        _Machine = null;
        _MachineId = null;
        _Part = null;
        _PartId = null;
    }
    public void SetMachine(string? machine, int? id)
    {
        _Machine = machine;
        _MachineId = id;
        _Part = null;
        _PartId = null;
    }
    public void SetPart(string? part, int? id)
    {
        _Part = part;
        _PartId = id;
    }
}
