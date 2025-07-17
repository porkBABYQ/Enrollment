using System;
using System.Collections.Generic;

namespace ScaffoldDbContextTest;

public partial class Teacher
{
    public int Id { get; set; }

    public string LastName { get; set; } = null!;

    public string FirstName { get; set; } = null!;
}
