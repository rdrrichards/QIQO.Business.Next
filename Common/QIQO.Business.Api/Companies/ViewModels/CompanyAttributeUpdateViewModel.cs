using QIQO.Companies.Domain;
using System;
using System.ComponentModel.DataAnnotations;

namespace QIQO.Business.Api.Companies
{
    public class CompanyAttributeUpdateViewModel
    {
        [Required]
        public int AttributeKey { get; set; }
        // public QIQOAttributeType AttributeType { get; set; } = QIQOAttributeType.AccountContact_CNCT_MAIN;
        // public AttributeType AttributeTypeData { get; set; }
        [Required]
        public string AttributeValue { get; set; }
        [Required]
        public int AttributeDataTypeKey { get; set; }
        [Required]
        public QIQOAttributeDataType AttributeDataType { get; set; } = QIQOAttributeDataType.String;
        public string AttributeDisplayFormat { get; set; }
        [Required]
        public string UpdateUserID { get; set; }
        [Required]
        public DateTime UpdateDateTime { get; set; }
    }
}
