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
                    Country = NullCheck<string>(record["country"]),
                    PostalCode = NullCheck<string>(record["postal_code"]),
                    StateCode = NullCheck<string>(record["state_code"]),
                    StateFullName = NullCheck<string>(record["state_full_name"]),
                    CityName = NullCheck<string>(record["city_name"]),
                    CountyName = NullCheck<string>(record["county_name"]),
                    TimeZone = NullCheck<int>(record["time_zone"])
                };
            }
            catch (Exception ex)
            {
                throw new MapException($"AddressPostalMap Exception occured: {ex.Message}", ex);
            }
        }

        public List<SqlParameter> MapParamsForUpsert(AddressPostalData entity) => new List<SqlParameter>
            {
                new SqlParameter("@country", entity.Country),
                new SqlParameter("@postal_code", entity.PostalCode),
                new SqlParameter("@state_code", entity.StateCode),
                new SqlParameter("@state_full_name", entity.StateFullName),
                new SqlParameter("@city_name", entity.CityName),
                new SqlParameter("@county_name", entity.CountyName),
                new SqlParameter("@time_zone", entity.TimeZone),
                GetOutParam()
            };

        public List<SqlParameter> MapParamsForDelete(AddressPostalData entity) => new List<SqlParameter>
            {
                new SqlParameter("@postal_code", entity.PostalCode),
                GetOutParam()
            };

        public List<SqlParameter> MapParamsForDelete(int address_key) => new List<SqlParameter>
            {
                new SqlParameter("@postal_code", address_key),
                GetOutParam()
            };
    }
}
