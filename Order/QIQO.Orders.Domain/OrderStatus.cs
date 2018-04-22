using QIQO.Business.Core.Contracts;
using QIQO.Orders.Data;
using System;

namespace QIQO.Orders.Domain
{
    public class OrderStatus : IModel
    {
        public OrderStatus(OrderStatusData orderStatusData)
        {
            OrderStatusKey = orderStatusData.OrderStatusKey;
            OrderStatusType = orderStatusData.OrderStatusType;
            OrderStatusCode = orderStatusData.OrderStatusCode;
            OrderStatusName = orderStatusData.OrderStatusName;
            OrderStatusDesc = orderStatusData.OrderStatusDesc;
            AddedUserID = orderStatusData.AuditAddUserId;
            AddedDateTime = orderStatusData.AuditAddDatetime;
            UpdateUserID = orderStatusData.AuditUpdateUserId;
            UpdateDateTime = orderStatusData.AuditUpdateDatetime;
        }
        public int OrderStatusKey { get; private set; }        
        public string OrderStatusCode { get; private set; }        
        public string OrderStatusName { get; private set; }        
        public string OrderStatusDesc { get; private set; }        
        public string OrderStatusType { get; private set; }        
        public string AddedUserID { get; private set; }        
        public DateTime AddedDateTime { get; private set; }        
        public string UpdateUserID { get; private set; }        
        public DateTime UpdateDateTime { get; private set; }
    }
}
