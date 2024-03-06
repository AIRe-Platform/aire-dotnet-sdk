namespace Aire.Sdk.Auth
{
    public class AireRoles : List<string>
    {
        public const string User = "user";
        public const string Admin = "admin";

        public const string DemoAdmin = "demo-admin";
        public const string DemoUser = "demo-user";

        public static readonly AireRoles All = [ User, Admin, DemoAdmin, DemoUser ];

        public AireRoles() : base() {}
        public AireRoles(params string[] roles) : base(roles) {}
        public AireRoles(params AireRoles[] roles) 
        {
            foreach(var list in roles)
                AddRange(list);
        }

    }
}
