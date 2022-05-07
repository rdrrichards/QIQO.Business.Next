using QIQO.Accounts.Data;
using QIQO.Accounts.Domain;
using Xunit;

namespace QIQO.Accounts.Tests
{
    public class AccountDomainUnitTests
    {
        [Fact]
        public void AccountModelTest1()
        {
            var data = new AccountData {
                AccountKey = 1,
                AccountCode = "TEST",
                AccountName = "TEST",
                AccountDesc = "TEST",
                AccountDba = "TEST",
                CompanyKey = 1,
                AccountStartDate = new System.DateTime(2018, 1, 1),
                AccountEndDate = new System.DateTime(2019, 1, 1),
                AccountTypeKey = 1,
                AuditAddDatetime = new System.DateTime(2018, 1, 1),
                AuditAddUserId = "TEST",
                AuditUpdateDatetime = new System.DateTime(2018, 1, 1),
                AuditUpdateUserId = "TEST"
            };
            var sut = new Account(data);
            Assert.True(sut.AccountKey == 1);
            Assert.True(sut.CompanyKey == 1);
            Assert.True(sut.AccountType == QIQOAccountType.Individual);
            Assert.True(sut.AccountCode == "TEST");
            Assert.True(sut.AccountName == "TEST");
            Assert.True(sut.AccountDesc == "TEST");
            Assert.True(sut.AccountDba == "TEST");
            Assert.True(sut.AddedUserID == "TEST");
            Assert.True(sut.UpdateUserID == "TEST");
            Assert.True(sut.AccountStartDate == new System.DateTime(2018, 1, 1));
            Assert.True(sut.AccountEndDate == new System.DateTime(2019, 1, 1));
            Assert.True(sut.AddedDateTime == new System.DateTime(2018, 1, 1));
            Assert.True(sut.UpdateDateTime == new System.DateTime(2018, 1, 1));

            Assert.True(sut.Comments.Count == 0);
            Assert.True(sut.Contacts.Count == 0);
            Assert.True(sut.Addresses.Count == 0);
            Assert.True(sut.FeeSchedules.Count == 0);
            Assert.True(sut.Employees.Count == 0);
            Assert.True(sut.AccountAttributes.Count == 0);
        }

        [Fact]
        public void AccountModelTest2()
        {
            var sut = new Account(1, QIQOAccountType.Individual, "TEST", "TEST", "TEST", "TEST",
                new System.DateTime(2018, 1, 1), new System.DateTime(2019, 1, 1));
            Assert.True(sut.AccountKey == 0);
            Assert.True(sut.CompanyKey == 1);
            Assert.True(sut.AccountType == QIQOAccountType.Individual);
            Assert.True(sut.AccountCode == "TEST");
            Assert.True(sut.AccountName == "TEST");
            Assert.True(sut.AccountDesc == "TEST");
            Assert.True(sut.AccountDba == "TEST");
            Assert.True(sut.AddedUserID == null);
            Assert.True(sut.UpdateUserID == null);
            Assert.True(sut.AccountStartDate == new System.DateTime(2018, 1, 1));
            Assert.True(sut.AccountEndDate == new System.DateTime(2019, 1, 1));
            //Assert.True(sut.AddedDateTime != null);
            //Assert.True(sut.UpdateDateTime != null);

            Assert.True(sut.Comments.Count == 0);
            Assert.True(sut.Contacts.Count == 0);
            Assert.True(sut.Addresses.Count == 0);
            Assert.True(sut.FeeSchedules.Count == 0);
            Assert.True(sut.Employees.Count == 0);
            Assert.True(sut.AccountAttributes.Count == 0);
        }

