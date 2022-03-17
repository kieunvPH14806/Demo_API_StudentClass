namespace Demo_API_StudentClass.BUS.Models;

public class Students
{
    private int id; 
    private string name;
    private DateTime birth;
    private string nameClass;
    private string clasroom;

    public Students()
    {
        
    }

    public Students(int id, string name, DateTime birth, string nameClass, string clasroom)
    {
        this.id = id;
        this.name = name;
        this.birth = birth;
        this.nameClass = nameClass;
        this.clasroom = clasroom;
    }

    public int Id
    {
        get => id;
        set => id = value;
    }

    public string Name
    {
        get => name;
        set => name = value ?? throw new ArgumentNullException(nameof(value));
    }

    public DateTime Birth
    {
        get => birth;
        set => birth = value;
    }

    public string NameClass
    {
        get => nameClass;
        set => nameClass = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string Clasroom
    {
        get => clasroom;
        set => clasroom = value ?? throw new ArgumentNullException(nameof(value));
    }
}