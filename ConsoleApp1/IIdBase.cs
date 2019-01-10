namespace ConsoleApp1
{
    public interface IIdBase<out T, TC>
        where TC : IIdBase<T, TC>
    {
        T Id { get; }
        UId ToUid();
    }
}