namespace SchoolBusAPI
{
    public class Permissions
    {
        public const string Home = "HOME";
        public const string OwnerRead = "OWNER-R";
        public const string OwnerWrite = "OWNER-W";
        public const string SchoolBusRead = "SB-R";
        public const string SchoolBusWrite = "SB-W";
        public const string UserRead = "USER-R";
        public const string UserWrite = "USER-W";
        public const string RoleRead = "ROLE-R";
        public const string RoleWrite = "ROLE-W";
        public const string CodeRead = "CODE-R";
        public const string CodeWrite = "CODE-W";
    }

    public class Roles
    {
        public const string SystemAdmininstrator = "System Administrator";
        public const string Inspector = "Inspector";
        public const string Manager = "Manager";
    }

    public static class SbiEnvironments
    {
        public const string Dev = "dev";
        public const string Test = "test";
        public const string Prod = "prd";
        public const string Unknown = "unknown";
    }

    public static class DotNetEnvironments
    {
        public const string Dev = "DEVELOPMENT";
        public const string Test = "STAGING";
        public const string Prod = "PRODUCTION";
        public const string Unknown = "UNKNOWN";
    }
}
