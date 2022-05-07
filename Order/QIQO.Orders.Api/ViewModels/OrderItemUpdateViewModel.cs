﻿using QIQO.Orders.Domain;

namespace QIQO.Business.Api.Orders
{
    public class OrderItemUpdateViewModel
    {
        public int OrderItemKey { get; set; }
        public int OrderKey { get; set; }
        public int OrderItemSeq { get; set; }
        public int ProductKey { get; set; }
        public string ProductCode { get; set; } = string.Empty;
        public string ProductName { get; set; } = string.Empty;
        public string ProductDesc { get; set; } = string.Empty;
        public int OrderItemQuantity { get; set; }
        public OrderAddressUpdateViewModel? OrderItemShipToAddress { get; set; } //= new Address();        
        public OrderAddressUpdateViewModel? OrderItemBillToAddress { get; set; } //= new Address();        
        public DateTime? OrderItemShipDate { get; set; }
        public DateTime? OrderItemCompleteDate { get; set; }
        public decimal ItemPricePer { get; set; }
        public decimal OrderItemLineSum { get; set; }
        public int SalesRepKey { get; set; }
        public int AccountRepKey { get; set; }
        public QIQOOrderItemStatus OrderItemStatus { get; set; } = QIQOOrderItemStatus.Open;     
        public List<OrderCommentUpdateViewModel> Comments { get; set; } = new List<OrderCommentUpdateViewModel>();
        public string UpdateUserID { get; set; } = string.Empty;
        public DateTime UpdateDateTime { get; set; }
    }
}
