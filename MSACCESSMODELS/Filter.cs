using System;
using System.Collections.Generic;

namespace WEBAPI.MODELSACCESS;

public partial class Filter
{
    public int? Id { get; set; }

    public string ObjectType { get; set; } = null!;

    public string ObjectName { get; set; } = null!;

    public string FilterName { get; set; } = null!;

    public string? FilterString { get; set; }

    public string? SortString { get; set; }

    public bool? Default { get; set; }

    public string? Description { get; set; }
}
