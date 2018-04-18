﻿using Microsoft.Extensions.Logging;
using QIQO.Business.Core;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace QIQO.Invoices.Data
{
    public class CommentRepository : RepositoryBase<CommentData>, ICommentRepository
    {
        private IInvoiceDbContext entityContext;

        public CommentRepository(IInvoiceDbContext dbc, ICommentMap map, ILogger<CommentData> log) : base(log, map)
        {
            entityContext = dbc;
        }

        public override IEnumerable<CommentData> GetAll()
        {
            Log.LogInformation("Accessing CommentRepo GetAll function");
            using (entityContext)
            {
                return MapRows(entityContext.ExecuteProcedureAsSqlDataReader("usp_comment_all"));
            }
        }

        public IEnumerable<CommentData> GetAll(int entity_key, int entity_type_key)
        {
            Log.LogInformation("Accessing CommentRepo GetAll function");
            var pcol = new List<SqlParameter>()
            {
                Mapper.BuildParam("@entity_key", entity_key),
                Mapper.BuildParam("@entity_type_key", entity_type_key)
            };
            using (entityContext)
            {
                return MapRows(entityContext.ExecuteProcedureAsSqlDataReader("usp_comment_all_by_entity", pcol));
            }
        }

        public override CommentData GetByID(int comment_key)
        {
            Log.LogInformation("Accessing CommentRepo GetByID function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@comment_key", comment_key) };

            using (entityContext)
            {
                return MapRow(entityContext.ExecuteProcedureAsSqlDataReader("usp_comment_get", pcol));
            }
        }

        public override CommentData GetByCode(string comment_code, string entity_code)
        {
            Log.LogInformation("Accessing CommentRepo GetByCode function");
            var pcol = new List<SqlParameter>()
            {
                Mapper.BuildParam("@comment_code", comment_code),
                Mapper.BuildParam("@company_code", entity_code)
            };

            using (entityContext)
            {
                return MapRow(entityContext.ExecuteProcedureAsSqlDataReader("usp_comment_get_c", pcol));
            }
        }

        public override void Insert(CommentData entity)
        {
            Log.LogInformation("Accessing CommentRepo Insert function");
            if (entity != null)
                Upsert(entity);
            else
                throw new ArgumentException(nameof(entity));
        }

        public override void Save(CommentData entity)
        {
            Log.LogInformation("Accessing CommentRepo Save function");
            if (entity != null)
                Upsert(entity);
            else
                throw new ArgumentException(nameof(entity));
        }

        public override void Delete(CommentData entity)
        {
            Log.LogInformation("Accessing CommentRepo Delete function");
            using (entityContext)
            {
                entityContext.ExecuteProcedureNonQuery("usp_comment_del", Mapper.MapParamsForDelete(entity));
            }
        }

        public override void DeleteByCode(string entity_code)
        {
            Log.LogInformation("Accessing CommentRepo DeleteByCode function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@comment_code", entity_code) };
            pcol.Add(Mapper.GetOutParam());
            using (entityContext)
            {
                entityContext.ExecuteProcedureNonQuery("usp_comment_del_c", pcol);
            }
        }

        public override void DeleteByID(int entity_key)
        {
            Log.LogInformation("Accessing CommentRepo Delete function");
            using (entityContext)
            {
                entityContext.ExecuteProcedureNonQuery("usp_comment_del", Mapper.MapParamsForDelete(entity_key));
            }
        }

        private void Upsert(CommentData entity)
        {
            using (entityContext)
            {
                entityContext.ExecuteProcedureNonQuery("usp_comment_ups", Mapper.MapParamsForUpsert(entity));
            }
        }
    }

}