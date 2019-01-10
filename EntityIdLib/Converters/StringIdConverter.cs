using System;

namespace EntityIdLib.Converters
{
    public class StringIdConverter : IdConverter<string>
    {
        public StringIdConverter(string start) : base(start)
        {
        }

        public override bool IsValidUid(UId uid)
        {
            return (uid.Value?.StartsWith(Starts) ?? false)
                   && uid.Value.Length > Starts.Length;
        }

        public override string FromUid(UId uid)
        {
            if (!IsValidUid(uid))
                throw new ArgumentOutOfRangeException(nameof(uid));
            return uid.Value?.Substring(Starts.Length);
        }

        public override UId ToUid(string key)
        {
            return new UId($"{Starts}{key}");
        }
    }
}