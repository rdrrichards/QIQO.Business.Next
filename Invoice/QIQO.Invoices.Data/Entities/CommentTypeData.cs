using QIQO.Business.Core.Contracts;
using System;

namespace QIQO.Invoices.Data
{
    public class CommentTypeData : CommonData, IEntity
    { 
        public int CommentTypeKey { get; set; }
        public string CommentTypeCategory { get; set; }
        public string CommentTypeCode { get; set; }
        public string CommentTypeName { get; set; }
        public string CommentTypeDesc { get; set; }
    }
}