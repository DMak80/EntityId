using System;

namespace EntityIdLib.Uids
{
    public static class UidCoreExtension
    {
        public static void CheckType(this IUid uid, Type t)
        {
            UidCore.Instance.CheckType(uid, t);
        }

        public static void CheckType(this IUid uid)
        {
            UidCore.Instance.CheckType(uid);
        }
    }
}