using System;
using System.Collections.Generic;

namespace EntityIdLib.Uids
{
    public class UidCore
    {
        private static UidCore? _core;

        public static UidCore Instance => _core
                                          ?? throw new NullReferenceException("_core is not defined. Use Init.");

        private readonly Dictionary<Type, EntityUidInfo> _typePrefixes =
            new Dictionary<Type, EntityUidInfo>();

        private readonly Dictionary<string, EntityUidInfo> _prefixTypes =
            new Dictionary<string, EntityUidInfo>(new PrefixEqualityComparer());

        #region Init

        public static void Init(IEnumerable<EntityUidInfo> types)
        {
            _core = new UidCore(types);
        }
        
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
                    $"Prefix '{info.Prefix}' is same as in {_prefixTypes[info.Prefix].Name} and want be used by {info.PublicUid.Name} in {info.Name}");
            _prefixTypes[info.Prefix] = info;
        }

        private void AddType(EntityUidInfo info)
        {
            if (_typePrefixes.ContainsKey(info.PublicUid))
                throw new ArgumentException(
                    $"Type '{info.PublicUid.Name}' is duplicated in entity {info.Name}");
            _typePrefixes[info.PublicUid] = info;
        }

        #endregion

        #region Check

        public void CheckType<T>(T uid, Type t)
            where T : IUid
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

        public void CheckType<T>(T uid)
            where T : IUid
        {
            if (uid.Value != null && !_prefixTypes.TryGetValue(uid.Value, out _))
            {
                throw new ArgumentException($"Id '{uid.Value}' is not entity id. Prefix is not found.");
            }
        }

        #endregion

        #region Get

        public EntityUidInfo? Get(Type type)
        {
            if (_typePrefixes.TryGetValue(type, out var desc))
            {
                return desc;
            }

            return null;
        }

        public IEnumerable<EntityUidInfo> GetAll()
        {
            return _prefixTypes.Values;
        }

        #endregion
    }
}