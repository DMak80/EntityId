using System;
using System.Collections.Generic;

namespace EntityIdLib.Uids
{
    internal class PrefixEqualityComparer : IEqualityComparer<string>
    {
        public bool Equals(string? x, string? y)
        {
            var dx = x ?? string.Empty;
            var dy = y ?? string.Empty;
            return dx.StartsWith(dy, StringComparison.OrdinalIgnoreCase)
                   || dy.StartsWith(dx, StringComparison.OrdinalIgnoreCase);
        }

        public int GetHashCode(string obj)
        {
            return obj.Length == 0
                ? 0
                : obj.Substring(0, 1).ToLower().GetHashCode();
        }
    }
}