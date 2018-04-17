using QIQO.Business.Core.Contracts;
using System;

namespace QIQO.Invoices.Domain
{
    public class CommentType : IModel
    {        
        public int CommentTypeKey { get; set; }        
        public string CommentTypeCategory { get; set; }        
        public string CommentTypeCode { get; set; }        
        public string CommentTypeName { get; set; }        
        public string CommentTypeDesc { get; set; }        
        public string AddedUserID { get; set; }        
        public DateTime AddedDateTime { get; set; }        
        public string UpdateUserID { get; set; }        
        public DateTime UpdateDateTime { get; set; }
    }
}
