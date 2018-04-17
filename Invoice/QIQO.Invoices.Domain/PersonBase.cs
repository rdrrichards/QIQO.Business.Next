using QIQO.Business.Core.Contracts;
using System;
using System.Collections.Generic;

namespace QIQO.Invoices.Domain
{
    public class PersonBase : IModel
    {        
        public int PersonKey { get; set; }        
        public string PersonCode { get; set; }        
        public string PersonFirstName { get; set; }        
        public string PersonMI { get; set; }        
        public string PersonLastName { get; set; }        
        public string PersonFullNameFL { get; set; }        
        public string PersonFullNameFML { get; set; }        
        public string PersonFullNameLF { get; set; }        
        public string PersonFullNameLFM { get; set; }        
        public DateTime? PersonDOB { get; set; }        
        //public List<Address> Addresses { get; set; } = new List<Address>();        
        //public List<EntityAttribute> PersonAttributes { get; set; } = new List<EntityAttribute>();        
        public string AddedUserID { get; set; }        
        public DateTime AddedDateTime { get; set; }        
        public string UpdateUserID { get; set; }        
        public DateTime UpdateDateTime { get; set; }
        //public QIQOPersonType Type  { get; set; }        
        //public PersonType PersonTypeData { get; set; } = new PersonType();
    }
}
