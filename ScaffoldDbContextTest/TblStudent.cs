using System;
using System.Collections.Generic;

namespace ScaffoldDbContextTest;

public partial class TblStudent
{
    public int Id { get; set; }

    public string Surname { get; set; } = null!;

    public string GivenName { get; set; } = null!;
}
