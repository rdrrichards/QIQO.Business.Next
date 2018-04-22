using QIQO.Business.Core.Contracts;
using QIQO.Orders.Data;
using System;
using System.Collections.Generic;

namespace QIQO.Orders.Domain
{
    public class OrderItem: IModel
    {
        public OrderItem(OrderItemData orderItemData)
        {
            OrderItemKey = orderItemData.OrderItemKey;
            OrderKey = orderItemData.OrderKey;
            OrderItemSeq = orderItemData.OrderItemSeq;
            ProductKey = orderItemData.ProductKey;
            ProductName = orderItemData.ProductName;
            ProductDesc = orderItemData.ProductDesc;
            OrderItemQuantity = orderItemData.OrderItemQuantity;
            OrderItemShipDate = orderItemData.OrderItemShipDate;
            OrderItemCompleteDate = orderItemData.OrderItemCompleteDate;
            ItemPricePer = orderItemData.OrderItemPricePer;
            OrderItemLineSum = orderItemData.OrderItemLineSum;
            AddedUserID = orderItemData.AuditAddUserId;
            AddedDateTime = orderItemData.AuditAddDatetime;
            UpdateUserID = orderItemData.AuditUpdateUserId;
            UpdateDateTime = orderItemData.AuditUpdateDatetime;
            OrderItemStatus = (QIQOOrderItemStatus)orderItemData.OrderItemStatusKey;
        }
        public int OrderItemKey { get; private set; }        
        public int OrderKey { get; private set; }        
        public int OrderItemSeq { get; private set; }        
        public int ProductKey { get; private set; }        
        public string ProductCode { get; private set; }        
        public string ProductName { get; private set; }        
        public string ProductDesc { get; private set; }        
        public int OrderItemQuantity { get; private set; }        
        public Address OrderItemShipToAddress { get; private set; } //= new Address();        
        public Address OrderItemBillToAddress { get; private set; } //= new Address();        
        public DateTime? OrderItemShipDate { get; private set; }        
        public DateTime? OrderItemCompleteDate { get; private set; }        
        public decimal ItemPricePer { get; private set; }        
        public decimal OrderItemLineSum { get; private set; }        
        public Representative SalesRep { get; private set; } //= new Representative(QIQOPersonType.SalesRepresentative);        
        public Representative AccountRep { get; private set; } //= new Representative(QIQOPersonType.AccountRepresentative);        
        public QIQOOrderItemStatus OrderItemStatus { get; private set; } = QIQOOrderItemStatus.Open;        
        public OrderItemStatus OrderItemStatusData { get; private set; } //= new OrderItemStatus();        
        public Product OrderItemProduct { get; private set; } //= new Product();       
        public List<Comment> Comments { get; private set; } = new List<Comment>();        
        public string AddedUserID { get; private set; }        
        public DateTime AddedDateTime { get; private set; }        
        public string UpdateUserID { get; private set; }        
        public DateTime UpdateDateTime { get; private set; }
    }
}
