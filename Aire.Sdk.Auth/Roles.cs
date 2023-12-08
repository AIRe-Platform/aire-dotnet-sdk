namespace Aire.Sdk.Auth.Roles
{
    public class AireRoles : List<string>
    {
        public const string User = "user";
        public const string Admin = "admin";

        public static readonly AireRoles All = [ User, Admin ];

        public AireRoles() : base() {}
        public AireRoles(params string[] roles) : base(roles) {}
        public AireRoles(params AireRoles[] roles) 
        {
            foreach(var list in roles)
                AddRange(list);
        }

    }
}
