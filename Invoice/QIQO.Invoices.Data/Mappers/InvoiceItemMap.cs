using QIQO.Business.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace QIQO.Invoices.Data
{
    public class InvoiceItemMap : MapperBase, IInvoiceItemMap
    {
        public InvoiceItemData Map(IDataReader record)
        {
            try
            {
                return new InvoiceItemData()
                {
                    InvoiceItemKey = NullCheck<int>(record["InvoiceItemKey"]),
                    InvoiceKey = NullCheck<int>(record["InvoiceKey"]),
                    InvoiceItemSeq = NullCheck<int>(record["InvoiceItemSeq"]),
                    ProductKey = NullCheck<int>(record["ProductKey"]),
                    ProductName = NullCheck<string>(record["ProductName"]),
                    ProductDesc = NullCheck<string>(record["ProductDescription"]),
                    InvoiceItemQuantity = NullCheck<int>(record["InvoiceItemQuantity"]),
                    ShiptoAddrKey = NullCheck<int>(record["ShipToAddressKey"]),
                    BilltoAddrKey = NullCheck<int>(record["BillToAddressKey"]),
                    InvoiceItemEntryDate = (DBNull.Value == record["InvoiceItemEntryDate"]) ? null : record["InvoiceItemEntryDate"] as DateTime?,
                    OrderItemShipDate = (DBNull.Value == record["OrderItemShipDate"]) ? null : record["OrderItemShipDate"] as DateTime?,
                    InvoiceItemCompleteDate = (DBNull.Value == record["InvoiceItemCompleteDate"]) ? null : record["InvoiceItemCompleteDate"] as DateTime?,
                    InvoiceItemPricePer = NullCheck<decimal>(record["InvoiceItemPricePer"]),
                    InvoiceItemLineSum = NullCheck<decimal>(record["InvoiceItemLineSum"]),
                    InvoiceItemAccountRepKey = NullCheck<int>(record["InvoiceItemAccountRepKey"]),
                    InvoiceItemSalesRepKey = NullCheck<int>(record["InvoiceItemSalesRepKey"]),
                    InvoiceItemStatusKey = NullCheck<int>(record["InvoiceItemStatusKey"]),
                    OrderItemKey = NullCheck<int>(record["OrderItemKey"]),
                    AuditAddUserId = NullCheck<string>(record["AuditAddUserId"]),
                    AuditAddDatetime = NullCheck<DateTime>(record["AuditAddDateTime"]),
                    AuditUpdateUserId = NullCheck<string>(record["AuditUpdateUserId"]),
                    AuditUpdateDatetime = NullCheck<DateTime>(record["AuditUpdateDateTime"])
                };
            }
            catch (Exception ex)
            {
                throw new MapException($"InvoiceItemMap Exception occured: {ex.Message}", ex);
            }
        }

        public List<SqlParameter> MapParamsForUpsert(InvoiceItemData entity) => new List<SqlParameter>
            {
                new SqlParameter("@InvoiceItemKey", entity.InvoiceItemKey),
                new SqlParameter("@InvoiceKey", entity.InvoiceKey),
                new SqlParameter("@InvoiceItemSeq", entity.InvoiceItemSeq),
                new SqlParameter("@ProductKey", entity.ProductKey),
                new SqlParameter("@ProductName", entity.ProductName),
                new SqlParameter("@ProductDescription", entity.ProductDesc),
                new SqlParameter("@InvoiceItemQuantity", entity.InvoiceItemQuantity),
                new SqlParameter("@ShipToAddressKey", entity.ShiptoAddrKey),
                new SqlParameter("@BillToAddressKey", entity.BilltoAddrKey),
                new SqlParameter("@InvoiceItemEntryDate", entity.InvoiceItemEntryDate),
                new SqlParameter("@OrderItemShipDate", entity.OrderItemShipDate),
                new SqlParameter("@InvoiceItemCompleteDate", entity.InvoiceItemCompleteDate),
                new SqlParameter("@InvoiceItemPricePer", entity.InvoiceItemPricePer),
                new SqlParameter("@InvoiceItemLineSum", entity.InvoiceItemLineSum),
                new SqlParameter("@InvoiceItemAccountRepKey", entity.InvoiceItemAccountRepKey),
                new SqlParameter("@InvoiceItemSalesRepKey", entity.InvoiceItemSalesRepKey),
                new SqlParameter("@InvoiceItemStatusKey", entity.InvoiceItemStatusKey),
                new SqlParameter("@OrderItemKey", entity.OrderItemKey),
                GetOutParam()
            };

        public List<SqlParameter> MapParamsForDelete(InvoiceItemData entity) => MapParamsForDelete(entity.InvoiceItemKey);

        public List<SqlParameter> MapParamsForDelete(int invoice_item_key) => new List<SqlParameter>
            {
                new SqlParameter("@InvoiceItemKey", invoice_item_key),
                GetOutParam()
            };
    }
}
