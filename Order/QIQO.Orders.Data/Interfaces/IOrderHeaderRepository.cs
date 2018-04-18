using QIQO.Business.Core.Contracts;
using System.Collections.Generic;

namespace QIQO.Orders.Data
{
    public interface IOrderHeaderRepository : IRepository<OrderHeaderData>
    {
        //IEnumerable<OrderHeaderData> GetAllOpen(CompanyData company);
        //IEnumerable<OrderHeaderData> GetAll(CompanyData company);
        IEnumerable<OrderHeaderData> GetAllOpen(AccountData account);
        IEnumerable<OrderHeaderData> GetAll(AccountData account);
        IEnumerable<OrderHeaderData> FindAll(int company_key, string pattern);
        IEnumerable<OrderHeaderData> GetForInvoice(int company_key, int account_key);
    }
}
