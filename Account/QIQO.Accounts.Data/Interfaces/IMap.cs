using QIQO.Business.Core.Contracts;

namespace QIQO.Accounts.Data
{
    public interface IAccountMap : IMapper<AccountData> { }
    public interface IAccountTypeMap : IMapper<AccountTypeData> { }
    public interface IAddressMap : IMapper<AddressData> { }
    public interface IAddressPostalMap : IMapper<AddressPostalData> { }
    public interface IAddressTypeMap : IMapper<AddressTypeData> { }
    public interface IAttributeMap : IMapper<AttributeData> { }
    public interface IAttributeTypeMap : IMapper<AttributeTypeData> { }
    public interface IAuditLogMap : IMapper<AuditLogData> { }
    public interface ICommentMap : IMapper<CommentData> { }
    public interface ICommentTypeMap : IMapper<CommentTypeData> { }
    public interface ICompanyMap : IMapper<CompanyData> { }
    public interface IContactMap : IMapper<ContactData> { }
    public interface IContactTypeMap : IMapper<ContactTypeData> { }
    public interface IEntityEntityMap : IMapper<EntityEntityData> { }
    public interface IFeeScheduleMap : IMapper<FeeScheduleData> { }
    public interface IPersonMap : IMapper<PersonData> { }
    public interface IPersonTypeMap : IMapper<PersonTypeData> { }
    public interface IProductMap : IMapper<ProductData> { }
    public interface IProductTypeMap : IMapper<ProductTypeData> { }

}
