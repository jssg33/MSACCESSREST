using System;
using System.Collections.Generic;

namespace WEBAPI.MODELSACCESS;

public partial class StudentsAndGuardian
{
    public int? StudentId { get; set; }

    public int? GuardianId { get; set; }

    public string? Relationship { get; set; }

    public bool EmergencyContact { get; set; }
}
