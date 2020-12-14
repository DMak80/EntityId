using System;
using System.Data;
using Dapper;
using EntityIdLib.Converters;
using EntityIdLib.Converters.Impl;
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
        private class FakeConverter : StringUidConverter
        {
            public FakeConverter(string? start) : base(start ?? string.Empty)
            {
            }
        }

        private static readonly UidConverter Converter = UidCore.Instance.Get(typeof(T))?.Converter
                                                         ?? new FakeConverter(UidCore.Instance.Get(typeof(T))?.Prefix);

        public override void SetValue(IDbDataParameter parameter, T value)
        {
            parameter.Value = Converter.FromUidToObject(value.Value);
        }

        public override T Parse(object value)
        {
            return (T) Activator.CreateInstance(typeof(T), Converter.ToUid(value))
                   ?? throw new InvalidOperationException();
        }
    }
}