using EntityIdLib.Converters.Impl;
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

        [EntityUidInfo("P2.", typeof(Perm2Uid))]
        Permission2
    }
    
    /// <summary>
    /// Inner Domain Converter
    /// </summary>
    public static class ConverterExtensions
    {
        public static IntUidConverter Converter(this UserUid uid)
        {
            return (IntUidConverter)UidCore.Instance.Get(uid.GetType()).Converter;
        }
        public static ByteUidConverter Converter(this PermUid uid)
        {
            return (ByteUidConverter)UidCore.Instance.Get(uid.GetType()).Converter;
        }
        public static StringUidConverter Converter(this Perm2Uid uid)
        {
            return (StringUidConverter)UidCore.Instance.Get(uid.GetType()).Converter;
        }
    }
}