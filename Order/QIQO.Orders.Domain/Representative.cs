using System.Collections.Generic;
using QIQO.Orders.Data;

namespace QIQO.Orders.Domain
{
    public class Representative : PersonBase
    {
        public Representative(PersonData personData) : base(personData)
        {
        }

        public List<Account> Accounts { get; private set; } = new List<Account>();
        //public Representative() { }
        //public Representative(QIQOPersonType RepType)
        //{
        //    // CompanyRoleType = RepType;
        //}
    }
}