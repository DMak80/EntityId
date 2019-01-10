using System;

namespace EntityIdLib.Converters
{
    public class LongIdConverter : IdConverter<long>
    {
        public LongIdConverter(string start) : base(start)
        {
        }

        private long? GetId(UId uid)
        {
            if ((uid.Value?.StartsWith(Starts) ?? false)
                && uid.Value.Length > Starts.Length
                && long.TryParse(uid.Value.Substring(Starts.Length), out var i))
                return i;

            return null;
        }

        public override bool IsValidUid(UId uid)
        {
            return GetId(uid).HasValue;
        }

        public override long FromUid(UId uid)
        {
            return GetId(uid) ?? throw new ArgumentOutOfRangeException(nameof(uid));
        }

        public override UId ToUid(long key)
        {
            return new UId($"{Starts}{key}");
        }
    }
}