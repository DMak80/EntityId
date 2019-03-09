using EntityIdLib.Uids;

namespace EntityIdLib.Converters
{
    public abstract class IdConverter<T> : BaseIdConverter
    {

        protected IdConverter(string start) : base(start)
        {
        }

        public abstract T FromUid(Uid uid);
        public abstract Uid ToUid(T key);
    }
}