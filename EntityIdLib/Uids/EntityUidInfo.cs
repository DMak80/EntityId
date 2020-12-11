using System;

namespace EntityIdLib.Uids
{
    public class EntityUidInfo
    {
        public EntityUidInfo(string prefix, Type publicUid, string name, Type? converter = null)
        {
            Prefix = prefix;
            PublicUid = publicUid;
            Name = name;
            Converter = converter;

            if (!typeof(IUid).IsAssignableFrom(publicUid))
            {
                throw new ArgumentException($"{publicUid.Name} cannot be cast to IUId");
            }
        }

        public string Prefix { get; }
        public Type PublicUid { get; }
        public string Name { get; }
        public Type? Converter { get; }
    }
}