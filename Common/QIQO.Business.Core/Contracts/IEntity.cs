namespace QIQO.Business.Core.Contracts
{
    public interface IReadOnlyEntity
    {
        // int EntityRowKey { get; set; }
    }
    public interface IWriteOnlyEntity
    {
        // int EntityRowKey { get; set; }
    }
    public interface IEntity : IReadOnlyEntity, IWriteOnlyEntity
    {
        // int EntityRowKey { get; set; }
    }
}
