using System;
using System.Collections.Generic;

namespace shokouhWebSite.Models;

public partial class CommunicationTable
{
    public int Id { get; set; }

    public string TextMessage { get; set; } = null!;

    /// <summary>
    /// who receiver message ? {accounting 0 ,voiceOfCustomer 1 , commercialUnit 2 }
    /// </summary>
    public int Receiver { get; set; }

    public string SenderEmail { get; set; } = null!;

    public string Topic { get; set; } = null!;
}
