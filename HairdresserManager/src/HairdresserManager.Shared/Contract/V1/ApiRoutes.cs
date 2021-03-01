namespace HairdresserManager.Shared.Contract.V1
{
    public static class ApiRoutes
    {
        private const string Root = "api";
        private const string Version = "v1";
        private const string Base = Root + "/" + Version;
        
        public static class Auth
        {
            private const string AuthBase = Base + "/auth";
            public const string Login = AuthBase + "/login";
            public const string Logout = AuthBase + "/logout";
            public const string Register = AuthBase + "/register";
            public const string FacebookAuth = AuthBase + "/facebook-auth";
            public const string RefreshToken = AuthBase + "/refresh-token";
            public const string RemindPassword = AuthBase + "/remind-password";
            public const string ResetPassword = AuthBase + "/reset-password/{resetPasswordKey}";
            public const string VerifyEmail = AuthBase + "/verify-email/{verifyEmailKey}";
        }

        public static class Employee
        {
            
        }

        public static class Offer
        {
            
        }

        public static class Review
        {
            
        }

        public static class Schedule
        {
            
        }

        public static class User
        {
            
        }
    }
}