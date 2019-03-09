namespace EntityIdLib.UIds
{
    public struct Uid : IUid
    {
        public Uid(string value)
        {
            Value = value;
            this.CheckType();
        }

        public Uid(Uid uid) : this(uid.Value)
        {
        }

        public string Value { get; }
    }
}