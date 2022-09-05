SET IDENTITY_INSERT AccountType ON;
INSERT INTO AccountType ([AccountTypeKey], [AccountTypeCode], [AccountTypeName], [AccountTypeDescription])
SELECT [account_type_key], [account_type_code], [account_type_name], [account_type_desc] FROM DevII.dbo.account_type;

SET IDENTITY_INSERT AccountType OFF;

SELECT * FROM AccountType;

SET IDENTITY_INSERT Company ON;
INSERT INTO Company ([CompanyKey], [CompanyCode], [CompanyName], [CompanyDescription])
SELECT company_key, company_code, company_name, company_desc FROM DevII.dbo.company;

SET IDENTITY_INSERT Company OFF;

SELECT * FROM Company;


SET IDENTITY_INSERT Account ON;
INSERT INTO Account ([AccountKey], [CompanyKey], [AccountTypeKey], [AccountCode], 
	[AccountName], [AccountDescription], [AccountDba], [AccountStartDate], [AccountEndDate])
SELECT [account_key], [company_key], [account_type_key], [account_code], 
	[account_name], [account_desc], [account_dba], [account_start_date], [account_end_date] FROM DevII.dbo.account;

SET IDENTITY_INSERT Account OFF;

SELECT * FROM Account;


SET IDENTITY_INSERT AddressType ON;
INSERT INTO AddressType (AddressTypeKey, AddressTypeCode, AddressTypeDescription, AddressTypeName)
SELECT address_type_key, address_type_code, address_type_desc, address_type_name FROM DevII.dbo.address_type;

SET IDENTITY_INSERT AddressType OFF;

SELECT * FROM AddressType;

INSERT INTO AddressPostal
SELECT * FROM DevII.dbo.address_postal

SELECT * FROM AddressPostal;

SET IDENTITY_INSERT EntityType ON;
INSERT INTO EntityType (EntityTypeKey, EntityTypeCode, EntityTypeName)
SELECT entity_type_key, entity_type_code, entity_type_name FROM DevII.dbo.entity_type;

SET IDENTITY_INSERT EntityType OFF;
SELECT * FROM EntityType 

SELECT * FROM [Address] WHERE EntityTypeKey != 3;
SELECT * FROM DevII.dbo.[address] WHERE entity_type_key != 3;

SET IDENTITY_INSERT [Address] ON;
INSERT INTO [Address] (AddressKey, AddressTypeKey, EntityKey, EntityTypeKey, AddressLine1, AddressLine2, AddressLine3, AddressLine4, 
	AddressCity, AddressState, AddressCounty, AddressCountry, AddressPostalCode, AddressNotes, AddressDefault, AddressActive)
SELECT [address_key], [address_type_key], [entity_key], [entity_type_key], [address_line_1], [address_line_2], [address_line_3], [address_line_4], 
	[address_city], [address_state_prov], [address_county], [address_country], [address_postal_code], [address_notes], [address_default_flg], [address_active_flg] 
FROM DevII.dbo.[address] -- WHERE entity_type_key = 3;

SET IDENTITY_INSERT [Address] OFF;

SET IDENTITY_INSERT AttributeType ON;
INSERT INTO AttributeType ([AttributeTypeKey], [AttributeTypeCategory], [AttributeTypeCode], [AttributeTypeName], [AttributeTypeDescription], [AttributeDataTypeKey], [AttributeDefaultFormat])
SELECT [attribute_type_key], [attribute_type_category], [attribute_type_code], [attribute_type_name], [attribute_type_desc], [attribute_data_type_key], [attribute_default_format] FROM DevII.dbo.attribute_type;

SET IDENTITY_INSERT AttributeType OFF;
SELECT * FROM AttributeType;

SELECT * FROM DevII.dbo.attribute WHERE entity_type_key = 3;


SET IDENTITY_INSERT Attribute ON;
INSERT INTO Attribute ([AttributeKey], [EntityKey], [EntityTypeKey], [AttributeTypeKey], [AttributeValue], [AttributeDataTypeKey], [AttributeDisplayFormat])
SELECT [attribute_key], [entity_key], [entity_type_key], [attribute_type_key], [attribute_value], [attribute_data_type_key], [attribute_display_format] 
FROM DevII.dbo.attribute WHERE entity_type_key = 4;

SET IDENTITY_INSERT Attribute OFF;

SELECT * FROM Attribute;


SET IDENTITY_INSERT CommentType ON;
INSERT INTO CommentType ([CommentTypeKey], [CommentTypeCategory], [CommentTypeCode], [CommentTypeName], [CommentTypeDescription])
SELECT [comment_type_key], [comment_type_category], [comment_type_code], [comment_type_name], [comment_type_desc] FROM DevII.dbo.comment_type;

