using System.Collections.Generic;
using EntityIdLib.Ids;
using EntityIdLib.Uids;

namespace EntityIdLib
{
    public interface IEntityIdInfoSource
    {
        IEnumerable<EntityUidInfo> GetUidInfos();
        IEnumerable<EntityIdInfo> GetIdInfos();
    }
}