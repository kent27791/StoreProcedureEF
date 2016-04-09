using System;
using System.Collections.Generic;

namespace StoreProcedureEF.Models
{
    public partial class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int ClassId { get; set; }
        public virtual Class Class { get; set; }
    }
}
