using EntityIdLib.Converters;
using EntityIdLib.Ids;
using EntityIdLib.Uids;

namespace EntityIdLib.Tests.EntityTypeFormat.Ids
{
    public struct PermUid : IUid
    {
        private readonly Uid _uid;

        public PermUid(Uid uid)
        {
            _uid = uid.For<PermUid>();
        }

        public string Value => _uid.Value;
    }

    public struct PermId : IIdBase<byte, PermId>
    {
        public static readonly Converter<byte, PermId> Converter = new Converter<byte, PermId>();
        
        public PermId(byte id)
        {
            Id = id;
        }

        public byte Id { get; }

        public Uid ToUid()
        {
            return Converter.ToUid(Id);
        }
    }
}