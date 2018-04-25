using System;

namespace QIQO.Orders.Data
{
    public class EntityEntityData : CommonData
    {
        public int EntityEntityKey { get; set; }
        public int PrimaryEntityKey { get; set; }
        public int PrimaryEntityTypeKey { get; set; }
        public int PrimaryEntityRoleKey { get; set; }
        public int SecondaryEntityKey { get; set; }
        public int SecondaryEntityTypeKey { get; set; }
        public int SecondaryEntityRoleKey { get; set; }
        public int EntityEntitySeq { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Comment { get; set; }
    }
    public class EntityTypeData : CommonData
    {
        public int EntityTypeKey { get; set; }
        public string EntityTypeCode { get; set; }
        public string EntityTypeName { get; set; }
    }
    public class EntityRoleData : CommonData
    {
        public int EntityRoleKey { get; set; }
        public string EntityRoleCode { get; set; }
        public string EntityRoleName { get; set; }
        public string EntityRoleDesc { get; set; }
    }
}