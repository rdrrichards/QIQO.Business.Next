using QIQO.Business.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace QIQO.Orders.Data
{
    public class AddressMap : MapperBase, IAddressMap
    {
        public AddressData Map(IDataReader record)
        {
            try
            {
                return new AddressData()
                {
                    AddressKey = NullCheck<int>(record["AddressKey"]),
                    AddressTypeKey = NullCheck<int>(record["AddressTypeKey"]),
                    EntityKey = NullCheck<int>(record["EntityKey"]),
                    EntityTypeKey = NullCheck<int>(record["EntityTypeKey"]),
                    AddressLine1 = NullCheck<string>(record["AddressLine1"]),
                    AddressLine2 = NullCheck<string>(record["AddressLine2"]),
                    AddressLine3 = NullCheck<string>(record["AddressLine3"]),
                    AddressLine4 = NullCheck<string>(record["AddressLine4"]),
                    AddressCity = NullCheck<string>(record["AddressCity"]),
                    AddressStateProv = NullCheck<string>(record["AddressStateProv"]),
                    AddressCounty = NullCheck<string>(record["AddressCounty"]),
                    AddressCountry = NullCheck<string>(record["AddressCountry"]),
                    AddressPostalCode = NullCheck<string>(record["AddressPostalCode"]),
                    AddressNotes = NullCheck<string>(record["AddressNotes"]),
                    AddressDefaultFlg = NullCheck<int>(record["AddressDefaultFlag"]),
                    AddressActiveFlg = NullCheck<int>(record["AddressActiveFlag"]),
                    AuditAddUserId = NullCheck<string>(record["AuditAddUserId"]),
                    AuditAddDatetime = NullCheck<DateTime>(record["AuditAddDateTime"]),
                    AuditUpdateUserId = NullCheck<string>(record["AuditUpdateUserId"]),
                    AuditUpdateDatetime = NullCheck<DateTime>(record["AuditUpdateDateTime"])
                };

            }
            catch (Exception ex)
            {
                throw new MapException($"AddressMap Exception occured: {ex.Message}", ex);
            }
        } // Map function closer

        public List<SqlParameter> MapParamsForUpsert(AddressData entity) => new List<SqlParameter>
            {
                BuildParam("@AddressKey", entity.AddressKey),
                BuildParam("@AddressTypeKey", entity.AddressTypeKey),
                BuildParam("@EntityKey", entity.EntityKey),
                BuildParam("@EntityTypeKey", entity.EntityTypeKey),
                BuildParam("@AddressLine1", entity.AddressLine1),
                BuildParam("@AddressLine2", entity.AddressLine2),
                BuildParam("@AddressLine3", entity.AddressLine3),
                BuildParam("@AddressLine4", entity.AddressLine4),
                BuildParam("@AddressCity", entity.AddressCity),
                BuildParam("@AddressStateProv", entity.AddressStateProv),
                BuildParam("@AddressCounty", entity.AddressCounty),
                BuildParam("@AddressCountry", entity.AddressCountry),
                BuildParam("@AddressPostalCode", entity.AddressPostalCode),
                BuildParam("@AddressNotes", entity.AddressNotes),
                BuildParam("@AddressDefaultFlag", entity.AddressDefaultFlg),
                BuildParam("@AddressActiveFlag", entity.AddressActiveFlg),
                GetOutParam()
            };

        public List<SqlParameter> MapParamsForDelete(AddressData entity) => MapParamsForDelete(entity.AddressKey);

        public List<SqlParameter> MapParamsForDelete(int addressKey) => new List<SqlParameter>
            {
                BuildParam("@AddressKey", addressKey),
                GetOutParam()
            };
    }
}
