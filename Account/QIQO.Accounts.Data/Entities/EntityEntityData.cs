using System;

namespace QIQO.Accounts.Data
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
}
