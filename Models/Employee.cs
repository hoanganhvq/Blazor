using System;
using System.Collections.Generic;

namespace Blazor.Models;

public partial class Employee
{
    public int EmployeeId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Email { get; set; }

    //public byte[] Photo { get; set; }

    public DateTime? StartingDate { get; set; }

    public int? GenderId { get; set; }

    public int? DepartmentId { get; set; }

    public virtual Department? Department { get; set; }

    public virtual Gender? Gender { get; set; }
}
