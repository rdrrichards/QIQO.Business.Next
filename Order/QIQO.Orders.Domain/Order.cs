using QIQO.Business.Core.Contracts;
using QIQO.Orders.Data;
using System;
using System.Collections.Generic;

namespace QIQO.Orders.Domain
{
    public class Order: IModel
    {
        public Order(OrderHeaderData orderData)
        {
            OrderKey = orderData.OrderKey;
            OrderEntryDate = orderData.OrderEntryDate;
            AccountKey = orderData.AccountKey;
            AccountContactKey = orderData.AccountContactKey;
            OrderNumber = orderData.OrderNum;
            OrderCompleteDate = orderData.OrderCompleteDate;
            OrderItemCount = orderData.OrderItemCount;
            OrderValueSum = orderData.OrderValueSum;
            OrderStatusDate = orderData.OrderStatusDate;
            OrderShipDate = orderData.OrderShipDate;
            OrderStatus = (QIQOOrderStatus)orderData.OrderStatusKey;
            DeliverByDate = orderData.DeliverByDate;
            AccountRepKey = orderData.AccountRepKey;
            SalesRepKey = orderData.SalesRepKey;
            AddedUserID = orderData.AuditAddUserId;
            AddedDateTime = orderData.AuditAddDatetime;
            UpdateUserID = orderData.AuditUpdateUserId;
            UpdateDateTime = orderData.AuditUpdateDatetime;
        }
        public Order(string orderNumber, DateTime orderEntryDate)
        {
            OrderNumber = orderNumber;
            OrderEntryDate = orderEntryDate;
        }
        public Order(DateTime orderEntryDate)
        {
            OrderEntryDate = orderEntryDate;
        }
        public int OrderKey { get; private set; }
        public int AccountKey { get; private set; }
        public Account Account { get; private set; }
        public int AccountContactKey { get; private set; }
        public string OrderNumber { get; private set; }        
        public PersonBase OrderAccountContact { get; private set; } //= new PersonBase();        
        public int OrderItemCount { get; private set; }        
        public decimal OrderValueSum { get; private set; }    
        public DateTime OrderEntryDate { get; private set; }        
        public DateTime OrderStatusDate { get; private set; }        
        public DateTime? OrderShipDate { get; private set; }        
        public DateTime? OrderCompleteDate { get; private set; }        
        public DateTime? DeliverByDate { get; private set; }
        public int SalesRepKey { get; private set; }        
        public Representative SalesRep { get; private set; } //= new Representative(QIQOPersonType.SalesRepresentative);        
        public int AccountRepKey { get; private set; }        
        public Representative AccountRep { get; private set; } //= new Representative(QIQOPersonType.AccountRepresentative);        
        public QIQOOrderStatus OrderStatus { get; private set; } = QIQOOrderStatus.Open;        
        public OrderStatus OrderStatusData { get; private set; } //= new OrderStatus();        
        public List<OrderItem> OrderItems { get; private set; } = new List<OrderItem>();        
        public List<Comment> Comments { get; private set; } = new List<Comment>();        
        public string AddedUserID { get; private set; }        
        public DateTime AddedDateTime { get; private set; }        
        public string UpdateUserID { get; private set; }        
        public DateTime UpdateDateTime { get; private set; }
    }
}
