using EntityIdLib.Attributes;
using EntityIdLib.Converters;

namespace EntityIdLib.EntityTypeFormat
{
    public enum EntityType
    {
        [EntityId("U", typeof(IntIdConverter))]
        User,

        [EntityId("P", typeof(StringIdConverter))]
        Permission,

        [EntityId("PP", typeof(StringIdConverter))]
        Permission2
    }
}