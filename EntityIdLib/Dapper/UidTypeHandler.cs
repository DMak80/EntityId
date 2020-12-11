using System;
using System.Data;
using Dapper;
using EntityIdLib.Converters;
using EntityIdLib.Uids;

namespace EntityIdLib.Dapper
{
    public class UidTypeHandler : SqlMapper.TypeHandler<Uid>
    {
        public override void SetValue(IDbDataParameter parameter, Uid value)
        {
            parameter.Value = value.Value;
        }

        public override Uid Parse(object value)
        {
            return new Uid(value?.ToString());
        }
    }

    public class TUidTypeHandler<T> : SqlMapper.TypeHandler<T>
        where T : IUid
    {
        public override void SetValue(IDbDataParameter parameter, T value)
        {
            parameter.Value = value.Value;
        }

        public override T Parse(object value)
        {
            return (T) Activator.CreateInstance(typeof(T), new Uid(value?.ToString()));
        }
    }

    public class TUidTypeHandler<T, TC> : SqlMapper.TypeHandler<T>
        where T : IUid
    {
        private static UidConverter<TC> converter =
            (UidConverter<TC>) Activator.CreateInstance(UidCore.Instance.Get(typeof(T)).Converter,
                UidCore.Instance.Get(typeof(T)).Prefix);

        public override void SetValue(IDbDataParameter parameter, T value)
        {
            parameter.Value = converter.FromUid(value.Value);
        }

        public override T Parse(object value)
        {
            return (T) Activator.CreateInstance(typeof(T), converter.ToUid((TC)value));
        }
    }
}