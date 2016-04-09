using System;
using System.Collections.Generic;

namespace StoreProcedureEF.Models
{
    public partial class Class
    {
        public Class()
        {
            this.Students = new List<Student>();
        }

        public int ClassId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
