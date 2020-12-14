using System;
using EntityIdLib.Converters;

namespace EntityIdLib.Uids
{
    public class EntityUidInfo
    {
        public EntityUidInfo(string prefix, Type publicUid, string name, Type? converter = null)
        {
            Prefix = prefix;
            PublicUid = publicUid;
            Name = name;
            ConverterType = converter;
            Converter = converter == null
                ? null
                :(UidConverter?)Activator.CreateInstance(converter, prefix);

            if (!typeof(IUid).IsAssignableFrom(publicUid))
            {
                throw new ArgumentException($"{publicUid.Name} cannot be cast to IUId");
            }
        }

        public string Prefix { get; }
        public Type PublicUid { get; }
        public string Name { get; }
        public UidConverter? Converter { get; }
        public Type? ConverterType { get; }
    }
}