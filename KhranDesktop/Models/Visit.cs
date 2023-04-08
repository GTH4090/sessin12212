using System;
using System.Collections.Generic;

namespace KhranDesktop.Models;

public partial class Visit
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public DateTime? FinalDate { get; set; }

    public TimeOnly? Time { get; set; }

    public int EmployeeId { get; set; }

    public int TypeId { get; set; }

    public int StatusId { get; set; }

    public string? StatusReason { get; set; }

    public int TargetId { get; set; }

    public string? GroupName { get; set; }

    public virtual Employee Employee { get; set; } = null!;

    public virtual Status Status { get; set; } = null!;

    public virtual Target Target { get; set; } = null!;

    public virtual Type Type { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
