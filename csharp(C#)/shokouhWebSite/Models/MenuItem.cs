using System;
using System.Collections.Generic;

namespace shokouhWebSite.Models;

public partial class MenuItem
{
    public byte Id { get; set; }

    public string TitleItem { get; set; } = null!;

    public string LinkItem { get; set; } = null!;

    /// <summary>
    /// what is item of menu type?{regular 0 , admin 1}
    /// </summary>
    public byte Tag { get; set; }
}
