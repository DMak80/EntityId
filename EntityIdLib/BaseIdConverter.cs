using System.Collections.Concurrent;

namespace EntityIdLib
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
}