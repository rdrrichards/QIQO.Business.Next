using QIQO.Business.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace QIQO.Companies.Data
{
    public class AddressPostalMap : MapperBase, IAddressPostalMap
    {
        public AddressPostalData Map(IDataReader record)
        {
            try
            {
                return new AddressPostalData()
                {
                    Country = NullCheck<string>(record["Country"]),
                    PostalCode = NullCheck<string>(record["PostalCode"]),
                    StateCode = NullCheck<string>(record["StateCode"]),
                    StateFullName = NullCheck<string>(record["StateFullName"]),
                    CityName = NullCheck<string>(record["CityName"]),
                    CountyName = NullCheck<string>(record["CountyName"]),
                    TimeZone = NullCheck<int>(record["TimeZone"])
                };
            }
            catch (Exception ex)
            {
                throw new MapException($"AddressPostalMap Exception occured: {ex.Message}", ex);
            }
        }

        public List<SqlParameter> MapParamsForUpsert(AddressPostalData entity) => new List<SqlParameter>
            {
                new SqlParameter("@Country", entity.Country),
                new SqlParameter("@PostalCode", entity.PostalCode),
                new SqlParameter("@StateCode", entity.StateCode),
                new SqlParameter("@StateFullName", entity.StateFullName),
                new SqlParameter("@CityName", entity.CityName),
                new SqlParameter("@CountyName", entity.CountyName),
                new SqlParameter("@TimeZone", entity.TimeZone),
                GetOutParam()
            };

        public List<SqlParameter> MapParamsForDelete(AddressPostalData entity) => new List<SqlParameter>
            {
                new SqlParameter("@PostalCode", entity.PostalCode),
                GetOutParam()
            };

        public List<SqlParameter> MapParamsForDelete(int AddressKey) => new List<SqlParameter>
            {
                new SqlParameter("@PostalCode", AddressKey),
                GetOutParam()
            };
    }
}
