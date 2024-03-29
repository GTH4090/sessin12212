﻿using System;
using System.Collections.Generic;

namespace KhranDesktop.Models;

public partial class Visitor
{
    public int Id { get; set; }

    public string LastName { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public byte[]? Photo { get; set; }

    public int VisitId { get; set; }

    public string Email { get; set; } = null!;

    public string? Phone { get; set; }

    public string PassportSerial { get; set; } = null!;

    public string PassportNumber { get; set; } = null!;

    public byte[] PassportScan { get; set; } = null!;

    public string? Comment { get; set; }

    public bool IsBanned { get; set; }

    public string? Organisation { get; set; }
}
