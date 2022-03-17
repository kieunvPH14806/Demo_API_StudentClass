using Demo_API_StudentClass.IServiceModels;
using Demo_API_StudentClass.BUS;
using Demo_API_StudentClass.BUS.Models;
using Demo_API_StudentClass.Data.Models;
using Demo_API_StudentClass.Models;

namespace Demo_API_StudentClass.BUS.Services;

public class StudentsService
{
    private readonly IStudentService _studentService;
    private readonly IClassService _classService;
    private readonly IStudentClassService _studentClassService;
    private List<Students> _lstStudents;
    private List<Student> _lstStudentData;
    private List<StudentClass> _lstStudentClassesData;
    private List<Class> _lstClassData;

    public StudentsService(IStudentService studentService, IClassService classService, IStudentClassService studentClassService)
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

    public List<Students> GetStudentsList()
    {
        _lstStudents = new List<Students>();
        var studentTemp =
            from student in _lstStudentData
            join _studentClass in _lstStudentClassesData on student.IdStudent equals _studentClass.IdStudent
            join _class in _lstClassData on _studentClass.IdClass equals _class.IdClass
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
            _lstStudents.Add(student);
        }

        return _lstStudents;
    }

    public List<Students> GetStudentsClass(string nameClass)
    {
        _lstStudents = new List<Students>();

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

            Students student = new Students(x.id,x.name,x.birth,x.className,x.Classroom);
            _lstStudents.Add(student);
        }

        return _lstStudents;
    }

    public List<Students> AddStudent(Students newStudent)
    {
        Student inputStudent = new Student();
        StudentClass inputStudentClass = new StudentClass();
        inputStudent.IdStudent = _lstStudentData.Max(c => c.IdStudent) + 1;
        inputStudent.Name = newStudent.Name;
        inputStudent.birth = newStudent.Birth;
        if (_lstClassData.Any(c => c.NameClass == newStudent.NameClass) == false)
        {
            Class inputClass = new Class();
            inputClass.IdClass = _lstClassData.Max(c => c.IdClass) + 1;
            inputClass.NameClass = newStudent.NameClass;
            inputClass.Classroom = newStudent.Clasroom;
            _classService.Add(inputClass);
            _classService.Save();
            GetData();
        }
        inputStudentClass.IdStudent = inputStudent.IdStudent;
        inputStudentClass.IdClass = _lstClassData[_lstClassData.FindIndex(c => c.NameClass == newStudent.NameClass)].IdClass;
        _studentService.Add(inputStudent);
        _studentClassService.Add(inputStudentClass);
        _studentService.Save();

        GetStudentsList();
        return _lstStudents;
    }
    public List<Students> EditStudent(Students studentEdited)
    {
        Student inputStudent = new Student();
        StudentClass inputStudentClass = new StudentClass();
        inputStudent.IdStudent = _lstStudentData[_lstStudentData.FindIndex(c => c.Name == studentEdited.Name)].IdStudent;
        inputStudent.Name = studentEdited.Name;
        inputStudent.birth = studentEdited.Birth;
        if (_lstClassData.Any(c => c.NameClass == studentEdited.NameClass) == false)
        {
            Class inputClass = new Class();
            inputClass.IdClass = _lstClassData.Max(c => c.IdClass) + 1;
            inputClass.NameClass = studentEdited.NameClass;
            inputClass.Classroom = studentEdited.Clasroom;
            _classService.Add(inputClass);
            _classService.Save();
            GetData();
        }
        inputStudentClass.IdStudent = inputStudent.IdStudent;
        inputStudentClass.IdClass = _lstClassData[_lstClassData.FindIndex(c => c.NameClass == studentEdited.NameClass)].IdClass;
        _studentService.Edit(inputStudent);
        _studentClassService.Edit(inputStudentClass);
        _studentService.Save();

        GetStudentsList();
        return _lstStudents;
    }

    public List<Students> DeleteStudent(Students deleteStudents)
    {
        Student StudentDelete = new Student();
        List<StudentClass> _lstStudentClassDelete = new List<StudentClass>();
        StudentDelete = _lstStudentData[_lstStudentData.FindIndex(c => c.Name == deleteStudents.Name)];
        _lstStudentClassDelete = _lstStudentClassesData.Where(c => c.IdStudent == StudentDelete.IdStudent).ToList();

        foreach (var studentClass in _lstStudentClassDelete)
        {
            _studentClassService.Delete(studentClass);
        }

        _studentService.Delete(StudentDelete);
        _studentService.Save();

        GetStudentsList();
        return _lstStudents;
    }
}