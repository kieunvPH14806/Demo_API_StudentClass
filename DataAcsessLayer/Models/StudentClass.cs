using Demo_API_StudentClass.Models;

namespace Demo_API_StudentClass.Data.Models;

public class StudentClass
{
    public int IdClass { get; set; }
    public int IdStudent { get; set; }
    public bool State { get; set; }
    public Student Student { get; set; }
    public Class Class { get; set; }
}