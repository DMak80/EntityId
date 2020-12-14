using System;
using EntityIdLib.Uids;

namespace EntityIdLib.Converters
{
    public abstract class UidConverter
    {
        protected UidConverter(string start)
        {
            Starts = start;
        }

        public string Starts { get; }

        public abstract object? FromUidToObject(string? uid);

        public abstract Uid ToUid(object? key);
    }

    public abstract class UidConverter<T> : UidConverter
    {
        protected UidConverter(string start) : base(start)
        {
        }

        public abstract T FromUid(string? uid);

        public abstract Uid ToUid(T key);

        public override object? FromUidToObject(string? uid)
        {
            return FromUid(uid);
        }
        
        public override Uid ToUid(object? key)
        {
            return ToUid((T)key);
        }
    }
}