SET IDENTITY_INSERT CommentType OFF;

SELECT * FROM CommentType

SELECT * FROM Comment
SELECT * FROM DevII.dbo.comment WHERE entity_type = 3;

SET IDENTITY_INSERT Comment ON;
INSERT INTO Comment ([CommentKey], [EntityKey], [EntityTypeKey], [CommentTypeKey], [CommentValue])
SELECT [comment_key], [entity_key], [entity_type], [comment_type_key], [comment_value] FROM DevII.dbo.comment --WHERE entity_type = 3;

SET IDENTITY_INSERT Comment OFF;

SET IDENTITY_INSERT ContactType ON;
INSERT INTO ContactType ([ContactTypeKey], [ContactTypeCategory], [ContactTypeCode], [ContactTypeName], [ContactTypeDescription])
SELECT [contact_type_key], [contact_type_category], [contact_type_code], [contact_type_name], [contact_type_desc] FROM DevII.dbo.Contact_type;

SET IDENTITY_INSERT ContactType OFF;

SELECT * FROM ContactType

SELECT * FROM Contact
SELECT * FROM DevII.dbo.Contact WHERE entity_type_key = 3;

SET IDENTITY_INSERT Contact ON;
INSERT INTO Contact ([ContactKey], [EntityKey], [EntityTypeKey], [ContactTypeKey], [ContactValue], [ContactDefault], [ContactActive])
SELECT [contact_key], [entity_key], [entity_type_key], [contact_type_key], [contact_value], [contact_default_flg], [contact_active_flg] FROM DevII.dbo.Contact;

SET IDENTITY_INSERT Contact OFF;

SELECT * FROM ProductType
SELECT * FROM DevII.dbo.product_type

SET IDENTITY_INSERT ProductType ON;
INSERT INTO ProductType ([ProductTypeKey], [ProductTypeCategory], [ProductTypeCode], [ProductTypeName], [ProductTypeDescription])
SELECT [product_type_key], [product_type_category], [product_type_code], [product_type_name], [product_type_desc] FROM DevII.dbo.product_type;

SET IDENTITY_INSERT ProductType OFF;


SET IDENTITY_INSERT Product ON;
INSERT INTO Product ([ProductKey], [ProductTypeKey], [ProductCode], [ProductName], [ProductDescription], [ProductName_short], [ProductName_long], [ProductImagePath])
SELECT [product_key], [product_type_key], [product_code], [product_name], [product_desc], [product_name_short], [product_name_long], [product_image_path] FROM DevII.dbo.product;

SET IDENTITY_INSERT Product OFF;


SELECT * FROM Product
SELECT * FROM DevII.dbo.product



SELECT * FROM FeeSchedule
SELECT * FROM DevII.dbo.fee_schedule --WHERE entity_type_key = 3;

SET IDENTITY_INSERT FeeSchedule ON;
INSERT INTO FeeSchedule ([FeeScheduleKey], [CompanyKey], [AccountKey], [ProductKey], [FeeScheduleStartDate], [FeeScheduleEndDate], [FeeScheduleType], [FeeScheduleValue])
SELECT [fee_schedule_key], [company_key], [account_key], [product_key], [fee_schedule_start_date], [fee_schedule_end_date], [fee_schedule_type], [fee_schedule_value] FROM DevII.dbo.fee_schedule;

SET IDENTITY_INSERT FeeSchedule OFF;


SET IDENTITY_INSERT PersonType ON;
INSERT INTO PersonType ([PersonTypeKey], [PersonTypeCategory], [PersonTypeCode], [PersonTypeName], [PersonTypeDescription])
SELECT [person_type_key], [person_type_category], [person_type_code], [person_type_name], [person_type_desc] FROM DevII.dbo.person_type;

SET IDENTITY_INSERT PersonType OFF;


SET IDENTITY_INSERT Person ON;
INSERT INTO Person ([PersonKey], [PersonCode], [PersonFirstName], [PersonMiddleInitial], [PersonLastName], [ParentPersonKey], [PersonDob])
SELECT [person_key], [person_code], [person_first_name], [person_mi], [person_last_name], [parent_person_key], [person_dob] FROM DevII.dbo.person;

SET IDENTITY_INSERT Person OFF;


/****************************************************************
*	INVOICE ONLY
****************************************************************/

SET IDENTITY_INSERT InvoiceStatus ON;
INSERT INTO InvoiceStatus ([InvoiceStatusKey], [InvoiceStatusCode], [InvoiceStatusName], [InvoiceStatusType], [InvoiceStatusDescription])
SELECT invoice_status_key, invoice_status_code, invoice_status_name, invoice_status_type, invoice_status_desc FROM DevII.dbo.invoice_status;

