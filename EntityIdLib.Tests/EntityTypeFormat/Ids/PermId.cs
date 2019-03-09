using EntityIdLib.Ids;
using EntityIdLib.UIds;

namespace EntityIdLib.Tests.EntityTypeFormat.Ids
{
    public struct PermUid : IUid
    {
        private readonly Uid _uid;

        public PermUid(Uid uid)
        {
            _uid = uid;
            uid.CheckType(GetType());
        }

        public PermUid(PermUid uid)
        {
            _uid = uid._uid;
        }

        public string Value => _uid.Value;
    }

    public struct PermId : IIdBase<byte, PermId>
    {
        public PermId(byte id)
        {
            Id = id;
        }

        public byte Id { get; }
    }
}