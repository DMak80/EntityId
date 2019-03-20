using System;
using System.Linq;
using Dapper;
using EntityIdLib.Ids;
using EntityIdLib.Uids;

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
                var args = entityIdInfo.IdType
                    .GetInterfaces()
                    .FirstOrDefault(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IIdBase<,>))
                    ?.GetGenericArguments();
                var ttype = typeHandler.MakeGenericType(args);
                var instance = (SqlMapper.ITypeHandler) Activator.CreateInstance(ttype);
                SqlMapper.AddTypeHandler(entityIdInfo.IdType, instance);
            }
        }
    }
}