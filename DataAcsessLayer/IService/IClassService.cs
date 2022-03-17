using Demo_API_StudentClass.Models;

namespace Demo_API_StudentClass.IServiceModels;

public interface IClassService
{
    public List<Class> GetList();
    public string Add(Class @object);
    public string Edit(Class @object);
    public string Delete(Class @object);
    public string Save();
}