SET IDENTITY_INSERT InvoiceStatus OFF;
SELECT * FROM InvoiceStatus;


SET IDENTITY_INSERT Invoice ON;
INSERT INTO Invoice ([InvoiceKey], [FromEntityKey], [AccountKey], [AccountContactKey], [InvoiceNumber], [InvoiceEntryDate], [OrderEntryDate], [InvoiceStatusKey], 
	[InvoiceStatusDate], [OrderShipDate], [AccountRepKey], [SalesRepKey], [InvoiceCompleteDate], [InvoiceValueSum], [InvoiceItemCount])
SELECT [invoice_key], [from_entity_key], [account_key], [account_contact_key], [invoice_num], [invoice_entry_date], [order_entry_date], [invoice_status_key], 
	[invoice_status_date], [order_ship_date], [account_rep_key], [sales_rep_key], [invoice_complete_date], [invoice_value_sum], [invoice_item_count] FROM DevII.dbo.Invoice;

SET IDENTITY_INSERT Invoice OFF;
SELECT * FROM Invoice;



SET IDENTITY_INSERT InvoiceItem ON;
INSERT INTO InvoiceItem ([InvoiceItemKey], [InvoiceKey], [InvoiceItemSeq], [ProductKey], [ProductName], [ProductDescription], [InvoiceItemQuantity], 
	[ShipToAddressKey], [BillToAddressKey], [InvoiceItemEntryDate], [OrderItemShipDate], [InvoiceItemCompleteDate], [InvoiceItemPricePer], 
	[InvoiceItemLineSum], [InvoiceItemAccountRepKey], [InvoiceItemSalesRepKey], [InvoiceItemStatusKey], [OrderItemKey])
SELECT [invoice_item_key], [invoice_key], [invoice_item_seq], [product_key], [product_name], [product_desc], [invoice_item_quantity], 
	[shipto_addr_key], [billto_addr_key], [invoice_item_entry_date], [order_item_ship_date], [invoice_item_complete_date], [invoice_item_price_per], 
	[invoice_item_line_sum], [invoice_item_account_rep_key], [invoice_item_sales_rep_key], [invoice_item_status_key], [order_item_key] FROM DevII.dbo.invoice_item;

SET IDENTITY_INSERT InvoiceItem OFF;
SELECT * FROM InvoiceItem;



/****************************************************************
*	ORDER ONLY
****************************************************************/

SET IDENTITY_INSERT OrderStatus ON;
INSERT INTO OrderStatus ([OrderStatusKey], [OrderStatusCode], [OrderStatusName], [OrderStatusType], [OrderStatusDescription])
SELECT order_status_key, order_status_code, order_status_name, order_status_type, order_status_desc FROM DevII.dbo.order_status;

SET IDENTITY_INSERT OrderStatus OFF;
SELECT * FROM OrderStatus;


SET IDENTITY_INSERT OrderHeader ON;
INSERT INTO OrderHeader ([OrderKey], [AccountKey], [AccountContactKey], [OrderNumber], [OrderEntryDate], [OrderStatusKey], 
	[OrderStatusDate], [OrderShipDate], [AccountRepKey], [SalesRepKey], [OrderCompleteDate], [OrderValueSum], [OrderItemCount], [DeliverByDate])
SELECT [order_key], [account_key], [account_contact_key], [order_num], [order_entry_date], [order_status_key], 
	[order_status_date], [order_ship_date], [account_rep_key], [sales_rep_key], [order_complete_date], [order_value_sum], [order_item_count], deliver_by_date FROM DevII.dbo.order_header;

SET IDENTITY_INSERT OrderHeader OFF;
SELECT * FROM OrderHeader;
SELECT * FROM DevII.dbo.order_header


SET IDENTITY_INSERT OrderItem ON;
INSERT INTO OrderItem ([OrderItemKey], [OrderKey], [OrderItemSeq], [ProductKey], [ProductName], [ProductDescription], [OrderItemQuantity], 
	[ShipToAddressKey], [BillToAddressKey], [OrderItemShipDate], [OrderItemCompleteDate], [OrderItemPricePer], 
	[OrderItemLineSum], [OrderItemAccountRepKey], [OrderItemSalesRepKey], [OrderItemStatusKey])
SELECT [order_item_key], [order_key], [order_item_seq], [product_key], [product_name], [product_desc], [order_item_quantity], 
	[shipto_addr_key], [billto_addr_key], [order_item_ship_date], [order_item_complete_date], [order_item_price_per], 
	[order_item_line_sum], [order_item_acct_rep_key], [order_item_sales_rep_key], [order_item_status_key] FROM DevII.dbo.order_item;

SET IDENTITY_INSERT OrderItem OFF;
SELECT * FROM OrderItem;








