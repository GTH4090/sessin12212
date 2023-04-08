using System;
using System.Collections.Generic;

namespace KhranDesktop.Models;

public partial class Division
{
    public string Name { get; set; } = null!;

    public int Id { get; set; }

    public virtual ICollection<Employee> Employees { get; } = new List<Employee>();
}
