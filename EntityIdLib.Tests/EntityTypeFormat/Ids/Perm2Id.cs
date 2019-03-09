using EntityIdLib.Ids;
using EntityIdLib.Uids;

namespace EntityIdLib.Tests.EntityTypeFormat.Ids
{
    public struct Perm2Uid : IUid
    {
        private readonly Uid _uid;

        public Perm2Uid(Uid uid)
        {
            _uid = uid;
            uid.CheckType(GetType());
        }

        public Perm2Uid(Perm2Uid uid)
        {
            _uid = uid._uid;
        }

        public string Value => _uid.Value;
    }

    public struct Perm2Id : IIdBase<string, Perm2Id>
    {
        public Perm2Id(string id)
        {
            Id = id;
        }

        public string Id { get; }
    }
}