        [Fact]
        public void AccountModelTest3()
        {
            var sut = new Account(1, QIQOAccountType.Individual, "TEST", "TEST", "TEST", "TEST",
                new System.DateTime(2018, 1, 1), null);
            Assert.True(sut.AccountKey == 0);
            Assert.True(sut.CompanyKey == 1);
            Assert.True(sut.AccountType == QIQOAccountType.Individual);
            Assert.True(sut.AccountCode == "TEST");
            Assert.True(sut.AccountName == "TEST");
            Assert.True(sut.AccountDesc == "TEST");
            Assert.True(sut.AccountDba == "TEST");
            Assert.True(sut.AddedUserID == null);
            Assert.True(sut.UpdateUserID == null);
            Assert.True(sut.AccountStartDate == new System.DateTime(2018, 1, 1));
            Assert.True(sut.AccountEndDate.Year == System.DateTime.Now.AddYears(99).Year);
            //Assert.True(sut.AddedDateTime != null);
            //Assert.True(sut.UpdateDateTime != null);

            Assert.True(sut.Comments.Count == 0);
            Assert.True(sut.Contacts.Count == 0);
            Assert.True(sut.Addresses.Count == 0);
            Assert.True(sut.FeeSchedules.Count == 0);
            Assert.True(sut.Employees.Count == 0);
            Assert.True(sut.AccountAttributes.Count == 0);
        }

        [Fact]
        public void AccountTypeModelTest1()
        {
            var data = new AccountTypeData
            {
                AccountTypeKey = 1,
                AccountTypeCode = "TEST",
                AccountTypeName = "TEST",
                AccountTypeDesc = "TEST",
                AuditAddUserId = "TEST",
                AuditAddDatetime = new System.DateTime(2018, 1, 1),
                AuditUpdateUserId = "TEST",
                AuditUpdateDatetime = new System.DateTime(2018, 1, 1),
            };
            var sut = new AccountType(data);

            Assert.True(sut.AccountTypeKey == 1);
            Assert.True(sut.AccountTypeCode == "TEST");
            Assert.True(sut.AccountTypeName == "TEST");
            Assert.True(sut.AccountTypeDesc == "TEST");
        }
        [Fact]
        public void AddressModelTest1()
        {
            var data = new AddressData
            {
                AddressKey = 1,
                AddressTypeKey = 1,
                EntityKey = 1,
                EntityTypeKey = 3,
                AddressLine1 = "TEST",
                AddressLine2 = "TEST",
                AddressLine3 = "TEST",
                AddressLine4 = "TEST",
                AddressCity = "TEST",
                AddressStateProv = "TEST",
                AddressCounty = "TEST",
                AddressCountry = "TEST",
                AddressPostalCode = "TEST",
                AddressNotes = "TEST",
                AddressDefaultFlg = 1,
                AddressActiveFlg = 1,
                AuditAddUserId = "TEST",
                AuditAddDatetime = new System.DateTime(2018, 1, 1),
                AuditUpdateUserId = "TEST",
                AuditUpdateDatetime = new System.DateTime(2018, 1, 1),
            };
            var sut = new Address(data);

            Assert.True(sut.AddressKey == 1);
            Assert.True(sut.AddressType == QIQOAccountAddressType.Mailing);
            Assert.True(sut.EntityKey == 1);
            Assert.True(sut.EntityType == QIQOAccountEntityType.Account);
            Assert.True(sut.AddressLine1 == "TEST");
            Assert.True(sut.AddressLine2 == "TEST");
            Assert.True(sut.AddressLine3 == "TEST");
            Assert.True(sut.AddressLine4 == "TEST");
            Assert.True(sut.AddressCity == "TEST");
            Assert.True(sut.AddressState == "TEST");
            Assert.True(sut.AddressCounty == "TEST");
            Assert.True(sut.AddressCountry == "TEST");
            Assert.True(sut.AddressPostalCode == "TEST");
            Assert.True(sut.AddressNotes == "TEST");
            Assert.True(sut.AddressDefaultFlag == true);
            Assert.True(sut.AddressActiveFlag == true);
        }
        [Fact]
        public void AddressPostalModelTest1()
        {
            var data = new AddressPostalData
            {
                Country = "TEST",
                PostalCode = "TEST",
                StateCode = "TEST",
                StateFullName = "TEST",
                CityName = "TEST",
                CountyName = "TEST",
                TimeZone = 1,
            };
            //var sut = new AddressPostal(data);

            //Assert.True(sut.Country == "TEST");
            //Assert.True(sut.PostalCode == "TEST");
            //Assert.True(sut.StateCode == "TEST");
            //Assert.True(sut.StateFullName == "TEST");
            //Assert.True(sut.CityName == "TEST");
            //Assert.True(sut.CountyName == "TEST");
            //Assert.True(sut.TimeZone == 1);
        }
        [Fact]
        public void AddressTypeModelTest1()
        {
            var data = new AddressTypeData
            {
                AddressTypeKey = 1,
                AddressTypeCode = "TEST",
                AddressTypeName = "TEST",
                AddressTypeDesc = "TEST",
                AuditAddUserId = "TEST",
                AuditAddDatetime = new System.DateTime(2018, 1, 1),
                AuditUpdateUserId = "TEST",
                AuditUpdateDatetime = new System.DateTime(2018, 1, 1),
            };
            var sut = new AddressType(data);

            Assert.True(sut.AddressTypeKey == 1);
            Assert.True(sut.AddressTypeCode == "TEST");
            Assert.True(sut.AddressTypeName == "TEST");
            Assert.True(sut.AddressTypeDesc == "TEST");
        }
        [Fact]
        public void AttributeModelTest1()
        {
            var data = new AttributeData
            {
                AttributeKey = 1,
                EntityKey = 1,
                EntityTypeKey = 1,
                AttributeTypeKey = 1,
                AttributeValue = "TEST",
                AttributeDataTypeKey = 1,
                AttributeDisplayFormat = "TEST",
                AuditAddUserId = "TEST",
                AuditAddDatetime = new System.DateTime(2018, 1, 1),
                AuditUpdateUserId = "TEST",
                AuditUpdateDatetime = new System.DateTime(2018, 1, 1),
            };
            var sut = new EntityAttribute(data);

            Assert.True(sut.AttributeKey == 1);
            Assert.True(sut.EntityKey == 1);
            Assert.True(sut.EntityType == QIQOAccountEntityType.Company);
            // Assert.True(sut.AttributeTypeKey == 1);
            Assert.True(sut.AttributeValue == "TEST");
            Assert.True(sut.AttributeDataTypeKey == 1);
            Assert.True(sut.AttributeDisplayFormat == "TEST");
        }

