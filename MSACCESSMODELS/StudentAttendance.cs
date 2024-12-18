using System;
using System.Collections.Generic;

namespace WEBAPI.MODELSACCESS;

public partial class StudentAttendance
{
    public int? Id { get; set; }

    public int? Student { get; set; }

    public DateTime? AttendanceDate { get; set; }

    public string? Status { get; set; }
}
