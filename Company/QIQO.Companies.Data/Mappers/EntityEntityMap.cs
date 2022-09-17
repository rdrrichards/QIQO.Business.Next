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
                    EntityEntityKey = NullCheck<int>(record["EntityEntityKey"]),
                    PrimaryEntityKey = NullCheck<int>(record["PrimaryEntityKey"]),
                    PrimaryEntityTypeKey = NullCheck<int>(record["PrimaryEntityTypeKey"]),
                    PrimaryEntityRoleKey = NullCheck<int>(record["PrimaryEntityRoleKey"]),
                    SecondaryEntityKey = NullCheck<int>(record["SecondaryEntityKey"]),
                    SecondaryEntityTypeKey = NullCheck<int>(record["SecondaryEntityTypeKey"]),
                    SecondaryEntityRoleKey = NullCheck<int>(record["SecondaryEntityRoleKey"]),
                    EntityEntitySeq = NullCheck<int>(record["EntityEntitySequence"]),
                    StartDate = NullCheck<DateTime>(record["StartDate"]),
                    EndDate = NullCheck<DateTime>(record["EndDate"]),
                    Comment = NullCheck<string>(record["Comment"]),
                    AuditAddUserId = NullCheck<string>(record["AuditAddUserId"]),
                    AuditAddDatetime = NullCheck<DateTime>(record["AuditAddDateTime"]),
                    AuditUpdateUserId = NullCheck<string>(record["AuditUpdateUserId"]),
                    AuditUpdateDatetime = NullCheck<DateTime>(record["AuditUpdateDateTime"])
                };
            }
            catch (Exception ex)
            {
                throw new MapException($"EntityEntityMap Exception occured: {ex.Message}", ex);
            }
        } // Map function closer

        public List<SqlParameter> MapParamsForUpsert(EntityEntityData entity) => new List<SqlParameter>
            {
                new SqlParameter("@EntityEntityKey", entity.EntityEntityKey),
                new SqlParameter("@PrimaryEntityKey", entity.PrimaryEntityKey),
                new SqlParameter("@PrimaryEntityTypeKey", entity.PrimaryEntityTypeKey),
                new SqlParameter("@PrimaryEntityRoleKey", entity.PrimaryEntityRoleKey),
                new SqlParameter("@SecondaryEntityKey", entity.SecondaryEntityKey),
                new SqlParameter("@SecondaryEntityTypeKey", entity.SecondaryEntityTypeKey),
                new SqlParameter("@SecondaryEntityRoleKey", entity.SecondaryEntityRoleKey),
                new SqlParameter("@EntityEntitySequence", entity.EntityEntitySeq),
                new SqlParameter("@StartDate", entity.StartDate),
                new SqlParameter("@EndDate", entity.EndDate),
                new SqlParameter("@Comment", entity.Comment),
                GetOutParam()
            };

        public List<SqlParameter> MapParamsForDelete(EntityEntityData entity) => MapParamsForDelete(entity.EntityEntityKey);

        public List<SqlParameter> MapParamsForDelete(int entity_entity_key) => new List<SqlParameter>
            {
                new SqlParameter("@EntityEntityKey", entity_entity_key),
                GetOutParam()
            };
    }
}
