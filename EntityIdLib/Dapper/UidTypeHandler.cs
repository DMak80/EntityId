using System.Data;
using Dapper;
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
            return new Uid(value.ToString());
        }
    }
}