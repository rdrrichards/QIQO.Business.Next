
using QIQO.Companies.Data;
using QIQO.Companies.Domain;
using QIQO.Business.Core.Contracts;

namespace QIQO.Accounts.Manager
{
    public interface IAddressEntityService : IEntityService<Address, AddressData> { }
    public interface IAddressTypeEntityService : IEntityService<AddressType, AddressTypeData> { }
    public interface ICommentEntityService : IEntityService<Comment, CommentData> { }
    public interface ICommentTypeEntityService : IEntityService<CommentType, CommentTypeData> { }
    public interface ICompanyEntityService : IEntityService<Company, CompanyData> { }
    public interface IContactEntityService : IEntityService<Contact, ContactData> { }
    public interface IContactTypeEntityService : IEntityService<ContactType, ContactTypeData> { }
    public interface IAttributeEntityService : IEntityService<EntityAttribute, AttributeData> { }
    public interface IEntityTypeEntityService : IEntityService<EntityType, EntityTypeData> { }
    public interface IEntityRoleEntityService : IEntityService<EntityRole, EntityRoleData> { }
    public interface IFeeScheduleEntityService : IEntityService<FeeSchedule, FeeScheduleData> { }
    // public interface IEmployeeEntityService : IEntityService<Employee, PersonData> { }
}
