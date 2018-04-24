using System;

namespace QIQO.Companies.Data
{
    public class PersonData : CommonData
    {

        public int PersonKey { get; set; }
        public string PersonCode { get; set; }
        public string PersonFirstName { get; set; }
        public string PersonMi { get; set; }
        public string PersonLastName { get; set; }
        public int ParentPersonKey { get; set; }
        public DateTime? PersonDob { get; set; }
    }

    public class EmployeeData: PersonData
    {

    }
}
