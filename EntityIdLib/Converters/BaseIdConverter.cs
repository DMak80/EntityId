namespace EntityIdLib.Converters
{
    public class BaseIdConverter
    {
        protected BaseIdConverter(string start)
        {
            Starts = start;
        }

        public string Starts { get; }
    }
}