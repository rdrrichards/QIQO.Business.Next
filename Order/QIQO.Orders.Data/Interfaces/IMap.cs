using QIQO.Business.Core.Contracts;

namespace QIQO.Orders.Data
{
    public interface IAccountMap : IMapper<AccountData> { }
    public interface IAddressMap : IMapper<AddressData> { }
    public interface ICommentMap : IMapper<CommentData> { }
    public interface IFeeScheduleMap : IMapper<FeeScheduleData> { }
    public interface IPersonMap : IMapper<PersonData> { }
    public interface IOrderHeaderMap : IMapper<OrderHeaderData> { }
    public interface IOrderItemMap : IMapper<OrderItemData> { }
    public interface IOrderStatusMap : IMapper<OrderStatusData> { }
}
