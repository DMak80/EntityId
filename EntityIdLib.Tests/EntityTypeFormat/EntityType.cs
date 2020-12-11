using EntityIdLib.Converters.Impl;
using EntityIdLib.Default;
using EntityIdLib.Tests.EntityTypeFormat.Ids;
using EntityIdLib.Uids;

namespace EntityIdLib.Tests.EntityTypeFormat
{
    /// <summary>
    /// Common Data
    /// </summary>
    public enum EntityType
    {
        [EntityUidInfo("U.", typeof(UserUid))]
        User,

        [EntityUidInfo("P.", typeof(PermUid))]
        Permission,

        [EntityUidInfo("PP.", typeof(Perm2Uid))]
        Permission2
    }
    /// <summary>
    /// Inner Domain Data
    /// </summary>
    public enum ConvertUids
    {
        [EntityUidConverter(typeof(UserUid), typeof(IntUidConverter))]
        User,

        [EntityUidConverter(typeof(PermUid), typeof(ByteUidConverter))]
        Permission,

        [EntityUidConverter(typeof(Perm2Uid), typeof(StringUidConverter))]
        Permission2
    }
}