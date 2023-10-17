namespace KorliakovBackendTestTask.Repository;

public interface IRepository<T> {
    public long Create(T obj);
    public T? Read(string id);
    public void Update(T obj);
    public void Delete(T obj);
}