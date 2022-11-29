
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineCourseRegistration.Domain.StudentAggregateRoot.Entities;
//using NewOnlineCourseReg.Infrastructure.Data.Repositories.Models;

namespace OnlineCourseRegistration.Persistence.EntitiesConfig
{
    internal class CourseModelConfig : IEntityTypeConfiguration<Course>
    {

        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasKey(p => new { p.StudentId, p.semester, p.session, p.CourseId });
              builder.HasOne(p => p.CourseRegistrationForm).WithMany(p => p.coursesForm).HasForeignKey(p =>new  { p.StudentId,  p.session,p.semester });
              builder.Property(p => p.FacId)
                .IsRequired()
                .HasMaxLength(50);

  
            builder.HasData(
                new Course() { CampId = "d", FacId = "s",StudentId = "1", session = "1" ,semester = "1", CourseId = "111" },
                new Course() { CampId = "d", FacId = "s", StudentId = "1", session = "1", semester = "1", CourseId = "113" },
                new Course() { CampId = "d", FacId = "s", StudentId = "1", session = "1", semester = "1", CourseId = "114" }


                );
        }
    }
}