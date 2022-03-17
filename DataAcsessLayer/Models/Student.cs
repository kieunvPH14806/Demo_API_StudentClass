using System.ComponentModel.DataAnnotations;

namespace Demo_API_StudentClass.Data.Models;

public class Student
{
    public int IdStudent { get; set; }
   // public int IdClass { get; set; }
    [StringLength(50)]
    public string Name { get; set; }
    public DateTime birth { get; set; }
    public bool State { get; set; }
    public ICollection<StudentClass> StudentClasses { get; set; }
}
