namespace Api;

public static class AppConstant
{
    public record Scopes
    {
        public const string ReadPhoneNumbers = "https://www.googleapis.com/auth/user.phonenumbers.read";
        public const string ViewPrimaryUserEmail = "https://www.googleapis.com/auth/userinfo.email";
        public const string ViewCustomerRelatedInformation = "https://www.googleapis.com/auth/admin.directory.customer.readonly";
    }

    public record Url
    {
        public const string FireBase = "kiss-8626d.appspot.com";
        public const string OAuthServerEndpoint = "https://accounts.google.com/o/oauth2/v2/auth";
        public const string TokenServerEndpoint = "https://oauth2.googleapis.com/token";
        public const string RedirectUrl = "https://localhost:5443/api/oauth/resolve-code";
        public const string ClientUrl = "http://localhost:3000";
    }
    public record General
    {
        public const int DefaultPage = 1;
        public const int DefaultPerPage = 30;
        // only for testing purposes
        public const string ClientId = "77771907046-61h45fc7gcuft91puprnuom2r0conrgs.apps.googleusercontent.com";
        public const string ClientSecret = "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";
        public const string PkceSessionKey = "codeVerifier";
    }
}
