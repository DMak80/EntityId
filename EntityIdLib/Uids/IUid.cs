using EntityIdLib.Converters;

namespace EntityIdLib.Uids
{
    public interface IUid
    {
        string? Value { get; }
    }

    public static class IUidExtensions
    {
        public static UidConverter? Converter(this IUid uid) => UidCore.Instance.Get(uid.GetType())?.Converter;
    }
}