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
                    InvoiceItemKey = NullCheck<int>(record["invoice_item_key"]),
                    InvoiceKey = NullCheck<int>(record["invoice_key"]),
                    InvoiceItemSeq = NullCheck<int>(record["invoice_item_seq"]),
                    ProductKey = NullCheck<int>(record["product_key"]),
                    ProductName = NullCheck<string>(record["product_name"]),
                    ProductDesc = NullCheck<string>(record["product_desc"]),
                    InvoiceItemQuantity = NullCheck<int>(record["invoice_item_quantity"]),
                    ShiptoAddrKey = NullCheck<int>(record["shipto_addr_key"]),
                    BilltoAddrKey = NullCheck<int>(record["billto_addr_key"]),
                    InvoiceItemEntryDate = (DBNull.Value == record["invoice_item_entry_date"]) ? null : record["invoice_item_entry_date"] as DateTime?,
                    OrderItemShipDate = (DBNull.Value == record["order_item_ship_date"]) ? null : record["order_item_ship_date"] as DateTime?,
                    InvoiceItemCompleteDate = (DBNull.Value == record["invoice_item_complete_date"]) ? null : record["invoice_item_complete_date"] as DateTime?,
                    InvoiceItemPricePer = NullCheck<decimal>(record["invoice_item_price_per"]),
                    InvoiceItemLineSum = NullCheck<decimal>(record["invoice_item_line_sum"]),
                    InvoiceItemAccountRepKey = NullCheck<int>(record["invoice_item_account_rep_key"]),
                    InvoiceItemSalesRepKey = NullCheck<int>(record["invoice_item_sales_rep_key"]),
                    InvoiceItemStatusKey = NullCheck<int>(record["invoice_item_status_key"]),
                    OrderItemKey = NullCheck<int>(record["order_item_key"]),
                    AuditAddUserId = NullCheck<string>(record["audit_add_user_id"]),
                    AuditAddDatetime = NullCheck<DateTime>(record["audit_add_datetime"]),
                    AuditUpdateUserId = NullCheck<string>(record["audit_update_user_id"]),
                    AuditUpdateDatetime = NullCheck<DateTime>(record["audit_update_datetime"])
                };
            }
            catch (Exception ex)
            {
                throw new MapException($"InvoiceItemMap Exception occured: {ex.Message}", ex);
            }
        }

        public List<SqlParameter> MapParamsForUpsert(InvoiceItemData entity) => new List<SqlParameter>
            {
                new SqlParameter("@invoice_item_key", entity.InvoiceItemKey),
                new SqlParameter("@invoice_key", entity.InvoiceKey),
                new SqlParameter("@invoice_item_seq", entity.InvoiceItemSeq),
                new SqlParameter("@product_key", entity.ProductKey),
                new SqlParameter("@product_name", entity.ProductName),
                new SqlParameter("@product_desc", entity.ProductDesc),
                new SqlParameter("@invoice_item_quantity", entity.InvoiceItemQuantity),
                new SqlParameter("@shipto_addr_key", entity.ShiptoAddrKey),
                new SqlParameter("@billto_addr_key", entity.BilltoAddrKey),
                new SqlParameter("@invoice_item_entry_date", entity.InvoiceItemEntryDate),
                new SqlParameter("@order_item_ship_date", entity.OrderItemShipDate),
                new SqlParameter("@invoice_item_complete_date", entity.InvoiceItemCompleteDate),
                new SqlParameter("@invoice_item_price_per", entity.InvoiceItemPricePer),
                new SqlParameter("@invoice_item_line_sum", entity.InvoiceItemLineSum),
                new SqlParameter("@invoice_item_account_rep_key", entity.InvoiceItemAccountRepKey),
                new SqlParameter("@invoice_item_sales_rep_key", entity.InvoiceItemSalesRepKey),
                new SqlParameter("@invoice_item_status_key", entity.InvoiceItemStatusKey),
                new SqlParameter("@order_item_key", entity.OrderItemKey),
                GetOutParam()
            };

        public List<SqlParameter> MapParamsForDelete(InvoiceItemData entity) => MapParamsForDelete(entity.InvoiceItemKey);

        public List<SqlParameter> MapParamsForDelete(int invoice_item_key) => new List<SqlParameter>
            {
                new SqlParameter("@invoice_item_key", invoice_item_key),
                GetOutParam()
            };
    }
}
