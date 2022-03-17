using Demo_API_StudentClass.BUS.Models;
using Demo_API_StudentClass.Data.Models;
using Demo_API_StudentClass.IServiceModels;
using Demo_API_StudentClass.Models;

namespace Demo_API_StudentClass.BUS.Services;

public class ClassService
{

    private readonly IStudentService _studentService;
    private readonly IClassService _classService;
    private readonly IStudentClassService _studentClassService;
    private List<Classes> _lstClass;
    private List<Student> _lstStudentData;
    private List<StudentClass> _lstStudentClassesData;
    private List<Class> _lstClassData;

    public ClassService(IStudentService studentService, IClassService classService,
        IStudentClassService studentClassService)
    {
        _studentService = studentService;
        _classService = classService;
        _studentClassService = studentClassService;
        GetData();
    }

    public void GetData()
    {
        _lstStudentClassesData = new List<StudentClass>();
        _lstClassData = new List<Class>();
        _lstStudentData = new List<Student>();
        _lstClassData = _classService.GetList().Where(c => c.State == true).ToList();
        _lstStudentData = _studentService.GetList().Where(c => c.State == true).ToList();
        _lstStudentClassesData = _studentClassService.GetList().Where(c => c.State == true).ToList();

    }

    public List<Classes> GetClassesList()
    {
        _lstClass = new List<Classes>();
        var classTemp =
            from _class in _lstClassData
            join _studentClass in _lstStudentClassesData on _class.IdClass equals _studentClass.IdClass
            join student in _lstStudentData on _studentClass.IdStudent equals student.IdStudent
            select new
            {
                id = _class.IdClass,
                NameClass = _class.NameClass,
                Classroom = _class.Classroom
            };
        foreach (var x in classTemp)
        {
            Classes newClasses = new Classes(x.id,x.NameClass,x.Classroom);
            _lstClass.Add(newClasses);
        }
        return _lstClass;
    }

    public List<Students> GetStudentsInClass(string nameClass)
    {
        List<Students> _lstStudent = new List<Students>();
        _lstStudent = new List<Students>();
        var studentTemp =
            from student in _lstStudentData
            join _studentClass in _lstStudentClassesData on student.IdStudent equals _studentClass.IdStudent
            join _class in _lstClassData on _studentClass.IdClass equals _class.IdClass
            where _class.NameClass == nameClass
            select new
            {
                id = student.IdStudent,
                name = student.Name,
                birth = student.birth,
                className = _class.NameClass,
                Classroom = _class.Classroom
            };
        foreach (var x in studentTemp)
        {

            Students student = new Students();
            student.Id = x.id;
            student.Name = x.name;
            student.Birth = x.birth;
            student.NameClass = x.className;
            student.Clasroom = x.Classroom;
            _lstStudent.Add(student);
        }


        return _lstStudent;
    }

    public List<Classes> AddClass(Classes newClass)
    {
        Class inputClass = new Class();
        inputClass.IdClass = newClass.IdClass;
        inputClass.NameClass = newClass.NameClass;
        inputClass.Classroom = newClass.Classroom;

        
        return _lstClass;
    }
}

