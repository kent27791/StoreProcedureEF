namespace StoreProcedureEF.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<StoreProcedureEF.Models.DemoStoreProcedureContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(StoreProcedureEF.Models.DemoStoreProcedureContext context)
        {
            //  This method will be called after migrating to the latest version.
            context.Classes.Add(new Class { ClassId = 1, Name = "A" });
            context.Classes.Add(new Class { ClassId = 2, Name = "B" });
            context.Classes.Add(new Class { ClassId = 3, Name = "C" });
            context.Classes.Add(new Class { ClassId = 4, Name = "D" });

            context.Students.Add(new Student { StudentId = 1, Name = "Student A", Age = 10, ClassId = 1 });
            context.Students.Add(new Student { StudentId = 2, Name = "Student B", Age = 8, ClassId = 1 });
            context.Students.Add(new Student { StudentId = 3, Name = "Student C", Age = 7, ClassId = 2 });
            context.Students.Add(new Student { StudentId = 4, Name = "Student D", Age = 9, ClassId = 1 });
        }
    }
}
