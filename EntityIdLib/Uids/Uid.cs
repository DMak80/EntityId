namespace EntityIdLib.Uids
{
    public struct Uid : IUid
    {
        public static readonly Uid Empty = new Uid(null);
        
        public Uid(string? value)
        {
            Value = value;
            this.CheckType();
        }

        public Uid(Uid uid) : this(uid.Value)
        {
        }

        public string? Value { get; }

        public Uid For<T>()
        {
            this.CheckType(typeof(T));
            return this;
        }
    }
}