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
                    AddressTypeKey = NullCheck<int>(record["address_type_key"]),
                    AddressTypeCode = NullCheck<string>(record["address_type_code"]),
                    AddressTypeName = NullCheck<string>(record["address_type_name"]),
                    AddressTypeDesc = NullCheck<string>(record["address_type_desc"]),
                    AuditAddUserId = NullCheck<string>(record["audit_add_user_id"]),
                    AuditAddDatetime = NullCheck<DateTime>(record["audit_add_datetime"]),
                    AuditUpdateUserId = NullCheck<string>(record["audit_update_user_id"]),
                    AuditUpdateDatetime = NullCheck<DateTime>(record["audit_update_datetime"])
                };
            }
            catch (Exception ex)
            {
                throw new MapException($"AccountMap Exception occured: {ex.Message}", ex);
            }
        }

        public List<SqlParameter> MapParamsForUpsert(AddressTypeData entity) => new List<SqlParameter>
            {
                BuildParam("@address_type_key", entity.AddressTypeKey),
                BuildParam("@address_type_code", entity.AddressTypeCode),
                BuildParam("@address_type_name", entity.AddressTypeName),
                BuildParam("@address_type_desc", entity.AddressTypeDesc),
                GetOutParam()
            };

        public List<SqlParameter> MapParamsForDelete(AddressTypeData entity) => MapParamsForDelete(entity.AddressTypeKey);

        public List<SqlParameter> MapParamsForDelete(int addressTypeKey) => new List<SqlParameter>
            {
                BuildParam("@address_type_key", addressTypeKey),
                GetOutParam()
            };
    }
}
