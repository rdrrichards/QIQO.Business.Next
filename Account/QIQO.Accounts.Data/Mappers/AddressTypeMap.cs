using QIQO.Business.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace QIQO.Accounts.Data
{
    public class AddressTypeMap : MapperBase, IAddressTypeMap
    {
        public AddressTypeData Map(IDataReader record)
        {
            try
            {
                return new AddressTypeData()
                {
                    AddressTypeKey = NullCheck<int>(record["AddressTypeKey"]),
                    AddressTypeCode = NullCheck<string>(record["AddressTypeCode"]),
                    AddressTypeName = NullCheck<string>(record["AddressTypeName"]),
                    AddressTypeDesc = NullCheck<string>(record["AddressTypeDescription"]),
                    AuditAddUserId = NullCheck<string>(record["AuditAddUserId"]),
                    AuditAddDatetime = NullCheck<DateTime>(record["AuditAddDateTime"]),
                    AuditUpdateUserId = NullCheck<string>(record["AuditUpdateUserId"]),
                    AuditUpdateDatetime = NullCheck<DateTime>(record["AuditUpdateDateTime"])
                };
            }
            catch (Exception ex)
            {
                throw new MapException($"AccountMap Exception occured: {ex.Message}", ex);
            }
        }

        public List<SqlParameter> MapParamsForUpsert(AddressTypeData entity) => new List<SqlParameter>
            {
                BuildParam("@AddressTypeKey", entity.AddressTypeKey),
                BuildParam("@AddressTypeCode", entity.AddressTypeCode),
                BuildParam("@AddressTypeName", entity.AddressTypeName),
                BuildParam("@AddressTypeDescription", entity.AddressTypeDesc),
                GetOutParam()
            };

        public List<SqlParameter> MapParamsForDelete(AddressTypeData entity) => MapParamsForDelete(entity.AddressTypeKey);

        public List<SqlParameter> MapParamsForDelete(int addressTypeKey) => new List<SqlParameter>
            {
                BuildParam("@AddressTypeKey", addressTypeKey),
                GetOutParam()
            };
    }
}
