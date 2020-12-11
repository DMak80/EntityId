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
}