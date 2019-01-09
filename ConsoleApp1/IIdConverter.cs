using System.Collections.Concurrent;

namespace ConsoleApp1
{
    public class BaseIdConverter
    {
        private static readonly ConcurrentDictionary<string, BaseIdConverter> dic =
            new ConcurrentDictionary<string, BaseIdConverter>();

        protected BaseIdConverter(string start)
        {
            dic.AddOrUpdate(start, this, (type, conv) => this);
        }

        //it's factory
        public static BaseIdConverter GetConverter(string start)
        {
            if (dic.TryGetValue(start, out var tt)) return tt;

            return null;
        }
    }

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