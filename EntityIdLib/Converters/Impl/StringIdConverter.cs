using System;
using EntityIdLib.Uids;

namespace EntityIdLib.Converters.Impl
{
    public class StringIdConverter : IdConverter<string?>
    {
        public StringIdConverter(string? start) : base(start)
        {
        }

        private bool IsValidUid(Uid uid)
        {
            return uid.Value.StartsWith(Starts) && uid.Value.Length > Starts.Length;
        }

        public override string FromUid(Uid uid)
        {
            if (!IsValidUid(uid))
                throw new ArgumentOutOfRangeException(nameof(uid));
            return uid.Value.Substring(Starts.Length);
        }

        public override Uid ToUid(string key)
        {
            return new Uid($"{Starts}{key}");
        }
    }
}