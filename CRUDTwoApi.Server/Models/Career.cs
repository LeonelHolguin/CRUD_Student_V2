using System;
using System.Collections.Generic;

namespace CRUDTwoApi.Server.Models;

public partial class Career
{
    public int CareerId { get; set; }

    public string? CareerName { get; set; }

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
