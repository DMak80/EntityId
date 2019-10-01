using System;
using EntityIdLib.Ids;
using EntityIdLib.Uids;

namespace EntityIdLib.Converters
{
    public static class ConverterExtensions
    {
        public static Uid ToUid<T, TC>(this TC obj)
            where TC : IIdBase<T, TC>
        {
            return obj.GetConverter<T, TC>().ToUid(obj.Id);
        }

        public static TC ToId<T, TC>(this Uid obj)
            where TC : IIdBase<T, TC>
        {
            return (TC) Activator.CreateInstance(typeof(TC), default(TC).GetConverter<T, TC>().FromUid(obj));
        }
    }
}