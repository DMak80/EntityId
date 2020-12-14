using System;
using EntityIdLib.Uids;

namespace EntityIdLib.Converters.Impl
{
    public class IntUidConverter : UidConverter<int>
    {
        public IntUidConverter(string start) : base(start)
        {
        }

        private int? GetId(string? uid)
        {
            if ((uid?.StartsWith(Starts) ?? false)
                && uid.Length > Starts.Length
                && int.TryParse(uid.Substring(Starts.Length), out var i))
                return i;

            return null;
        }

        public override int FromUid(string? uid)
        {
            return GetId(uid) ?? throw new ArgumentOutOfRangeException(nameof(uid));
        }

        public override Uid ToUid(int key)
        {
            return new Uid($"{Starts}{key}");
        }
        
        
        public override Uid ToUid(object? key)
        {
            return ToUid(key is int b ? b : Convert.ToInt32(key));
        }
    }
}