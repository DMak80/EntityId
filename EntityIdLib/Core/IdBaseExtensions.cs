namespace EntityIdLib.Core
{
    public static class IdBaseExtensions
    {
        public static UId ToUid<T, TC>(this IIdBase<T, TC> obj)
            where TC : IIdBase<T, TC>
        {
            return obj.GetConverter().ToUid(obj.Id);
        }

        public static TC ToId<T, TC>(this UId obj)
            where TC : IIdBase<T, TC>
        {
            return (TC) Activator.CreateInstance(typeof(TC), IdBaseConverters.GetConverter<T, TC>().FromUid(obj));
        }
    }
}