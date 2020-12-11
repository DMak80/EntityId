using System.Collections.Generic;
using EntityIdLib.Uids;

namespace EntityIdLib
{
    public interface IEntityIdInfoSource
    {
        IEnumerable<EntityUidInfo> GetUidInfos();
    }
}