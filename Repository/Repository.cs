using System.Data;
// using Dapper;
using Dapper.Contrib.Extensions;

namespace KorliakovBackendTestTask.Repository;

public class Repository<T> : IRepository<T> where T : class {
    private readonly IDbConnection _dbConnection;

    public Repository(IDbConnection dbConnection) {
        _dbConnection = dbConnection;
    }

    public long Create(T obj) {
        return _dbConnection.Insert(obj);
    }

    public T? Read(string id) {
        // для того, щоб не писати кожен раз цей запит, я використав бібліотеку Dapper.Contrib 
        // const string query = "SELECT * FROM Client WHERE DeviceToken = @DeviceToken";
        //
        // var client = _dbConnection.QueryFirstOrDefault<T>(query, new { DeviceToken = id });
        
        var client = _dbConnection.Get<T>(id);
        
        return client;
    }

    public void Update(T obj) {
        _dbConnection.Update(obj);
    }

    public void Delete(T obj) {
        _dbConnection.Delete(obj);
    }
}