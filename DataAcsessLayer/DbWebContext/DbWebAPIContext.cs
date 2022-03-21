using Demo_API_StudentClass.Data.Models;
using Demo_API_StudentClass.Models;

using Microsoft.EntityFrameworkCore;

namespace Demo_API_StudentClass.DBContext;

public class DbWebAPIContext : DbContext
{
    public DbWebAPIContext(DbContextOptions<DbWebAPIContext> options) : base(options)
    {

    }
    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
    //    if (!optionsBuilder.IsConfigured)
    //    {
    //        optionsBuilder.UseSqlServer(
    //            "Data Source=DESKTOP-NVB7S6L;Initial Catalog=DemoDPOTECH;Persist Security Info=True;User ID=kieu96;Password=123");
    //    }
    //}

    public DbSet<Class> Classes { get; set; }
    public DbSet<StudentClass> StudentClasses { get; set; }
    public DbSet<Student> Students { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        

        modelBuilder.Entity<Class>(entity =>
        {
            entity.ToTable("Class");
            entity.HasKey(p => p.IdClass);
            entity.Property(p => p.IdClass).ValueGeneratedOnAdd();
        });
        modelBuilder.Entity<Student>(entity =>
        {
            entity.ToTable("Student");
            entity.HasKey(p => p.IdStudent);
            entity.Property(p=>p.IdStudent).ValueGeneratedNever();
        });
        modelBuilder.Entity<StudentClass>(entity =>
        {
            entity.ToTable("StudentClass");
            entity.HasKey(p => new { p.IdStudent, p.IdClass });
            entity.HasOne<Student>(p => p.Student)
                .WithMany(p => p.StudentClasses)
                .HasForeignKey(p => p.IdStudent);
            entity.HasOne<Class>(p => p.Class)
                .WithMany(p => p.StudentsClasses)
                .HasForeignKey(c => c.IdClass)
                .OnDelete(deleteBehavior: DeleteBehavior.ClientSetNull);
        });

    }
}