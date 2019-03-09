using System;

namespace EntityIdLib.UIds
{
    public class EntityUidInfo
    {
        public EntityUidInfo(string prefix, Type publicUId, string name)
        {
            Prefix = prefix;
            PublicUId = publicUId;
            Name = name;

            if (!typeof(IUid).IsAssignableFrom(publicUId))
            {
                throw new ArgumentException($"{publicUId.Name} cannot be cast to IUId");
            }
        }

        public string Prefix { get; }
        public Type PublicUId { get; }
        public string Name { get; }
    }
}