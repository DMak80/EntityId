using EntityIdLib.Uids;

namespace EntityIdLib.Converters
{
    public class UidConverter
    {
        protected UidConverter(string start)
        {
            Starts = start;
        }

        public string Starts { get; }

        public abstract object FromUid(string uid);

        public abstract Uid ToUid(object key)
        {
            
        }
    }

    public abstract class UidConverter<T> : UidConverter
    {
        protected UidConverter(string start) : base(start)
        {
        }

        public abstract T FromUid(string uid);

        public abstract Uid ToUid(T key);
    }
}