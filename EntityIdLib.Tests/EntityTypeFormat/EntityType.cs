using EntityIdLib.Converters.Impl;
using EntityIdLib.Default;
using EntityIdLib.Tests.EntityTypeFormat.Ids;

namespace EntityIdLib.Tests.EntityTypeFormat
{
    public enum EntityType
    {
        [EntityUidInfo("U.", typeof(UserUid))]
        User,

        [EntityUidInfo("P.", typeof(PermUid))]
        Permission,

        [EntityUidInfo("PP.", typeof(Perm2Uid))]
        Permission2
    }
    public enum EntityIds
    {
        [EntityIdInfo(typeof(UserUid), typeof(UserId), typeof(IntIdConverter))]
        User,

        [EntityIdInfo(typeof(PermUid), typeof(PermId), typeof(ByteIdConverter))]
        Permission,

        [EntityIdInfo(typeof(Perm2Uid), typeof(Perm2Id), typeof(StringIdConverter))]
        Permission2
    }
}