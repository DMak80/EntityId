using System;
using System.Reflection;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }


    public interface IIdConverter<T>
    {
        bool IsUid(string uid);
        T FromUid(string uid);
        string ToUid(T key);
    }

    public class IdBase<T, TConv>
        where TConv : IIdConverter<T>
    {
        private static readonly Lazy<TConv> conv = new Lazy<TConv>(Activator.CreateInstance<TConv>);
        private string uid = null;

        protected IdBase(T key)
        {
            Key = key;
        }

        protected IdBase(string uid) : this(FromUid(uid))
        {
            this.uid = AsUid(uid);
        }

        private static string AsUid(string uid)
        {
            return Conv.IsUid(uid) ? uid : Conv.ToUid(uid);
        }

        private static string FromUid(string uid)
        {
            if (Conv.IsUid(uid))
            {
                return Conv.FromUid(uid);
            }
            return uid;
        }

        private static T FromUid(string uid)
        {
            if (typeof(T) != typeof(string))
            {
                return Conv.FromUid(uid);
            }
            
            if (Conv.IsUid(uid))
            {
                return Conv.FromUid(uid);
            }
            return uid as T;
        }
        protected static TConv Conv => conv.Value;

        public string UID => uid ?? (uid = conv.Value.ToUid(Key));
        public T Key { get; }
    }

    public class UserId : IdBase<int,UserIdConverter>
    {
        protected UserId(int key) : base(key)
        {
        }

        protected UserId(string uid) : base(uid)
        {
        }
    }

    public class PermId : IdBase<string,PermIdConverter>
    {
        protected PermId(string key) : base(key)
        {
        }
    }

    public class UserIdConverter : IIdConverter<int>
    {
        public bool IsUid(string uid)
        {
            return uid?.StartsWith("U") ?? false;
        }

        public int FromUid(string uid)
        {
            return int.Parse(uid.Substring(1));
        }

        public string ToUid(int key)
        {
            return $"U{key}";
        }
    }

    public class PermIdConverter : IIdConverter<string>
    {
        public bool IsUid(string uid)
        {
            return uid?.StartsWith("P") ?? false;
        }

        public string FromUid(string uid)
        {
            uid.Substring(1);
        }

        public string ToUid(string key)
        {
            return $"P{key}";
        }
    }
}