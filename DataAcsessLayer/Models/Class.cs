using System.ComponentModel.DataAnnotations;
using Demo_API_StudentClass.Data.Models;


namespace Demo_API_StudentClass.Models;

public class Class
{
    
    public int IdClass { get; set; }
    [StringLength(25)]
    public string NameClass { get; set; }
    [StringLength(5)]
    public string? Classroom { get; set; }
    public bool State { get; set; }

    public ICollection<StudentClass> StudentsClasses { get; set; }
}