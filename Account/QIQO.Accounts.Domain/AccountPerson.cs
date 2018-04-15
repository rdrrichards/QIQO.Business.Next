using QIQO.Business.Core.Contracts;
using System;
using System.Collections.Generic;

namespace QIQO.Accounts.Domain
{
    public class AccountPerson : IModel
    {
        public int PersonKey { get; private set; }
        public string PersonCode { get; private set; }
        public string PersonFirstName { get; private set; }
        public string PersonMI { get; private set; }
        public string PersonLastName { get; private set; }
        public string PersonFullNameFL => $"{PersonFirstName} {PersonLastName}";
        public string PersonFullNameFML => $"{PersonFirstName} {PersonMI} {PersonLastName}";
        public string PersonFullNameLF => $"{PersonLastName}, {PersonFirstName}";
        public string PersonFullNameLFM => $"{PersonLastName}, {PersonFirstName} {PersonMI}";
        public DateTime? PersonDOB { get; private set; }
        public string AddedUserID { get; private set; }
        public DateTime AddedDateTime { get; private set; }
        public string UpdateUserID { get; private set; }
        public DateTime UpdateDateTime { get; private set; }
        public string RoleInCompany { get; private set; }
        public int EntityPersonKey { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public string Comment { get; private set; }
        public QIQOPersonType CompanyRoleType => QIQOPersonType.AccountEmployee;
        public List<Address> Addresses { get; private set; } = new List<Address>();
        public List<EntityAttribute> PersonAttributes { get; private set; } = new List<EntityAttribute>();
    }
}
