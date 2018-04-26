using QIQO.Orders.Data;
using QIQO.Orders.Domain;

namespace QIQO.Orders.Manager
{
    public class AccountTypeEntityService : IAccountTypeEntityService
    {
        public AccountType Map(AccountTypeData commentData) => new AccountType(commentData);
        public AccountTypeData Map(AccountType comment) => new AccountTypeData()
        {
            AccountTypeKey = comment.AccountTypeKey,
            AccountTypeCode = comment.AccountTypeCode,
            AccountTypeName = comment.AccountTypeName,
            AccountTypeDesc = comment.AccountTypeDesc
        };
    }
}
