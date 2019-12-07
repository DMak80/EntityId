using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using EntityIdLib.Converters;

namespace EntityIdLib.Ids
{
    public class IdCore
    {
        private static IdCore? _core;
        
        public static IdCore Instance => _core 
                                          ?? throw new NullReferenceException("_core is not defined. Use Init.");
        
        public static void Init(IEnumerable<EntityIdInfo> infos)
        {
            _core = new IdCore(infos);
        }

        private readonly ConcurrentDictionary<Type, BaseIdConverter?> _converters =
            new ConcurrentDictionary<Type, BaseIdConverter?>();

        public IReadOnlyList<EntityIdInfo> Infos { get; }

        private IdCore(IEnumerable<EntityIdInfo> infos)
        {
            Infos = infos.ToList();
        }

        public IdConverter<T>? GetConverter<T, TC>()
            where TC : IIdBase<T, TC>
        {
            return (IdConverter<T>?) _converters.GetOrAdd(typeof(TC), GetConverter<T>);
        }

        private BaseIdConverter? GetConverter<T>(Type tc)
        {
            var info = Infos.FirstOrDefault(i => i.IdType == tc);
            if (info?.IdTypeConverter == null || string.IsNullOrEmpty(info.Info.Prefix))
            {
                return null;
            }

            return (BaseIdConverter) Activator.CreateInstance(info.IdTypeConverter, info.Info.Prefix);
        }
    }
}