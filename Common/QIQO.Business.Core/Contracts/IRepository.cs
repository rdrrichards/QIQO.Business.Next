using System.Collections.Generic;

namespace QIQO.Business.Core.Contracts
{
    public interface IRepository { }

    public interface IReadRepository<T> : IRepository
        where T : class, IEntity, new()
    {
        IEnumerable<T> GetAll();
        T GetByID(int entity_key);
        T GetByCode(string account_code, string entity_code);
    }

    public interface IWriteRepository<T> : IRepository
        where T : class, IEntity, new()
    {
        void Insert(T entity);
        void Delete(T entity);
        void DeleteByID(int entity_key);
        void DeleteByCode(string entity_code);
        void Save(T entity);
    }

    public interface IRepository<T> : IReadRepository<T>, IWriteRepository<T> where T : class, IEntity, new()  { }

}
