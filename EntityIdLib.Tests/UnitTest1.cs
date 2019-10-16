using System;
using EntityIdLib.Converters;
using EntityIdLib.Default;
using EntityIdLib.Ids;
using EntityIdLib.Json;
using EntityIdLib.Tests.EntityTypeFormat;
using EntityIdLib.Tests.EntityTypeFormat.Ids;
using EntityIdLib.Uids;
using Newtonsoft.Json;
using Xunit;

namespace EntityIdLib.Tests
{
    public class UnitTest1
    {
        public UnitTest1()
        {
            UidCore.Init(UidEnumConverter.GetUidInfos<EntityType>());
            IdCore.Init(UidEnumConverter.GetIdInfos<EntityIds>());
        }

        [Fact]
        public void Test1()
        {
            var userId = new UserId(1);
            var uidUserId = userId.ToUid();
            Assert.Equal("U.1", uidUserId.Value);
        }

        [Fact]
        public void Test2()
        {
            var permId = new PermId(123);
            var uidPermId = permId.ToUid();
            Assert.Equal("P.123", uidPermId.Value);
        }

        [Fact]
        public void Test3()
        {
            var perm2Id = new Perm2Id("123");
            var uidPerm2Id = perm2Id.ToUid();
            Assert.Equal("PP.123", uidPerm2Id.Value);
        }

        [Fact]
        public void Test4()
        {
            var userId = new UserId(1);
            var uidUserId = userId.ToUid();
            var userId2 = UserId.Converter.FromUid(uidUserId); //new UserId(uidUserId);
            Assert.Equal(userId, userId2);
        }

        [Fact]
        public void Test5()
        {
            var permId = new PermId(123);
            var uidPermId = permId.ToUid();
            var permId2 = PermId.Converter.FromUid(uidPermId); //new PermId(uidPermId);
            Assert.Equal(permId, permId2);
        }

        [Fact]
        public void Test6()
        {
            var userId = new UserId(1);
            var uidUserId = userId.ToUid();

            Assert.Throws<ArgumentOutOfRangeException>(() => PermId.Converter.FromUid(uidUserId));
        }

        public class TestUserEntity
        {
            public UserUid Uid { get; set; }
            public string Name { get; set; }
        }

        [Fact]
        public void Test7()
        {
            var userId = new UserId(1);
            var uidUserId = userId.ToUid();
            var entity = new TestUserEntity {Name = "test", Uid = new UserUid(uidUserId)};
            var json = JsonConvert.SerializeObject(entity);
            var entity2 = JsonConvert.DeserializeObject<TestUserEntity>(json);

            Assert.Equal(entity.Uid, entity2.Uid);
            Assert.Equal(entity.Name, entity2.Name);
        }
        
        [Fact]
        public void Test8()
        {
            unsafe
            {
                Assert.Equal(sizeof(byte), sizeof(PermId));
            }
        }
    }
}