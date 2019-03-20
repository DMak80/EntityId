using System;
using System.Collections.Generic;

namespace EntityIdLib.Uids
{
    public class UidCore
    {
        public static UidCore Instance { get; private set; }

        public static void Init(IEnumerable<EntityUidInfo> types)
        {
            Instance = new UidCore(types);
        }
        private class PrefixEqualityComparer : IEqualityComparer<string>
        {
            public bool Equals(string x, string y)
            {
                return x.StartsWith(y, StringComparison.OrdinalIgnoreCase)
                       || y.StartsWith(x, StringComparison.OrdinalIgnoreCase);
            }

            public int GetHashCode(string obj)
            {
                return obj.Substring(0, 1).ToLower().GetHashCode();
            }
        }

        private readonly Dictionary<Type, EntityUidInfo> _typePrefixes = 
            new Dictionary<Type, EntityUidInfo>();

        private readonly Dictionary<string, EntityUidInfo> _prefixTypes =
            new Dictionary<string, EntityUidInfo>(new PrefixEqualityComparer());

        private UidCore(IEnumerable<EntityUidInfo> types)
        {
            foreach (var desc in types)
            {
                AddPrefix(desc);
                AddType(desc);
            }
        }

        private void AddPrefix(EntityUidInfo info)
        {
            if (_prefixTypes.ContainsKey(info.Prefix))
                throw new ArgumentException(
                    $"Prefix '{info.Prefix}' is same as in {_prefixTypes[info.Prefix].Name} and want be used by {info.PublicUId.Name} in {info.Name}");
            _prefixTypes[info.Prefix] = info;
        }

        private void AddType(EntityUidInfo info)
        {
            if (_typePrefixes.ContainsKey(info.PublicUId))
                throw new ArgumentException(
                    $"Type '{info.PublicUId.Name}' is duplicated in entity {info.Name}");
            _typePrefixes[info.PublicUId] = info;
        }

        public void CheckType(IUid uid, Type t)
        {
            if (_typePrefixes.TryGetValue(t, out var prefix))
            {
                if (uid.Value?.StartsWith(prefix.Prefix) != true)
                {
                    throw new ArgumentException($"Uid '{uid.Value}' is not type of {t.Name}");
                }
            }
            else
            {
                throw new ArgumentException($"Type {t.Name} is not entity id");
            }
        }

        public void CheckType(IUid uid)
        {
            if (!_prefixTypes.TryGetValue(uid.Value, out _))
            {
                throw new ArgumentException($"Id '{uid.Value}' is not entity id. Prefix is not found.");
            }
        }

        public EntityUidInfo Get(Type type)
        {
            if (_typePrefixes.TryGetValue(type, out var desc))
            {
                return desc;
            }

            return null;
        }
    }
}