using Demo_API_StudentClass.Data.Models;

namespace Demo_API_StudentClass.IServiceModels;

public interface IStudentClassService
{
    public List<StudentClass> GetList();
    public string Add(StudentClass @object);
    public string Edit(StudentClass @object);
    public string Delete(StudentClass @object);
    public string Save();
}