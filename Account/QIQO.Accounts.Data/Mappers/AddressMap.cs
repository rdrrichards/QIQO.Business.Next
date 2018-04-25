using QIQO.Business.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace QIQO.Accounts.Data
{
    public class AddressMap : MapperBase, IAddressMap
    {
        public AddressData Map(IDataReader record)
        {
            try
            {
                return new AddressData()
                {
                    AddressKey = NullCheck<int>(record["address_key"]),
                    AddressTypeKey = NullCheck<int>(record["address_type_key"]),
                    EntityKey = NullCheck<int>(record["entity_key"]),
                    EntityTypeKey = NullCheck<int>(record["entity_type_key"]),
                    AddressLine1 = NullCheck<string>(record["address_line_1"]),
                    AddressLine2 = NullCheck<string>(record["address_line_2"]),
                    AddressLine3 = NullCheck<string>(record["address_line_3"]),
                    AddressLine4 = NullCheck<string>(record["address_line_4"]),
                    AddressCity = NullCheck<string>(record["address_city"]),
                    AddressStateProv = NullCheck<string>(record["address_state_prov"]),
                    AddressCounty = NullCheck<string>(record["address_county"]),
                    AddressCountry = NullCheck<string>(record["address_country"]),
                    AddressPostalCode = NullCheck<string>(record["address_postal_code"]),
                    AddressNotes = NullCheck<string>(record["address_notes"]),
                    AddressDefaultFlg = NullCheck<int>(record["address_default_flg"]),
                    AddressActiveFlg = NullCheck<int>(record["address_active_flg"]),
                    AuditAddUserId = NullCheck<string>(record["audit_add_user_id"]),
                    AuditAddDatetime = NullCheck<DateTime>(record["audit_add_datetime"]),
                    AuditUpdateUserId = NullCheck<string>(record["audit_update_user_id"]),
                    AuditUpdateDatetime = NullCheck<DateTime>(record["audit_update_datetime"])
                };

            }
            catch (Exception ex)
            {
                throw new MapException($"AddressMap Exception occured: {ex.Message}", ex);
            }
        } // Map function closer

        public List<SqlParameter> MapParamsForUpsert(AddressData entity) => new List<SqlParameter>
            {
                BuildParam("@address_key", entity.AddressKey),
                BuildParam("@address_type_key", entity.AddressTypeKey),
                BuildParam("@entity_key", entity.EntityKey),
                BuildParam("@entity_type_key", entity.EntityTypeKey),
                BuildParam("@address_line_1", entity.AddressLine1),
                BuildParam("@address_line_2", entity.AddressLine2),
                BuildParam("@address_line_3", entity.AddressLine3),
                BuildParam("@address_line_4", entity.AddressLine4),
                BuildParam("@address_city", entity.AddressCity),
                BuildParam("@address_state_prov", entity.AddressStateProv),
                BuildParam("@address_county", entity.AddressCounty),
                BuildParam("@address_country", entity.AddressCountry),
                BuildParam("@address_postal_code", entity.AddressPostalCode),
                BuildParam("@address_notes", entity.AddressNotes),
                BuildParam("@address_default_flg", entity.AddressDefaultFlg),
                BuildParam("@address_active_flg", entity.AddressActiveFlg),
                GetOutParam()
            };

        public List<SqlParameter> MapParamsForDelete(AddressData entity) => MapParamsForDelete(entity.AddressKey);

        public List<SqlParameter> MapParamsForDelete(int addressKey) => new List<SqlParameter>
            {
                BuildParam("@address_key", addressKey),
                GetOutParam()
            };
    }
}
