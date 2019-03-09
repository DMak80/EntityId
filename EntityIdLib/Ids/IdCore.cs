using System;
using System.Collections.Concurrent;
using EntityIdLib.Converters;

namespace EntityIdLib.Ids
{
    public class IdCore
    {
        public static IdCore Instance { get; private set; }

        public static void Init(IEntityIdDescGetter getter)
        {
            Instance = new IdCore(getter);
        }

        private readonly ConcurrentDictionary<Type, BaseIdConverter> _converters =
            new ConcurrentDictionary<Type, BaseIdConverter>();

        private readonly IEntityIdDescGetter _getter;

        private IdCore(IEntityIdDescGetter getter)
        {
            _getter = getter ?? throw new ArgumentNullException(nameof(getter));
        }

        public IdConverter<T> GetConverter<T, TC>()
            where TC : IIdBase<T, TC>
        {
            return (IdConverter<T>) _converters.GetOrAdd(typeof(TC), GetConverter<T>);
        }

        private BaseIdConverter GetConverter<T>(Type tc)
        {
            EntityIdInfo info = null;
            info = _getter.Get(tc);
            if (info?.IdTypeConverter == null || string.IsNullOrEmpty(info.Info.Prefix))
            {
                return null;
            }

            return (BaseIdConverter) Activator.CreateInstance(info.IdTypeConverter, info.Info.Prefix);
        }
    }
}