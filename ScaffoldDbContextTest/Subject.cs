using System;
using System.Collections.Generic;

namespace ScaffoldDbContextTest;

public partial class Subject
{
    public int Id { get; set; }

    public string Code { get; set; } = null!;

    public string Discription { get; set; } = null!;

    public decimal Units { get; set; }
}
