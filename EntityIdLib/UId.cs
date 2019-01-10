namespace EntityIdLib
{
    public struct UId
    {
        public UId(string value)
        {
            Value = value;
        }

        public string Value { get; }
    }
}