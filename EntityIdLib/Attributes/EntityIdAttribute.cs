namespace EntityIdLib.Attributes
{
    [AttributeUsage(AttributeTargets.Field)]
    public class EntityIdAttribute : Attribute
    {
        public EntityIdAttribute(string prefix, Type idType)
        {
            Prefix = prefix;
            IdType = idType;
        }

        public string Prefix { get; }
        public Type IdType { get; }
    }
}