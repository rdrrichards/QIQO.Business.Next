using QIQO.Business.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QIQO.Companies.Domain
{
    public class Company : IModel
    {
        public int CompanyKey { get; private set; }
        public string CompanyCode { get; private set; }
        public string CompanyName { get; private set; }
        public string CompanyDesc { get; private set; }
        public string AddedUserID { get; private set; }
        public DateTime AddedDateTime { get; private set; }
        public string UpdateUserID { get; private set; }
        public DateTime UpdateDateTime { get; private set; }

        public List<Employee> Employees { get; private set; } = new List<Employee>();
        //public List<ChartOfAccount> GLAccounts { get; private set; } = new List<ChartOfAccount>();
        //public List<Ledger> Ledgers { get; private set; } = new List<Ledger>();
        public List<EntityAttribute> CompanyAttributes { get; private set; } = new List<EntityAttribute>();
        public List<Address> CompanyAddresses { get; private set; } = new List<Address>();
        public List<FeeSchedule> FeeSchedules { get; private set; } = new List<FeeSchedule>();
    }
}
