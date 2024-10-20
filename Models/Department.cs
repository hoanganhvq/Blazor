﻿using System;
using System.Collections.Generic;

namespace Blazor.Models;

public partial class Department
{
    public int DepartmentId { get; set; }

    public string? DepartmnetName { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
