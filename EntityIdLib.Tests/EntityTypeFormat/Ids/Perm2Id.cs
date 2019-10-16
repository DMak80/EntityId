using EntityIdLib.Converters;
using EntityIdLib.Ids;
using EntityIdLib.Uids;

namespace EntityIdLib.Tests.EntityTypeFormat.Ids
{
    public struct Perm2Uid : IUid
    {
        private readonly Uid _uid;

        public Perm2Uid(Uid uid)
        {
            _uid = uid.For<Perm2Uid>();
        }

        public string Value => _uid.Value;
    }

    public struct Perm2Id : IIdBase<string, Perm2Id>
    {
        public static Converter<string, Perm2Id> Converter = new Converter<string, Perm2Id>();

        public Perm2Id(string id)
        {
            Id = id;
        }

        public string Id { get; }
        
        
        public Uid ToUid()
        {
            return Converter.ToUid(Id);
        }
    }
}