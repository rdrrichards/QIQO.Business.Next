using QIQO.Business.Core.Contracts;
using System.Collections.Generic;

namespace QIQO.Invoices.Data
{
    public interface ICommentRepository : IRepository<CommentData>
    {
        IEnumerable<CommentData> GetAll(int entity_key, int entity_type_key);
    }
    public interface ICommentTypeRepository : IRepository<CommentTypeData> { }
}
