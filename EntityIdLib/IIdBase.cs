namespace EntityIdLib
{
    public interface IIdBase<out T, TC>
        where TC : IIdBase<T, TC>
    {
        T Id { get; }
    }
}