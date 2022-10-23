using System.Collections.Generic;

namespace QIQO.Business.Core.Contracts
{
    public interface IRepository { }

    public interface IReadRepository<T> : IRepository
        where T : class, IReadOnlyEntity, new()
    {
        IEnumerable<T> GetAll();
        T GetByID(int entityKey);
        T GetByCode(string accountCode, string entityCode);
    }

    public interface IWriteRepository<T> : IRepository
        where T : class, IWriteOnlyEntity, new()
    {
        void Insert(T entity);
        void Delete(T entity);
        void DeleteByID(int entityKey);
        void DeleteByCode(string entityCode);
        void Save(T entity);
    }

    public interface IRepository<T> : IReadRepository<T>, IWriteRepository<T> where T : class, IEntity, new()  { }

}
