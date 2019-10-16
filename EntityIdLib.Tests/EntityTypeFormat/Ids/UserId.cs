using EntityIdLib.Converters;
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
            _uid = uid.For<UserUid>();
        }

        public string Value => _uid.Value;
    }

    public struct UserId : IIdBase<int, UserId>
    {
        public static Converter<int, UserId> Converter = new Converter<int, UserId>();

        public UserId(int id)
        {
            Id = id;
        }

        public int Id { get; }

        public Uid ToUid()
        {
            return Converter.ToUid(Id);
        }
    }
}