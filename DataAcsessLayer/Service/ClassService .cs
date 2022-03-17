using Demo_API_StudentClass.Data.Models;
using Demo_API_StudentClass.DBContext;
using Demo_API_StudentClass.IServiceModels;
using Demo_API_StudentClass.Models;

namespace Demo_API_StudentClass.Data.ServiceModels;

public class ClassService:IClassService
{
    private readonly DbWebAPIContext _dbContext;

    //public ServiceModels()
    //{
    //    _dbContext = new DbWebAPIContext();
    //}
    public ClassService(DbWebAPIContext dbContext)
    {
        _dbContext = dbContext;
    }

    public List<Class> GetList()
    {

        try
        {
            return _dbContext.Set<Class>().ToList();
        }
        catch (Exception e)
        {
            return null;
        }
    }

    public string Add(Class @object)
    {
        @object.State = true;
        try
        {
            _dbContext.Set<Class>().Add(@object);
            return "successful";
        }
        catch (Exception e)
        {
            return e.Message;
        }
    }

    public string Edit(Class @object)
    {
        try
        {
            _dbContext.Set<Class>().Update(@object);
            return "successful";
        }
        catch (Exception e)
        {
            return e.Message;
        }
    }

    public string Delete(Class @object)
    {
        @object.State = true;
        try
        {
            _dbContext.Set<Class>().Update(@object);
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