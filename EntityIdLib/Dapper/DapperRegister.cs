using System;
using Dapper;
using EntityIdLib.Uids;

namespace EntityIdLib.Dapper
{
    public class DapperRegister
    {
        public static void Init()
        {
            SqlMapper.AddTypeHandler(new UidTypeHandler());
            var infos = UidCore.Instance.GetAll();
            foreach (var uidInfo in infos)
            {
                if (uidInfo.Converter == null)
                {
                    var type = typeof(TUidTypeHandler<>).MakeGenericType(uidInfo.PublicUid);
                    
                    SqlMapper.AddTypeHandler(uidInfo.PublicUid, (SqlMapper.ITypeHandler)Activator.CreateInstance(type));
                }
                else
                {
                    var type = typeof(TUidTypeHandler<,>).MakeGenericType(uidInfo.PublicUid, uidInfo.Converter.GenericTypeArguments[0]);
                    
                    SqlMapper.AddTypeHandler(uidInfo.PublicUid, (SqlMapper.ITypeHandler)Activator.CreateInstance(type));
                    
                }
            }
        }
    }
}