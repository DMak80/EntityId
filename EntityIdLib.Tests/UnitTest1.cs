using System;
using EntityIdLib.Converters;
using EntityIdLib.Default;
using EntityIdLib.Ids;
using EntityIdLib.Tests.EntityTypeFormat;
using EntityIdLib.Tests.EntityTypeFormat.Ids;
using EntityIdLib.UIds;
using Xunit;

namespace EntityIdLib.Tests
{
    public class UnitTest1
    {
        public UnitTest1()
        {
            UidCore.Init(UIdEnumConverter.GetUidInfos<EntityType>());
            IdCore.Init(new DefaultEntityIdDescGetter<EntityIds>());
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
            var userId2 = uidUserId.ToId<int, UserId>(); //new UserId(uidUserId);
            Assert.Equal(userId, userId2);
        }

        [Fact]
        public void Test5()
        {
            var permId = new PermId(123);
            var uidPermId = permId.ToUid();
            var permId2 = uidPermId.ToId<byte, PermId>(); //new PermId(uidPermId);
            Assert.Equal(permId, permId2);
        }

        [Fact]
        public void Test6()
        {
            var userId = new UserId(1);
            var uidUserId = userId.ToUid();

            Assert.Throws<ArgumentOutOfRangeException>(() => uidUserId.ToId<byte, PermId>());
        }
    }
}