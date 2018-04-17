using QIQO.Business.Core.Contracts;
using System;

namespace QIQO.Orders.Domain
{
    public class AddressType : IModel
    {        
        public int AddressTypeKey { get; set; }
        //public string AddressCategory { get; set; }        
        public string AddressTypeCode { get; set; }        
        public string AddressTypeName { get; set; }        
        public string AddressTypeDesc { get; set; }        
        public string AddedUserID { get; set; }        
        public DateTime AddedDateTime { get; set; }        
        public string UpdateUserID { get; set; }        
        public DateTime UpdateDateTime { get; set; }
    }
}
