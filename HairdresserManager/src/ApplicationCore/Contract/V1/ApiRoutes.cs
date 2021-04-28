namespace ApplicationCore.Contract.V1
{
    public static class ApiRoutes
    {
        private const string Root = "api";
        private const string Version = "v1";
        private const string Base = Root + "/" + Version;

        public static class Login
        {
            public const string LoginUser = Base + "/login";
            public const string FacebookAuth = Base + "/facebook-auth";
            public const string Logout = Base + "/logout";
        }
        
        public static class Register
        {
            private const string RegisterBase = Base + "/register";
            public const string VerifyEmail = RegisterBase + "/verify-email";
            public const string RegisterUser = RegisterBase;
        }
        
        public static class PasswordRecovery
        {
            private const string PasswordRecoveryBase = Base + "";
            public const string RemindPassword = PasswordRecoveryBase + "/remind-password";
            public const string ResetPassword = PasswordRecoveryBase + "/reset-password/{resetPasswordKey}";
        }
        
        public static class RefreshToken
        {
            private const string RefreshTokenBase = Base + "/jwt";
            public const string Refresh = RefreshTokenBase + "/refresh";
        }
        //

        public static class Employee
        {
            private const string EmployeeBase = Base + "/employees";
            public const string GetAllEmployees = EmployeeBase;
            public const string CreateEmployee = EmployeeBase;
            public const string UpdateEmployee = EmployeeBase + "/{employeeId}";
            public const string DeleteEmployee = EmployeeBase + "/{employeeId}";
        }
        
        public static class EmployeeRoles
        {
            private const string EmployeeRolesBase = Base + "/employees/roles";
            public const string CreateRole = EmployeeRolesBase;
            public const string GetRoles = EmployeeRolesBase;
            public const string UpdateRole = EmployeeRolesBase + "/{roleId}";
            public const string DeleteRole = EmployeeRolesBase + "/{roleId}";
        }

        public static class Account
        {
            private const string AccountBase = Base + "/accounts";
            public const string ChangePassword = AccountBase + "/change-password";
            public const string GetUserData = AccountBase + "/me";
            public const string EditUserData = AccountBase;
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
        
        public static class Resource
        {
            
        }
    }
}