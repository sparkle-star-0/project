using System;
using System.Collections.Generic;

namespace shokouhWebSite.Models;

public partial class Admin
{
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? FullName { get; set; }

    public int Position { get; set; }

    public virtual PositionTable PositionNavigation { get; set; } = null!;
}
