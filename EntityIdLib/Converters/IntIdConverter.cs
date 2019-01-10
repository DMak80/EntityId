using System;

namespace EntityIdLib.Converters
{
    public class IntIdConverter : IdConverter<int>
    {
        public IntIdConverter(string start) : base(start)
        {
        }

        private int? GetId(UId uid)
        {
            if ((uid.Value?.StartsWith(Starts) ?? false)
                && uid.Value.Length > Starts.Length
                && int.TryParse(uid.Value.Substring(Starts.Length), out var i))
                return i;

            return null;
        }

        public override bool IsValidUid(UId uid)
        {
            return GetId(uid).HasValue;
        }

        public override int FromUid(UId uid)
        {
            return GetId(uid) ?? throw new ArgumentOutOfRangeException(nameof(uid));
        }

        public override UId ToUid(int key)
        {
            return new UId($"{Starts}{key}");
        }
    }
}