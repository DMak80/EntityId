using System;
using System.Data;
using Dapper;
using EntityIdLib.Ids;

namespace EntityIdLib.Dapper
{
    public class IdTypeHandler<T, TC> : SqlMapper.TypeHandler<IIdBase<T, TC>>
        where TC : IIdBase<T, TC>
    {
        public override void SetValue(IDbDataParameter parameter, IIdBase<T, TC> value)
        {
            parameter.Value = value.Id;
        }

        public override IIdBase<T, TC> Parse(object value)
        {
            return (IIdBase<T, TC>) Activator.CreateInstance(typeof(TC), new[] {value});
        }
    }
}