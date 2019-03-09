using System;

namespace EntityIdLib.Ids
{
    public interface IEntityIdDescGetter
    {
        EntityIdInfo Get(Type type);
    }
}