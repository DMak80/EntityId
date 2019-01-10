using System;

namespace EntityIdLib.Converters
{
    public class ShortIdConverter : IdConverter<short>
    {
        public ShortIdConverter(string start) : base(start)
        {
        }

        private short? GetId(UId uid)
        {
            if ((uid.Value?.StartsWith(Starts) ?? false)
                && uid.Value.Length > Starts.Length
                && short.TryParse(uid.Value.Substring(Starts.Length), out var i))
                return i;

            return null;
        }

        public override bool IsValidUid(UId uid)
        {
            return GetId(uid).HasValue;
        }

        public override short FromUid(UId uid)
        {
            return GetId(uid) ?? throw new ArgumentOutOfRangeException(nameof(uid));
        }

        public override UId ToUid(short key)
        {
            return new UId($"{Starts}{key}");
        }
    }
}