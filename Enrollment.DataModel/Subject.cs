﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enrollment.DataModel
{
    public class Subject
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Discription { get; set; }
        public Decimal Units { get; set; }

    }
}
