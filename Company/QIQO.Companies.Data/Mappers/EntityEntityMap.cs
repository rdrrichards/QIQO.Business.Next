using QIQO.Business.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace QIQO.Companies.Data
{
    public class EntityEntityMap : MapperBase, IEntityEntityMap
    {
        public EntityEntityData Map(IDataReader record)
        {
            try
            {
                return new EntityEntityData()
                {
                    EntityEntityKey = NullCheck<int>(record["entity_entity_key"]),
                    PrimaryEntityKey = NullCheck<int>(record["primary_entity_key"]),
                    PrimaryEntityTypeKey = NullCheck<int>(record["primary_entity_type_key"]),
                    PrimaryEntityRoleKey = NullCheck<int>(record["primary_entity_role_key"]),
                    SecondaryEntityKey = NullCheck<int>(record["secondary_entity_key"]),
                    SecondaryEntityTypeKey = NullCheck<int>(record["secondary_entity_type_key"]),
                    SecondaryEntityRoleKey = NullCheck<int>(record["secondary_entity_role_key"]),
                    EntityEntitySeq = NullCheck<int>(record["entity_entity_seq"]),
                    StartDate = NullCheck<DateTime>(record["start_date"]),
                    EndDate = NullCheck<DateTime>(record["end_date"]),
                    Comment = NullCheck<string>(record["comment"]),
                    AuditAddUserId = NullCheck<string>(record["audit_add_user_id"]),
                    AuditAddDatetime = NullCheck<DateTime>(record["audit_add_datetime"]),
                    AuditUpdateUserId = NullCheck<string>(record["audit_update_user_id"]),
                    AuditUpdateDatetime = NullCheck<DateTime>(record["audit_update_datetime"])
                };
            }
            catch (Exception ex)
            {
                throw new MapException($"EntityEntityMap Exception occured: {ex.Message}", ex);
            }
        } // Map function closer

        public List<SqlParameter> MapParamsForUpsert(EntityEntityData entity) => new List<SqlParameter>
            {
                new SqlParameter("@entity_entity_key", entity.EntityEntityKey),
                new SqlParameter("@primary_entity_key", entity.PrimaryEntityKey),
                new SqlParameter("@primary_entity_type_key", entity.PrimaryEntityTypeKey),
                new SqlParameter("@primary_entity_role_key", entity.PrimaryEntityRoleKey),
                new SqlParameter("@secondary_entity_key", entity.SecondaryEntityKey),
                new SqlParameter("@secondary_entity_type_key", entity.SecondaryEntityTypeKey),
                new SqlParameter("@secondary_entity_role_key", entity.SecondaryEntityRoleKey),
                new SqlParameter("@entity_entity_seq", entity.EntityEntitySeq),
                new SqlParameter("@start_date", entity.StartDate),
                new SqlParameter("@end_date", entity.EndDate),
                new SqlParameter("@comment", entity.Comment),
                GetOutParam()
            };

        public List<SqlParameter> MapParamsForDelete(EntityEntityData entity) => MapParamsForDelete(entity.EntityEntityKey);

        public List<SqlParameter> MapParamsForDelete(int entity_entity_key) => new List<SqlParameter>
            {
                new SqlParameter("@entity_entity_key", entity_entity_key),
                GetOutParam()
            };
    }
}
