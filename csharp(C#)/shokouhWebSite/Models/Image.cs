using System;
using System.Collections.Generic;

namespace shokouhWebSite.Models;

public partial class Image
{
    public int Id { get; set; }

    public byte[]? Image1 { get; set; }

    public string? ImageName { get; set; }

    /// <summary>
    /// what image type? {logo 0 , regular 1 , products 2}
    /// </summary>
    public byte Tag { get; set; }
}
