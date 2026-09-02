using System;
using System.Collections.Generic;

namespace shokouhWebSite.Models;

public partial class PositionTable
{
    /// <summary>
    /// xxx =&gt;( user type{ head admin 1, admin 2 , other 3 } / acsses level {high 1 , meduim 2 , low 3} / position{accounting 1 , Commercial Department 2 , voice of customer 3 }  )
    /// </summary>
    public int Code { get; set; }

    public string PositionName { get; set; } = null!;

    public int Id { get; set; }

    public virtual ICollection<Admin> Admins { get; set; } = new List<Admin>();
}
