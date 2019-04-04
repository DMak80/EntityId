using EntityIdLib.Ids;
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
            _uid = uid;
            uid.CheckType(GetType());
        }

        public UserUid(UserUid uid)
        {
            _uid = uid._uid;
        }

        public string Value => _uid.Value;
    }

    public struct UserId : IIdBase<int, UserId>
    {
        public UserId(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}