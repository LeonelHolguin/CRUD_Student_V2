using System;
using System.Collections.Generic;

namespace CRUDTwoApi.Server.Models;

public partial class Student
{
    public int StudentId { get; set; }

    public string? StudentFirstName { get; set; }

    public string? StudentLastName { get; set; }

    public int? StudentCareerId { get; set; }

    public DateTime? StudentAdmissionDate { get; set; }

    public DateTime? RegisterDate { get; set; }

    public virtual Career? StudentCareer { get; set; }
}
