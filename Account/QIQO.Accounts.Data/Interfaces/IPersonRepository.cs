using QIQO.Business.Core.Contracts;
using System.Collections.Generic;

namespace QIQO.Accounts.Data
{
    public interface IPersonRepository : IRepository<PersonData>
    {
        IEnumerable<PersonData> GetAll(CompanyData comp);
        IEnumerable<PersonData> GetAll(AccountData acct);
        PersonData GetByUserName(string user_name);
        IEnumerable<PersonData> GetAllReps(CompanyData comp, int rep_type);
    }

}
