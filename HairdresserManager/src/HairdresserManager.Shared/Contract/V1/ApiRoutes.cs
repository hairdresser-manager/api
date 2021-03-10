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