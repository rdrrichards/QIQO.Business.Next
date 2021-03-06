﻿using QIQO.Accounts.Data;
using QIQO.Accounts.Domain;

namespace QIQO.Accounts.Manager
{
    public class AddressTypeEntityService : IAddressTypeEntityService
    {
        public AddressType Map(AddressTypeData commentData) => new AddressType(commentData);
        public AddressTypeData Map(AddressType comment) => new AddressTypeData()
        {
            AddressTypeKey = comment.AddressTypeKey,
            AddressTypeCode = comment.AddressTypeCode,
            AddressTypeName = comment.AddressTypeName,
            AddressTypeDesc = comment.AddressTypeDesc
        };
    }
}
