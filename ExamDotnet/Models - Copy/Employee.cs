using System;
using System.Collections.Generic;

namespace ExamDotnet.Models;

public partial class Employee
{
    public int EmployeeId { get; set; }

    public string EmployeeName { get; set; } = null!;

    public string EmployeeCode { get; set; } = null!;

    public int? DepartmentId { get; set; }

    public string? Rank { get; set; }

    public virtual Department? Department { get; set; }
}
