namespace Utility
{
    public class SiteSettings
    {
        public ConnectionStrings ConnectionStrings { get; set; }
        public JwtSettings JwtSettings { get; set; }
        public IdentitySettings IdentitySettings { get; set; }
        public ElasticConfiguration ElasticConfiguration { get; set; }
        public UrlImage  UrlImage { get; set; }
        public CallbackURL CallbackURL { get; set; }
        public AmountToPay AmountToPay { get; set; }
        public ParbadConfiguration ParbadConfiguration { get; set; }
        public SwaggerConfiguration Swagger { get; set; }
        public IsSandBoxPayment SandBoxPayment { get; set; }
        public OriginsUrl OriginsUrl { get; set; }
    }

    public class OriginsUrl
    {
        public string Url { get; set; }
    }
    public class IdentitySettings
    {
        public bool PasswordRequireDigit { get; set; }
        public int PasswordRequiredLength { get; set; }
        public bool PasswordRequireNonAlphanumic { get; set; }
        public bool PasswordRequireUppercase { get; set; }
        public bool PasswordRequireLowercase { get; set; }
        public bool RequireUniqueEmail { get; set; }
    }
    public class JwtSettings
    {
        public string SecretKey { get; set; }
        public string Encryptkey { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public int NotBeforeMinutes { get; set; }
        public int ExpirationMinutes { get; set; }
    }

    public class ConnectionStrings
    {
        public string SqlServer { get; set; }
    }

    public class ElasticConfiguration
    {
        public string Uri { get; set; }
        public string Index { get; set; }
    }

    public class UrlImage
    {
        public string Url { get; set; }
    }
    public class CallbackURL
    {
        public string Uri { get; set; }
        public string UriVerify { get; set; }
    }
    public class AmountToPay 
    {
        public long Amount { get; set; }
    }
    public class ParbadConfiguration
    {
        public Mellat Mellat { get; set; }
        public ZarinPal ZarinPal { get; set; }
    }

    public class Mellat
    {
        public long TerminalId { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
    }
    public class ZarinPal
    {
        public string MerchantId { get; set; }
        public bool IsSandbox { get; set; }
    }

    public class SwaggerConfiguration
    {
        public string UriSwagger { get; set; }
    }

    public class IsSandBoxPayment
    {
        public string IsSandBox { get; set; }
    }
}
