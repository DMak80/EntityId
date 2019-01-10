using EntityIdLib.Attributes;

namespace EntityIdLib
{
    public interface IEntityIdAttributeGetter
    {
        EntityIdAttribute Get(Type type);
    }
}