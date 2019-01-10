using System;
using EntityIdLib;
using EntityIdLib.Core;
using EntityIdLib.EntityTypeFormat;

namespace ConsoleApp1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var userId = new UserId(1);
            var uidUserId = userId.ToUid();
            var permId = new PermId("123");
            var uidPermId = permId.ToUid();
            var perm2Id = new Perm2Id("123");
            var uidPerm2Id = perm2Id.ToUid();
            var userId2 = uidUserId.ToId<int, UserId>(); //new UserId(uidUserId);
            var permId2 = uidPermId.ToId<string, PermId>(); //new PermId(uidPermId);
            var permId3 = uidUserId.ToId<string, PermId>(); //new PermId(uidUserId);
        }
    }

    [EntityIdType(EntityType.User)]
    public struct UserId : IIdBase<int, UserId>
    {
        public UserId(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }

    [EntityIdType(EntityType.Permission)]
    public struct PermId : IIdBase<string, PermId>
    {
        public PermId(string id)
        {
            Id = id;
        }

        public string Id { get; }
    }

    [EntityIdType(EntityType.Permission2)]
    public struct Perm2Id : IIdBase<string, Perm2Id>
    {
        public Perm2Id(string id)
        {
            Id = id;
        }

        public string Id { get; }
    }
}