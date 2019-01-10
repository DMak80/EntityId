namespace ConsoleApp1
{
    public enum EntityType
    {
        [EntityId("U", typeof(IntIdConverter))]
        User,

        [EntityId("P", typeof(StringIdConverter))]
        Permission
    }
}