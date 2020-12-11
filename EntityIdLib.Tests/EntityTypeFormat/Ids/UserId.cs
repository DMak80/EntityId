using EntityIdLib.Json;
using EntityIdLib.Uids;
using Newtonsoft.Json;

namespace EntityIdLib.Tests.EntityTypeFormat.Ids
{
    [JsonConverter(typeof(UidJsonConverter))]
    public struct UserUid : IUid
    {
        private readonly Uid _uid;

        public UserUid(Uid uid)
        {
            _uid = uid.For<UserUid>();
        }

        public string Value => _uid.Value;
    }
}