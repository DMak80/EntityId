using EntityIdLib.Ids;
using EntityIdLib.Uids;

namespace EntityIdLib
{
    public static class EntityIdInitializer
    {
        public static void Init(IEntityIdInfoSource source)
        {
            UidCore.Init(source.GetUidInfos());
            IdCore.Init(source.GetIdInfos());
        }
    }
}