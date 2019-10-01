using System;
using EntityIdLib.Converters;

namespace EntityIdLib.Ids
{
    public static class IdCoreExtension
    {
        public static IdConverter<T> GetConverter<T, TC>(this TC obj)
            where TC : IIdBase<T, TC>
        {
            return IdCore.Instance.GetConverter<T, TC>();
        }
    }
}