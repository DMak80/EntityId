using System;
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
            UidCore.Init(EntityUidInfoBuilder.GetUidInfos<EntityType>(typeof(ConverterExtensions)));
        }

        [Fact]
        public void Test1()
        {
            var uidUserId = new UserUid().Converter().ToUid(1);
            var userId = new UserUid(uidUserId);
            Assert.Equal("U.1", userId.Value);
        }

        [Fact]
        public void Test2()
        {
            var uidPermId = new PermUid().Converter().ToUid("123");
            var permId = new PermUid(uidPermId);
            Assert.Equal("P.123", permId.Value);
        }

        [Fact]
        public void Test3()
        {
            var uidPerm2Id = new Perm2Uid().Converter().ToUid(123);
            var perm2Id = new Perm2Uid(uidPerm2Id);
            Assert.Equal("PP.123", perm2Id.Value);
        }

        [Fact]
        public void Test4()
        {
            var uidUserId = new UserUid().Converter().ToUid(1);
            var userId2 = new UserUid().Converter().FromUid(uidUserId.Value); //new UserId(uidUserId);
            Assert.Equal(1, userId2);
        }

        public class TestUserEntity
        {
            public UserUid Uid { get; set; }
            public string Name { get; set; }
        }

        [Fact]
        public void Test7()
        {
            var uidUserId = new UserUid().Converter().ToUid(1);
            var entity = new TestUserEntity {Name = "test", Uid = new UserUid(uidUserId)};
            var json = JsonConvert.SerializeObject(entity);
            var entity2 = JsonConvert.DeserializeObject<TestUserEntity>(json);

            Assert.Equal(entity.Uid, entity2.Uid);
            Assert.Equal(entity.Name, entity2.Name);
        }

    }
}