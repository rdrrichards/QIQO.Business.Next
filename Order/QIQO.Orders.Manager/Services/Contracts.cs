
using QIQO.Orders.Data;
using QIQO.Orders.Domain;
using QIQO.Business.Core.Contracts;

namespace QIQO.Orders.Manager
{
    public interface IAccountEntityService : IEntityService<Account, AccountData> { }
    public interface IAccountTypeEntityService : IEntityService<AccountType, AccountTypeData> { }
    public interface IAddressEntityService : IEntityService<Address, AddressData> { }
    public interface IAddressTypeEntityService : IEntityService<AddressType, AddressTypeData> { }
    public interface ICommentEntityService : IEntityService<Comment, CommentData> { }
    public interface ICommentTypeEntityService : IEntityService<CommentType, CommentTypeData> { }
    public interface IOrderEntityService : IEntityService<Order, OrderHeaderData> { }
    public interface IOrderItemEntityService : IEntityService<OrderItem, OrderItemData> { }
    //public interface IContactEntityService : IEntityService<Contact, ContactData> { }
    //public interface IContactTypeEntityService : IEntityService<ContactType, ContactTypeData> { }
    //public interface IAttributeEntityService : IEntityService<EntityAttribute, AttributeData> { }
    public interface IEntityTypeEntityService : IEntityService<EntityType, EntityTypeData> { }
    public interface IEntityRoleEntityService : IEntityService<EntityRole, EntityRoleData> { }
    public interface IFeeScheduleEntityService : IEntityService<FeeSchedule, FeeScheduleData> { }
    //public interface IAccountPersonEntityService : IEntityService<AccountPerson, PersonData> { }
    // public interface IEmployeeEntityService : IEntityService<Employee, PersonData> { }
}
