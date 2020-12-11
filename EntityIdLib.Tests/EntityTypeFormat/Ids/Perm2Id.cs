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
}