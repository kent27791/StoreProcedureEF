using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using StoreProcedureEF.Models.Mapping;

namespace StoreProcedureEF.Models
{
    public partial class DemoStoreProcedureContext : DbContext
    {
        static DemoStoreProcedureContext()
        {
            Database.SetInitializer<DemoStoreProcedureContext>(null);
        }

        public DemoStoreProcedureContext()
            : base("Name=DemoStoreProcedureContext")
        {
        }

        public DbSet<Class> Classes { get; set; }
        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ClassMap());
            modelBuilder.Configurations.Add(new StudentMap());
        }
    }
}
