using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using vasilevamariakt_42_23_pp.models;

namespace vasilevamariakt_42_23_pp.Database;

public class SpecialtyConfiguration : IEntityTypeConfiguration<Specialty>
{
    public void Configure(EntityTypeBuilder<Specialty> builder)
    {
        builder.ToTable("Specialties");
        builder.HasKey(s => s.SpecialtyId);
        builder.Property(s => s.Title).IsRequired().HasMaxLength(200);
        builder.Property(s => s.Code).IsRequired().HasMaxLength(20);
    }
}

public class GroupConfiguration : IEntityTypeConfiguration<Group>
{
    public void Configure(EntityTypeBuilder<Group> builder)
    {
        builder.ToTable("Groups");
        builder.HasKey(g => g.GroupId);
        builder.Property(g => g.Name).IsRequired().HasMaxLength(50);

        // У группы одна специальность, у специальности много групп
        builder.HasOne(g => g.Specialty)
            .WithMany(s => s.Groups)
            .HasForeignKey(g => g.SpecialtyId)
            .HasConstraintName("fk_groups_specialty")
            .OnDelete(DeleteBehavior.Restrict);
    }
}

public class StudentConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.ToTable("Students");
        builder.HasKey(s => s.StudentId);
        builder.Property(s => s.FirstName).IsRequired().HasMaxLength(100);
        builder.Property(s => s.LastName).IsRequired().HasMaxLength(100);

        // У студента одна группа, у группы много студентов
        builder.HasOne(s => s.Group)
            .WithMany(g => g.Students)
            .HasForeignKey(s => s.GroupId)
            .HasConstraintName("fk_students_group")
            .OnDelete(DeleteBehavior.Cascade);
    }
}

public class DisciplineConfiguration : IEntityTypeConfiguration<Discipline>
{
    public void Configure(EntityTypeBuilder<Discipline> builder)
    {
        builder.ToTable("Disciplines");
        builder.HasKey(d => d.DisciplineId);
        builder.Property(d => d.Name).IsRequired().HasMaxLength(200);
    }
}

public class GradeConfiguration : IEntityTypeConfiguration<Grade>
{
    public void Configure(EntityTypeBuilder<Grade> builder)
    {
        builder.ToTable("Grades");
        builder.HasKey(g => g.GradeId);

        builder.HasOne(g => g.Student)
            .WithMany(s => s.Grades)
            .HasForeignKey(g => g.StudentId)
            .HasConstraintName("fk_grades_student")
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(g => g.Discipline)
            .WithMany(d => d.Grades)
            .HasForeignKey(g => g.DisciplineId)
            .HasConstraintName("fk_grades_discipline")
            .OnDelete(DeleteBehavior.Restrict);
    }
}