using System.Collections.Generic;

namespace QIQO.Orders.Domain
{
    public class Representative : PersonBase
    {        
        public List<Account> Accounts { get; set; } = new List<Account>();
        public Representative() { }
        public Representative(QIQOPersonType RepType)
        {
            // CompanyRoleType = RepType;
        }
    }
}