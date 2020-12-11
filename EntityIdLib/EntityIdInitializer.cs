using EntityIdLib.Uids;

namespace EntityIdLib
{
    public static class EntityIdInitializer
    {
        public static void Init(IEntityIdInfoSource source)
        {
            UidCore.Init(source.GetUidInfos());
        }
    }
}