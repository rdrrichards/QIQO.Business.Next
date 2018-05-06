using QIQO.Business.Core.Contracts;
using QIQO.Companies.Data;
using System;
using System.Collections.Generic;

namespace QIQO.Companies.Domain
{
    public class Company : IModel
    {
        public Company(CompanyData companyData)
        {
            CompanyKey = companyData.CompanyKey;
            CompanyCode = companyData.CompanyCode;
            CompanyName = companyData.CompanyName;
            CompanyDesc = companyData.CompanyDesc;
            AddedUserID = companyData.AuditAddUserId;
            AddedDateTime = companyData.AuditAddDatetime;
            UpdateUserID = companyData.AuditUpdateUserId;
            UpdateDateTime = companyData.AuditUpdateDatetime;
        }
        public Company(string companyCode, string companyName, string companyDesc)
        {
            CompanyCode = companyCode;
            CompanyName = companyName;
            CompanyDesc = companyDesc;
        }
        public Company(string companyName, string companyDesc)
        {
            CompanyName = companyName;
            CompanyDesc = companyDesc;
        }
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
