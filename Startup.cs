using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using ZHYR_Library.Models;

[assembly: OwinStartupAttribute(typeof(ZHYR_Library.Startup))]
namespace ZHYR_Library
{
    public partial class Startup
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public void CreateRoles()
        {
            RoleStore<IdentityRole> roleStore = new RoleStore<IdentityRole>(db);
            RoleManager<IdentityRole> roleManager = new RoleManager<IdentityRole>(roleStore);
            IdentityRole role;
            if (!roleManager.RoleExists("Admins"))
            {
                role = new IdentityRole();
                role.Name = "Admins";
                roleManager.Create(role);
            }
            if (!roleManager.RoleExists("Managers"))
            {
                role = new IdentityRole();
                role.Name = "Managers";
                roleManager.Create(role);
            }
            if (!roleManager.RoleExists("Users"))
            {
                role = new IdentityRole();
                role.Name = "Users";
                roleManager.Create(role);
            }
            if (!roleManager.RoleExists("Authors"))
            {
                role = new IdentityRole();
                role.Name = "Authors";
                roleManager.Create(role);
            }

        }
        public void CreateUsers()
        {
            var databasse = new UserStore<ApplicationUser, CustomRole,
    int, CustomUserLogin, CustomUserRole, CustomUserClaim>(db);
            UserManager<ApplicationUser,int> userManager = new UserManager<ApplicationUser, int>(databasse);

            ApplicationUser user = new ApplicationUser();

            user.Email = "zahir.hayrallah@gmail.com";
            user.UserName = "ZahirHayrallah";

            var chack = userManager.Create(user, "Zz96321//");
            if (chack.Succeeded)
            {
                userManager.AddToRole(user.Id, "Admins");
                userManager.AddToRole(user.Id, "Users");
                userManager.AddToRole(user.Id, "Managers");
            }

        }
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            //CreateRoles();
            //CreateUsers();

        }
    }
}
