using QIQO.Business.Core.Contracts;
using QIQO.Orders.Data;
using System;

namespace QIQO.Orders.Domain
{
    public class PersonBase : IModel
    {
        public PersonBase(PersonData personData)
        {
            PersonKey = personData.PersonKey;
            PersonFirstName = personData.PersonFirstName;
            PersonMi = personData.PersonMi;
            PersonLastName = personData.PersonLastName;
            PersonCode = personData.PersonCode;
            PersonDob = personData.PersonDob;
        }
        public int PersonKey { get; private set; }
        public string PersonCode { get; private set; }
        public string PersonFirstName { get; private set; }
        public string PersonMi { get; private set; }
        public string PersonLastName { get; private set; }
        public string PersonFullNameFL => $"{PersonFirstName} {PersonLastName}";
        public string PersonFullNameFML => $"{PersonFirstName} {PersonMi} {PersonLastName}";
        public string PersonFullNameLF => $"{PersonLastName}, {PersonFirstName}";
        public string PersonFullNameLFM => $"{PersonLastName}, {PersonFirstName} {PersonMi}";
        public DateTime? PersonDob { get; private set; }
        //public List<Address> Addresses { get; private set; } = new List<Address>();        
        //public List<EntityAttribute> PersonAttributes { get; private set; } = new List<EntityAttribute>();        
        public string AddedUserID { get; private set; }
        public DateTime AddedDateTime { get; private set; }
        public string UpdateUserID { get; private set; }
        public DateTime UpdateDateTime { get; private set; }
        //public QIQOPersonType Type  { get; private set; }        
        //public PersonType PersonTypeData { get; private set; } = new PersonType();
    }
}
