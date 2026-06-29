namespace Tamrin.Interfaces;

public interface IService<T>
{
    public void Insert(T model);
    public void Update(T model);
    public void Delete(T model);
    public T GetById(int id);
    public List<T> GetAll();
}