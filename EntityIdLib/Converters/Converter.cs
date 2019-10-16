using System;
using System.Runtime.CompilerServices;
using EntityIdLib.Ids;
using EntityIdLib.Uids;

namespace EntityIdLib.Converters
{
    public class Converter<T, TC>
        where TC : IIdBase<T, TC>
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Uid ToUid(T id)
        {
            return default(TC).GetConverter<T, TC>().ToUid(id);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public TC FromUid(Uid uid)
        {
            return (TC) Activator.CreateInstance(typeof(TC), default(TC).GetConverter<T, TC>().FromUid(uid));
        }
    }
}