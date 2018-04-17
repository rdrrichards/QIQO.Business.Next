using QIQO.Business.Core.Contracts;
using System;

namespace QIQO.Orders.Domain
{
    public class OrderItemStatus: IModel
    {        
        public int OrderItemStatusKey { get; set; }        
        public string OrderItemStatusCode { get; set; }        
        public string OrderItemStatusName { get; set; }        
        public string OrderItemStatusDesc { get; set; }        
        public string OrderItemStatusType { get; set; }        
        public string AddedUserID { get; set; }        
        public DateTime AddedDateTime { get; set; }        
        public string UpdateUserID { get; set; }        
        public DateTime UpdateDateTime { get; set; }    }
}
