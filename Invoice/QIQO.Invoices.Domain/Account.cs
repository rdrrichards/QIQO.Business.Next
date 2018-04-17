using QIQO.Business.Core.Contracts;
using System;
using System.Collections.Generic;

namespace QIQO.Invoices.Domain
{
    public class Account : IModel
    {        
        public int AccountKey { get; set; }        
        public int CompanyKey { get; set; }        
        public QIQOAccountType AccountType { get; set; } = QIQOAccountType.Business;        
        public AccountType AccountTypeData { get; set; } = new AccountType();        
        public string AccountCode { get; set; }        
        public string AccountName { get; set; }        
        public string AccountDesc { get; set; }        
        public string AccountDBA { get; set; }        
        public DateTime AccountStartDate { get; set; }        
        public DateTime AccountEndDate { get; set; }        
        public string AddedUserID { get; set; }        
        public DateTime AddedDateTime { get; set; }        
        public string UpdateUserID { get; set; }        
        public DateTime UpdateDateTime { get; set; }
        //public QIQOEntityType EntityType { get; private set; }        
        //public List<Address> Addresses { get; set; } = new List<Address>();        
        //public List<EntityAttribute> AccountAttributes { get; set; } = new List<EntityAttribute>();        
        //public List<FeeSchedule> FeeSchedules { get; set; } = new List<FeeSchedule>();        
        //public List<AccountPerson> Employees { get; set; } = new List<AccountPerson>();        
        //public List<Contact> Contacts { get; set; } = new List<Contact>();        
        //public List<Comment> Comments { get; set; } = new List<Comment>();
    }
}
