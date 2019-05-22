using System;

namespace EntityIdLib.Uids
{
    public static class UidCoreExtension
    {
        public static void CheckType<T>(this T uid, Type t)
            where T : IUid
        {
            UidCore.Instance.CheckType(uid, t);
        }

        public static void CheckType<T>(this T uid)
            where T : IUid
        {
            UidCore.Instance.CheckType(uid);
        }
    }
}