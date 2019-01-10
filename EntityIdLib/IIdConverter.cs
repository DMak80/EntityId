namespace EntityIdLib
{
    public abstract class IdConverter<T> : BaseIdConverter
    {
        protected readonly string Starts;

        protected IdConverter(string start) : base(start)
        {
            Starts = start;
        }

        public abstract bool IsValidUid(UId uid);
        public abstract T FromUid(UId uid);
        public abstract UId ToUid(T key);
    }
}