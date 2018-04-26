using QIQO.Invoices.Data;
using QIQO.Invoices.Domain;

namespace QIQO.Invoices.Manager
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
