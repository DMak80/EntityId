using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace EntityIdLib.Core
{
    public static class IdPrefixChecker
    {
        private static readonly ConcurrentDictionary<string, Type> Prefixes =
            new ConcurrentDictionary<string, Type>(new PrefixEqualityComparer());

        public static void CheckUniquePrefix(string prefix, Type type)
        {
            var ttype = Prefixes.GetOrAdd(prefix, type);
            if (type != ttype)
                throw new ArgumentException(
                    $"Prefix '{prefix}' is same as in {ttype.Name} and want be used by {type.Name}");
        }

        private class PrefixEqualityComparer : IEqualityComparer<string>
        {
            public bool Equals(string x, string y)
            {
                return x.StartsWith(y) || y.StartsWith(x);
            }

            public int GetHashCode(string obj)
            {
                return obj[0].GetHashCode();
            }
        }
    }
}