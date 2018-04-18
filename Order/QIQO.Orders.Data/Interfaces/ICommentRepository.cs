using QIQO.Business.Core.Contracts;
using System.Collections.Generic;

namespace QIQO.Orders.Data
{
    public interface ICommentRepository : IRepository<CommentData>
    {
        IEnumerable<CommentData> GetAll(int entity_key, int entity_type_key);
    }

}
