using System;
using System.Collections.Generic;

namespace WEBAPI.MODELSACCESS;

public partial class StudentsAndGuardiansExtended
{
    public string? StudentName { get; set; }

    public string? GuardianName { get; set; }

    public int? StudentId { get; set; }

    public int? GuardianId { get; set; }

    public string? Relationship { get; set; }

    public string? EMailAddress { get; set; }

    public string? BusinessPhone { get; set; }

    public string? HomePhone { get; set; }

    public string? MobilePhone { get; set; }

    public bool EmergencyContact { get; set; }
}
