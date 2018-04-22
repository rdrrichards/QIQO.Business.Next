using QIQO.Business.Core.Contracts;
using QIQO.Orders.Data;
using System;

namespace QIQO.Orders.Domain
{
    public class OrderItemStatus: IModel
    {
        public OrderItemStatus(OrderStatusData orderItemStatusData)
        {
            OrderItemStatusKey = orderItemStatusData.OrderStatusKey;
            OrderItemStatusType = orderItemStatusData.OrderStatusType;
            OrderItemStatusCode = orderItemStatusData.OrderStatusCode;
            OrderItemStatusName = orderItemStatusData.OrderStatusName;
            OrderItemStatusDesc = orderItemStatusData.OrderStatusDesc;
            AddedUserID = orderItemStatusData.AuditAddUserId;
            AddedDateTime = orderItemStatusData.AuditAddDatetime;
            UpdateUserID = orderItemStatusData.AuditUpdateUserId;
            UpdateDateTime = orderItemStatusData.AuditUpdateDatetime;
        }
        public int OrderItemStatusKey { get; private set; }        
        public string OrderItemStatusCode { get; private set; }        
        public string OrderItemStatusName { get; private set; }        
        public string OrderItemStatusDesc { get; private set; }        
        public string OrderItemStatusType { get; private set; }        
        public string AddedUserID { get; private set; }        
        public DateTime AddedDateTime { get; private set; }        
        public string UpdateUserID { get; private set; }        
        public DateTime UpdateDateTime { get; private set; }    }
}
