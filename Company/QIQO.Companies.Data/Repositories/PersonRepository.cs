﻿using Microsoft.Extensions.Logging;
using QIQO.Business.Core;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace QIQO.Companies.Data
{
    public class PersonRepository : RepositoryBase<PersonData>, IPersonRepository
    {
        private ICompanyDbContext entityContext;

        public PersonRepository(ICompanyDbContext dbc, IPersonMap map, ILogger<PersonData> log) : base(log, map)
        {
            entityContext = dbc;
        }

        public override IEnumerable<PersonData> GetAll()
        {
            Log.LogInformation("Accessing PersonRepo GetAll function");
            using (entityContext)
            {
                return MapRows(entityContext.ExecuteProcedureAsSqlDataReader("usp_person_all"));
            }
        }

        public IEnumerable<PersonData> GetAll(CompanyData comp)
        {
            Log.LogInformation("Accessing PersonRepo GetAll by Company function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@company_key", comp.CompanyKey) };
            using (entityContext)
            {
                return MapRows(entityContext.ExecuteProcedureAsSqlDataReader("usp_person_all_by_company", pcol));
            }
        }

        public override PersonData GetByCode(string account_code, string entity_code)
        {
            Log.LogInformation("Accessing PersonRepo GetByCode function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@person_code", entity_code) };

            using (entityContext)
            {
                return MapRow(entityContext.ExecuteProcedureAsSqlDataReader("usp_person_get_c", pcol));
            }
        }

        public override PersonData GetByID(int entity_key)
        {
            Log.LogInformation("Accessing PersonRepo GetByID function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@person_key", entity_key) };
            using (entityContext)
            {
                return MapRow(entityContext.ExecuteProcedureAsSqlDataReader("usp_person_get", pcol));
            }
        }

        public override void Insert(PersonData entity)
        {
            Log.LogInformation("Accessing PersonRepo Insert function");
            if (entity != null)
                Upsert(entity);
            else
                throw new ArgumentException(nameof(entity));
        }

        public override void Save(PersonData entity)
        {
            Log.LogInformation("Accessing PersonRepo Save function");
            if (entity != null)
                Upsert(entity);
            else
                throw new ArgumentException(nameof(entity));
        }

        public override void Delete(PersonData entity)
        {
            Log.LogInformation("Accessing PersonRepo Delete function");
            using (entityContext)
            {
                entityContext.ExecuteProcedureNonQuery("usp_person_del", Mapper.MapParamsForDelete(entity));
            }
        }

        public override void DeleteByCode(string entity_code)
        {
            Log.LogInformation("Accessing PersonRepo DeleteByCode function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@person_code", entity_code) };
            pcol.Add(Mapper.GetOutParam());
            using (entityContext)
            {
                entityContext.ExecuteProcedureNonQuery("usp_person_del_c", pcol);
            }
        }

        public override void DeleteByID(int entity_key)
        {
            Log.LogInformation("Accessing PersonRepo DeleteByID function");
            using (entityContext)
            {
                entityContext.ExecuteProcedureNonQuery("usp_person_del", Mapper.MapParamsForDelete(entity_key));
            }
        }

        public PersonData GetByUserName(string user_name)
        {
            Log.LogInformation("Accessing PersonRepo GetByUserName function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@user_name", user_name) };
            using (entityContext)
            {
                return MapRow(entityContext.ExecuteProcedureAsSqlDataReader("usp_person_by_creds", pcol));
            }
        }

        public IEnumerable<PersonData> GetAllReps(CompanyData comp, int rep_type)
        {
            Log.LogInformation("Accessing PersonRepo GetAllReps by Company function");
            var pcol = new List<SqlParameter>() {
                Mapper.BuildParam("@company_key", comp.CompanyKey),
                Mapper.BuildParam("@rep_type", rep_type)
            };
            using (entityContext)
            {
                return MapRows(entityContext.ExecuteProcedureAsSqlDataReader("usp_person_all_by_company_reponly", pcol));
            }
        }

        private void Upsert(PersonData entity)
        {
            using (entityContext)
            {
                entityContext.ExecuteProcedureNonQuery("usp_person_ups", Mapper.MapParamsForUpsert(entity));
            }
        }
    }

}