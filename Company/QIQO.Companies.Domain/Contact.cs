using QIQO.Business.Core.Contracts;
using System;

namespace QIQO.Companies.Domain
{
    public class Contact : IModel
    {
        public int ContactKey { get; private set; }
        public int EntityKey { get; private set; }
        public int EntityTypeKey { get; private set; }
        public int ContactTypeKey { get; private set; }
        public QIQOContactType ContactType { get; private set; } = QIQOContactType.CellPhone;
        public string ContactValue { get; private set; }
        public int ContactDefaultFlg { get; private set; }
        public int ContactActiveFlg { get; private set; }
        public string AddedUserID { get; private set; }
        public DateTime AddedDateTime { get; private set; }
        public string UpdateUserID { get; private set; }
        public DateTime UpdateDateTime { get; private set; }

    }
}
