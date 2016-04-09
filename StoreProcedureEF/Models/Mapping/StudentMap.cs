using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace StoreProcedureEF.Models.Mapping
{
    public class StudentMap : EntityTypeConfiguration<Student>
    {
        public StudentMap()
        {
            // Primary Key
            this.HasKey(t => t.StudentId);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(500);

            // Table & Column Mappings
            this.ToTable("Student");
            this.Property(t => t.StudentId).HasColumnName("StudentId");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Age).HasColumnName("Age");
            this.Property(t => t.ClassId).HasColumnName("ClassId");

            // Relationships
            this.HasRequired(t => t.Class)
                .WithMany(t => t.Students)
                .HasForeignKey(d => d.ClassId);

        }
    }
}
