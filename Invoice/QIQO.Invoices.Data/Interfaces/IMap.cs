using QIQO.Business.Core.Contracts;

namespace QIQO.Invoices.Data
{
    public interface IAccountMap : IMapper<AccountData> { }
    public interface IAccountTypeMap : IMapper<AccountTypeData> { }
    public interface IAddressMap : IMapper<AddressData> { }
    public interface IAddressPostalMap : IMapper<AddressPostalData> { }
    public interface IAddressTypeMap : IMapper<AddressTypeData> { }
    public interface IAuditLogMap : IMapper<AuditLogData> { }
    public interface ICommentMap : IMapper<CommentData> { }
    public interface ICommentTypeMap : IMapper<CommentTypeData> { }
    public interface IEntityEntityMap : IMapper<EntityEntityData> { }
    public interface IFeeScheduleMap : IMapper<FeeScheduleData> { }
    public interface IPersonMap : IMapper<PersonData> { }
    public interface IPersonTypeMap : IMapper<PersonTypeData> { }
    public interface IInvoiceItemMap : IMapper<InvoiceItemData> { }
    public interface IInvoiceMap : IMapper<InvoiceData> { }
    public interface IInvoiceStatusMap : IMapper<InvoiceStatusData> { }
}
