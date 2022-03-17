using Demo_API_StudentClass.Data.Models;

namespace Demo_API_StudentClass.IServiceModels;

public interface IStudentService

{
    public List<Student> GetList();
    public string Add(Student @object);
    public string Edit(Student @object);
    public string Delete(Student @object);
    public string Save();
}