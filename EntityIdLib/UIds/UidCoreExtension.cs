using System;

namespace EntityIdLib.UIds
{
    public static class UidCoreExtension
    {
        public static void CheckType(this Uid uid, Type t)
        {
            UidCore.Instance.CheckType(uid, t);
        }

        public static void CheckType(this Uid uid)
        {
            UidCore.Instance.CheckType(uid);
        }
    }
}