        [Fact]
        public void CommentModelTest1()
        {
            var data = new CommentData
            {
                CommentKey = 1,
                EntityKey = 1,
                EntityType = 1,
                CommentTypeKey = 1,
                CommentValue = "TEST",
                AuditAddUserId = "TEST",
                AuditAddDatetime = new System.DateTime(2018, 1, 1),
                AuditUpdateUserId = "TEST",
                AuditUpdateDatetime = new System.DateTime(2018, 1, 1),
            };
            var sut = new Comment(data);

            Assert.True(sut.CommentKey == 1);
            Assert.True(sut.EntityKey == 1);
            Assert.True(sut.EntityTypeKey == 1);
            Assert.True(sut.CommentType == QIQOCommentType.Public);
            Assert.True(sut.CommentValue == "TEST");
        }
        [Fact]
        public void CommentTypeModelTest1()
        {
            var data = new CommentTypeData
            {
                CommentTypeKey = 1,
                CommentTypeCategory = "TEST",
                CommentTypeCode = "TEST",
                CommentTypeName = "TEST",
                CommentTypeDesc = "TEST",
                AuditAddUserId = "TEST",
                AuditAddDatetime = new System.DateTime(2018, 1, 1),
                AuditUpdateUserId = "TEST",
                AuditUpdateDatetime = new System.DateTime(2018, 1, 1),
            };
            var sut = new CommentType(data);

            Assert.True(sut.CommentTypeKey == 1);
            // Assert.True(sut.CommentTypeCategory == "TEST");
            Assert.True(sut.CommentTypeCode == "TEST");
            Assert.True(sut.CommentTypeName == "TEST");
            Assert.True(sut.CommentTypeDesc == "TEST");
        }
        [Fact]
        public void CompanyModelTest1()
        {
            var data = new CompanyData
            {
                CompanyKey = 1,
                CompanyCode = "TEST",
                CompanyName = "TEST",
                CompanyDesc = "TEST",
                AuditAddUserId = "TEST",
                AuditAddDatetime = new System.DateTime(2018, 1, 1),
                AuditUpdateUserId = "TEST",
                AuditUpdateDatetime = new System.DateTime(2018, 1, 1),
            };
            var sut = new Company(data);

            Assert.True(sut.CompanyKey == 1);
            Assert.True(sut.CompanyCode == "TEST");
            Assert.True(sut.CompanyName == "TEST");
            Assert.True(sut.CompanyDesc == "TEST");
        }
        [Fact]
        public void ContactModelTest1()
        {
            var data = new ContactData
            {
                ContactKey = 1,
                EntityKey = 1,
                EntityTypeKey = 1,
                ContactTypeKey = 1,
                ContactValue = "TEST",
                ContactDefaultFlg = 1,
                ContactActiveFlg = 1,
                AuditAddUserId = "TEST",
                AuditAddDatetime = new System.DateTime(2018, 1, 1),
                AuditUpdateUserId = "TEST",
                AuditUpdateDatetime = new System.DateTime(2018, 1, 1),
            };
            var sut = new Contact(data);

            Assert.True(sut.ContactKey == 1);
            Assert.True(sut.EntityKey == 1);
            Assert.True(sut.EntityTypeKey == 1);
            Assert.True(sut.ContactTypeKey == 1);
            Assert.True(sut.ContactValue == "TEST");
            Assert.True(sut.ContactDefaultFlg == 1);
            Assert.True(sut.ContactActiveFlg == 1);
        }
        [Fact]
        public void ContactTypeModelTest1()
        {
            var data = new ContactTypeData
            {
                ContactTypeKey = 1,
                ContactTypeCategory = "TEST",
                ContactTypeCode = "TEST",
                ContactTypeName = "TEST",
                ContactTypeDesc = "TEST",
                AuditAddUserId = "TEST",
                AuditAddDatetime = new System.DateTime(2018, 1, 1),
                AuditUpdateUserId = "TEST",
                AuditUpdateDatetime = new System.DateTime(2018, 1, 1),
            };
            var sut = new ContactType(data);

            Assert.True(sut.ContactTypeKey == 1);
            //Assert.True(sut.ContactTypeCategory == "TEST");
            Assert.True(sut.ContactTypeCode == "TEST");
            Assert.True(sut.ContactTypeName == "TEST");
            Assert.True(sut.ContactTypeDesc == "TEST");
        }
        [Fact]
        public void EntityRoleModelTest1()
        {
            var data = new EntityRoleData
            {
                EntityRoleKey = 1,
                EntityRoleCode = "TEST",
                EntityRoleName = "TEST",
                EntityRoleDesc = "TEST",
                AuditAddUserId = "TEST",
                AuditAddDatetime = new System.DateTime(2018, 1, 1),
                AuditUpdateUserId = "TEST",
                AuditUpdateDatetime = new System.DateTime(2018, 1, 1),
            };
            var sut = new EntityRole(data);

            Assert.True(sut.EntityRoleKey == 1);
            Assert.True(sut.EntityRoleCode == "TEST");
            Assert.True(sut.EntityRoleName == "TEST");
            Assert.True(sut.EntityRoleDesc == "TEST");
        }
        [Fact]
        public void EntityTypeModelTest1()
        {
            var data = new EntityTypeData
            {
                EntityTypeKey = 1,
                EntityTypeCode = "TEST",
                EntityTypeName = "TEST",
                AuditAddUserId = "TEST",
                AuditAddDatetime = new System.DateTime(2018, 1, 1),
                AuditUpdateUserId = "TEST",
                AuditUpdateDatetime = new System.DateTime(2018, 1, 1),
            };
            var sut = new EntityType(data);

            Assert.True(sut.EntityTypeKey == 1);
            Assert.True(sut.EntityTypeCode == "TEST");
            Assert.True(sut.EntityTypeName == "TEST");
        }
        [Fact]
        public void FeeScheduleModelTest1()
        {
            var data = new FeeScheduleData
            {
                FeeScheduleKey = 1,
                CompanyKey = 1,
                AccountKey = 1,
                ProductKey = 1,
                FeeScheduleStartDate = new System.DateTime(2018, 1, 1),
                FeeScheduleEndDate = new System.DateTime(2018, 1, 1),
                FeeScheduleType = "TEST",
                FeeScheduleValue = 1,
                AuditAddUserId = "TEST",
                AuditAddDatetime = new System.DateTime(2018, 1, 1),
                AuditUpdateUserId = "TEST",
                AuditUpdateDatetime = new System.DateTime(2018, 1, 1),
            };
            var sut = new FeeSchedule(data);

            Assert.True(sut.FeeScheduleKey == 1);
            Assert.True(sut.CompanyKey == 1);
            Assert.True(sut.AccountKey == 1);
            Assert.True(sut.ProductKey == 1);
            Assert.True(sut.FeeScheduleStartDate == new System.DateTime(2018, 1, 1));
            Assert.True(sut.FeeScheduleEndDate == new System.DateTime(2018, 1, 1));
            Assert.True(sut.FeeScheduleTypeCode == "TEST");
            Assert.True(sut.FeeScheduleValue == 1);
        }
        [Fact]
        public void PersonModelTest1()
        {
            var data = new PersonData
            {
                PersonKey = 1,
                PersonCode = "TEST",
                PersonFirstName = "TEST",
                PersonMi = "TEST",
                PersonLastName = "TEST",
                ParentPersonKey = 1,
                PersonDob = new System.DateTime(2018, 1, 1),
                AuditAddUserId = "TEST",
                AuditAddDatetime = new System.DateTime(2018, 1, 1),
                AuditUpdateUserId = "TEST",
                AuditUpdateDatetime = new System.DateTime(2018, 1, 1),
            };
            var sut = new AccountPerson(data);

            Assert.True(sut.PersonKey == 1);
            Assert.True(sut.PersonCode == "TEST");
            Assert.True(sut.PersonFirstName == "TEST");
            Assert.True(sut.PersonMi == "TEST");
            Assert.True(sut.PersonLastName == "TEST");
            //Assert.True(sut.ParentPersonKey == 1);
            Assert.True(sut.PersonDob == new System.DateTime(2018, 1, 1));
        }
        [Fact]
        public void ProductModelTest1()
        {
            var data = new ProductData
            {
                ProductKey = 1,
                ProductTypeKey = 1,
                ProductCode = "TEST",
                ProductName = "TEST",
                ProductDesc = "TEST",
                ProductNameShort = "TEST",
                ProductNameLong = "TEST",
                ProductImagePath = "TEST",
                AuditAddUserId = "TEST",
                AuditAddDatetime = new System.DateTime(2018, 1, 1),
                AuditUpdateUserId = "TEST",
                AuditUpdateDatetime = new System.DateTime(2018, 1, 1),
            };
            //var sut = new Product(data);

            //Assert.True(sut.ProductKey == 1);
            //Assert.True(sut.ProductTypeKey == 1);
            //Assert.True(sut.ProductCode == "TEST");
            //Assert.True(sut.ProductName == "TEST");
            //Assert.True(sut.ProductDesc == "TEST");
            //Assert.True(sut.ProductNameShort == "TEST");
            //Assert.True(sut.ProductNameLong == "TEST");
            //Assert.True(sut.ProductImagePath == "TEST");
        }
        [Fact]
        public void ProductTypeModelTest1()
        {
            var data = new ProductTypeData
            {
                ProductTypeKey = 1,
                ProductTypeCategory = "TEST",
                ProductTypeCode = "TEST",
                ProductTypeName = "TEST",
                ProductTypeDesc = "TEST",
                AuditAddUserId = "TEST",
                AuditAddDatetime = new System.DateTime(2018, 1, 1),
                AuditUpdateUserId = "TEST",
                AuditUpdateDatetime = new System.DateTime(2018, 1, 1),
            };
            //var sut = new ProductType(data);

            //Assert.True(sut.ProductTypeKey == 1);
            //Assert.True(sut.ProductTypeCategory == "TEST");
            //Assert.True(sut.ProductTypeCode == "TEST");
            //Assert.True(sut.ProductTypeName == "TEST");
            //Assert.True(sut.ProductTypeDesc == "TEST");
        }
    }
}
