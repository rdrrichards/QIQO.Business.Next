﻿using QIQO.Business.Core.Contracts;
using System;

namespace QIQO.Companies.Domain
{
    public class EntityAttribute : IModel
    {
        public int AttributeKey { get; private set; }
        public int EntityKey { get; private set; }
        public QIQOEntityType EntityType { get; private set; } = QIQOEntityType.Account;
        // public EntityType EntityTypeData { get; private set; }
        // public QIQOAttributeType AttributeType { get; private set; } = QIQOAttributeType.AccountContact_CNCT_MAIN;
        // public AttributeType AttributeTypeData { get; private set; }
        public string AttributeValue { get; private set; }
        public int AttributeDataTypeKey { get; private set; }
        public QIQOAttributeDataType AttributeDataType { get; private set; } = QIQOAttributeDataType.String;
        public string AttributeDisplayFormat { get; private set; }
        public string AddedUserID { get; private set; }
        public DateTime AddedDateTime { get; private set; }
        public string UpdateUserID { get; private set; }
        public DateTime UpdateDateTime { get; private set; }
    }
}