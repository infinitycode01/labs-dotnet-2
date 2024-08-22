namespace Lab3_AspNet_EF.Repositories;

public interface IBaseRepository<T> where T : class
{
    void Add(T objModel);
    void AddRange(IEnumerable<T> objModel);
    T? GetId(int id);
    IEnumerable<T> GetAll();
    int Count();
    void Update(T objModel);
    void Remove(T objModel);
}