using System.ComponentModel.DataAnnotations;
using Demo_API_StudentClass.Models;

namespace Demo_API_StudentClass.Data.Models;

public class Student
{
    public Guid Id { get; set; }
   // public int IdClass { get; set; }
    [StringLength(50)]
    public string Name { get; set; }
    public DateTime birth { get; set; }
    public bool State { get; set; }
    public ICollection<Class> StudentClasses { get; set; }
}
