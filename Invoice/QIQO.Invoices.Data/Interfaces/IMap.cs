using QIQO.Business.Core.Contracts;

namespace QIQO.Invoices.Data
{
    public interface IAccountMap : IMapper<AccountData> { }
    public interface IAddressMap : IMapper<AddressData> { }
    public interface ICommentMap : IMapper<CommentData> { }
    public interface IFeeScheduleMap : IMapper<FeeScheduleData> { }
    public interface IPersonMap : IMapper<PersonData> { }
    public interface IInvoiceItemMap : IMapper<InvoiceItemData> { }
    public interface IInvoiceMap : IMapper<InvoiceData> { }
    public interface IInvoiceStatusMap : IMapper<InvoiceStatusData> { }
}
