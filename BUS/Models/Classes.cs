namespace Demo_API_StudentClass.BUS.Models;

public class Classes
{
    private int idClass;
    private string nameClass;
    private string classroom;

    public Classes()
    {
        
    }

    public Classes(int idClass, string nameClass, string classroom)
    {
        this.idClass = idClass;
        this.nameClass = nameClass;
        this.classroom = classroom;
    }

    public int IdClass
    {
        get => idClass;
        set => idClass = value;
    }

    public string NameClass
    {
        get => nameClass;
        set => nameClass = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string Classroom
    {
        get => classroom;
        set => classroom = value ?? throw new ArgumentNullException(nameof(value));
    }
}