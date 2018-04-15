using QIQO.Business.Core.Contracts;

namespace QIQO.Accounts.Data
{
    public interface IAccountMap : IMapper<AccountData> { }
    public interface IAddressMap : IMapper<AddressData> { }
    public interface IAttributeMap : IMapper<AttributeData> { }
    public interface ICommentMap : IMapper<CommentData> { }
    public interface ICompanyMap : IMapper<CompanyData> { }
    public interface IContactMap : IMapper<ContactData> { }
    public interface IFeeScheduleMap : IMapper<FeeScheduleData> { }
    public interface IPersonMap : IMapper<PersonData> { }

}
