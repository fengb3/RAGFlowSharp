namespace System.Text.Json
{
    internal sealed class SnakeCaseNamingPolicy : JsonSeparatorNamingPolicy
    {
        public SnakeCaseNamingPolicy() : base(true, '_')
        {
        }
    }
}