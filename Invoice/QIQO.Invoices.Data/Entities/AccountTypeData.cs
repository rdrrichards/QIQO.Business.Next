﻿using QIQO.Business.Core.Contracts;

namespace QIQO.Invoices.Data
{
    public class AccountTypeData : CommonData, IEntity
    {
        public int AccountTypeKey { get; set; }
        public string AccountTypeCode { get; set; }
        public string AccountTypeName { get; set; }
        public string AccountTypeDesc { get; set; }
    }
}