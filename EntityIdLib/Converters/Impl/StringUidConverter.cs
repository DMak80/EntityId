using System;
using EntityIdLib.Uids;

namespace EntityIdLib.Converters.Impl
{
    public class StringUidConverter : UidConverter<string>
    {
        public StringUidConverter(string start) : base(start)
        {
        }

        private bool IsValidUid(string uid)
        {
            return (uid?.StartsWith(Starts) ?? false) && uid.Length > Starts.Length;
        }

        public override string FromUid(string uid)
        {
            if (!IsValidUid(uid))
                throw new ArgumentOutOfRangeException(nameof(uid));
            return uid?.Substring(Starts.Length) ?? string.Empty;
        }

        public override Uid ToUid(string key)
        {
            return new Uid($"{Starts}{key}");
        }
    }
}