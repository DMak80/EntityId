namespace EntityIdLib.Ids
{
    public interface IIdBase<out T, TC>
        where TC : IIdBase<T, TC>
    {
        T Id { get; }
    }
}