using Demo_API_StudentClass.Models;

namespace Demo_API_StudentClass.IServiceModels;

public interface IClassService
{
    public IQueryable<Class> GetList();
    public void Add(Class @object);
    public string Edit(Class @object);
    public string Delete(Class @object);
    public void Save();
}