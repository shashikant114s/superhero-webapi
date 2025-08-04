namespace SuperHeros.Configuration
{
    public class JwtConfiguration
    {
        public string Section { get; set; } = "JwtSettings";

        public string ValidIssuer { get; set; } = string.Empty;
        public string ValidAudience { get; set; } = string.Empty;
        public string Key { get; set; } = string.Empty;
        public string Expires { get; set; } = string.Empty;
    }
}
