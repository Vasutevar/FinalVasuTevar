using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalVasuTevar;
using Microsoft.EntityFrameworkCore;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;


public class StudentContext : DbContext
{
    public DbSet<Student> Students { get; set; }

    //define connection string
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=(LocalDB)\MSSQLLocalDB;
                                       Database=FinalVasuTevar;
                                       Trusted_Connection=True;
                                       MultipleActiveResultSets=True;");

    }


    // data seed
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>().HasData(
                 new Student { StudentId = 1, Name = "John", Age = 20, GPA = 3.6, IsHonors = true },
                 new Student { StudentId = 2, Name = "Anne", Age = 22, GPA = 3.9, IsHonors = true },
                 new Student { StudentId = 3, Name = "Mark", Age = 21, GPA = 3.2, IsHonors = false }
             );
    }
}
