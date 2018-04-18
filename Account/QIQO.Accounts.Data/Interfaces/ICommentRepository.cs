using QIQO.Business.Core.Contracts;
using System.Collections.Generic;

namespace QIQO.Accounts.Data
{
    public interface ICommentRepository : IRepository<CommentData>
    {
        IEnumerable<CommentData> GetAll(int entityKey, int entityTypeKey);
    }

}
