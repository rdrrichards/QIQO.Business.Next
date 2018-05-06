using QIQO.Companies.Domain;
using System;
using System.ComponentModel.DataAnnotations;

namespace QIQO.Business.Api.Companies
{
    public class CompanyAttributeAddViewModel
    {
        [Required]
        public int EntityKey { get; set; }
        public QIQOEntityType EntityType => QIQOEntityType.Company;
        // public EntityType EntityTypeData { get; set; }
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
        public string AddedUserID { get; set; }
        [Required]
        public DateTime AddedDateTime { get; set; }
    }
}
