using System;
using EntityIdLib.Uids;

namespace EntityIdLib.Converters.Impl
{
    public class IntIdConverter : IdConverter<int>
    {
        public IntIdConverter(string start) : base(start)
        {
        }

        private int? GetId(Uid uid)
        {
            if ((uid.Value?.StartsWith(Starts) ?? false)
                && uid.Value.Length > Starts.Length
                && int.TryParse(uid.Value.Substring(Starts.Length), out var i))
                return i;

            return null;
        }

        public override int FromUid(Uid uid)
        {
            return GetId(uid) ?? throw new ArgumentOutOfRangeException(nameof(uid));
        }

        public override Uid ToUid(int key)
        {
            return new Uid($"{Starts}{key}");
        }
    }
}