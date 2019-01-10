using System;

namespace EntityIdLib.Converters
{
    public class GuidIdConverter : IdConverter<Guid>
    {
        public GuidIdConverter(string start) : base(start)
        {
        }

        private Guid? GetId(UId uid)
        {
            if ((uid.Value?.StartsWith(Starts) ?? false)
                && uid.Value.Length > Starts.Length
                && Guid.TryParse(uid.Value.Substring(Starts.Length), out var i))
                return i;

            return null;
        }

        public override bool IsValidUid(UId uid)
        {
            return GetId(uid).HasValue;
        }

        public override Guid FromUid(UId uid)
        {
            return GetId(uid) ?? throw new ArgumentOutOfRangeException(nameof(uid));
        }

        public override UId ToUid(Guid key)
        {
            return new UId($"{Starts}{key}");
        }
    }
}