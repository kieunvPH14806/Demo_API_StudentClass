using Demo_API_StudentClass.Data.Models;
using Demo_API_StudentClass.DBContext;
using Demo_API_StudentClass.IServiceModels;

namespace Demo_API_StudentClass.Data.ServiceModels;

public class StudentClassService:IStudentClassService
{
    private readonly DbWebAPIContext _dbContext;

    public StudentClassService(DbWebAPIContext dbContext)
    {
        _dbContext = dbContext;
    }
    public List<StudentClass> GetList()
    {

        try
        {
            return _dbContext.Set<StudentClass>().ToList();
        }
        catch (Exception e)
        {
            return null;
        }
    }

    public string Add(StudentClass @object)
    {
        @object.State = true;
        try
        {
            _dbContext.Set<StudentClass>().Add(@object);
            return "successful";
        }
        catch (Exception e)
        {
            return e.Message;
        }
    }

    public string Edit(StudentClass @object)
    {
        try
        {
            _dbContext.Set<StudentClass>().Update(@object);
            return "successful";
        }
        catch (Exception e)
        {
            return e.Message;
        }
    }

    public string Delete(StudentClass @object)
    {
        @object.State = false;
        try
        {
            _dbContext.Set<StudentClass>().Update(@object);
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