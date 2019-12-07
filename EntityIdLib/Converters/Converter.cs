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
            var converter = default(TC).GetConverter<T, TC>()
                   ?? throw new ArgumentException($"No converter from {typeof(T).FullName} to Uid");
            return converter.ToUid(id);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public TC FromUid(Uid uid)
        {
            var converter = default(TC).GetConverter<T, TC>()
                        ?? throw new ArgumentException($"No converter from Uid({uid.Value}) to {typeof(T).FullName}");
            return (TC) Activator.CreateInstance(typeof(TC), converter.FromUid(uid));
        }
    }
}