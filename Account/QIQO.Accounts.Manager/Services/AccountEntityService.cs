using QIQO.Accounts.Data;
using QIQO.Accounts.Domain;

namespace QIQO.Accounts.Manager
{
    public class AccountEntityService : IAccountEntityService
    {
        public Account Map(AccountData ent) => new Account(ent);

        public AccountData Map(Account ent) => new AccountData
        {
            AccountCode = ent.AccountCode,
            AccountName = ent.AccountName,
            AccountDesc = ent.AccountDesc,
            AccountDba = ent.AccountDba,
            AccountStartDate = ent.AccountStartDate,
            AccountEndDate = ent.AccountEndDate,
            AccountKey = ent.AccountKey,
            AccountTypeKey = (int)ent.AccountType,
        };
    }
}
