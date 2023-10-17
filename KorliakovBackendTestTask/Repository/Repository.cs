using System.Data;
using Dapper;
using Dapper.Contrib.Extensions;

namespace KorliakovBackendTestTask.Repository;

public class Repository<T> : IRepository<T> where T : class {
    private readonly IDbConnection _dbConnection;

    public Repository(IDbConnection dbConnection) {
        _dbConnection = dbConnection;
    }
    
    // в цьому методі _dbConnection.Create(obj) не повертав affectedRows, тому і довелося робити звичайним запитом
    public long Create(T obj) {
        const string query = "INSERT INTO Client VALUES(@DeviceToken, @Color, @Price)";
        var affectedRows = _dbConnection.Execute(query, obj);
        return affectedRows;
    }
    
    // щоб не писати кожен раз усім відомі sql запити, я краще скористаюсь бібліотекою Dapper.Contrib
    public T? Read(string id) {
        return _dbConnection.Get<T>(id);
    }

    public void Update(T obj) {
        _dbConnection.Update(obj);
    }

    public void Delete(T obj) {
        _dbConnection.Delete(obj);
    }
}