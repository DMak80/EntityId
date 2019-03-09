using System;
using Dapper;
using EntityIdLib.Ids;

namespace EntityIdLib.Dapper
{
    public class DapperRegister
    {
        public static void Init()
        {
            SqlMapper.AddTypeHandler(new UidTypeHandler());

            var typeHandler = typeof(IdTypeHandler<,>);
            foreach (var entityIdInfo in IdCore.Instance.Infos)
            {
                var ttype = typeHandler.MakeGenericType(entityIdInfo.IdType.GetGenericArguments());
                var instance = (SqlMapper.ITypeHandler) Activator.CreateInstance(ttype);
                SqlMapper.AddTypeHandler(entityIdInfo.IdType, instance);
            }
        }
    }
}