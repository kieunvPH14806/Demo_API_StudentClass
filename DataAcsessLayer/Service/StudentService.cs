using Demo_API_StudentClass.Data.Models;
using Demo_API_StudentClass.DBContext;
using Demo_API_StudentClass.IServiceModels;
namespace Demo_API_StudentClass.Data.ServiceModels;

public class StudentService:IStudentService
{
    private readonly DbWebAPIContext _dbContext;

    //public ServiceModels()
    //{
    //    _dbContext = new DbWebAPIContext();
    //}
    public StudentService(DbWebAPIContext dbContext)
    {
        _dbContext = dbContext;
    }

    public List<Student> GetList()
    {

        try
        {
            return _dbContext.Set<Student>().ToList();
        }
        catch (Exception e)
        {
            return null;
        }
    }

    public string Add(Student @object)
    {
        @object.State = true;
        try
        {
            _dbContext.Set<Student>().Add(@object);
            return "successful";
        }
        catch (Exception e)
        {
            return e.Message;
        }
    }

    public string Edit(Student @object)
    {
        try
        {
            _dbContext.Set<Student>().Update(@object);
            return "successful";
        }
        catch (Exception e)
        {
            return e.Message;
        }
    }

    public string Delete(Student @object)
    {
        @object.State = false;
        try
        {
            _dbContext.Set<Student>().Update(@object);
            return "successful";
        }
        catch (Exception e)
        {
            return e.Message;
        }
    }

    public string Save()
    {
        try
        {
            _dbContext.SaveChanges();
            return "successful";
        }
        catch (Exception e)
        {
            return e.Message;
        }
    }
}