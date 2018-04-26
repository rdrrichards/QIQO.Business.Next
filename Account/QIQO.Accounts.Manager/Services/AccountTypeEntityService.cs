using QIQO.Accounts.Data;
using QIQO.Accounts.Domain;

namespace QIQO.Accounts.Manager
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
