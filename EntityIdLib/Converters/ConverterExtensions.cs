using System;
using EntityIdLib.Ids;
using EntityIdLib.UIds;

namespace EntityIdLib.Converters
{
    public static class ConverterExtensions
    {
        public static Uid ToUid<T, TC>(this IIdBase<T, TC> obj)
            where TC : IIdBase<T, TC>
        {
            return obj.GetConverter().ToUid(obj.Id);
        }

        public static TC ToId<T, TC>(this Uid obj)
            where TC : IIdBase<T, TC>
        {
            return (TC) Activator.CreateInstance(typeof(TC), default(TC).GetConverter().FromUid(obj));
        }
    }
}