using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using System.Collections.Generic;

[assembly: OwinStartupAttribute(typeof(giSelle.Startup))]
namespace giSelle
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            createDefaultUsersAndRoles();
        }

        private void createDefaultUsersAndRoles()
        {
            var db = new Models.ApplicationDbContext();
            var rolesManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            var usersManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(db));

            string adminRole = "Admin";
            string[] defaultRoles = { adminRole, "User", "Collaborator" };
            foreach (var roleName in defaultRoles)
            {
                if (!rolesManager.RoleExists(roleName))
                {
                    rolesManager.Create(new IdentityRole() { Name = roleName });
                    if (roleName == adminRole)
                    {
                        // TODO: fix this
                        var userData = new Models.ApplicationUser() { UserName = "admin", Email = "admin@email.com" };
                        var userResult = usersManager.Create(userData, "qwertyQWERTY123!@#");
                        if (userResult.Succeeded)
                        {
                            usersManager.AddToRole(userData.Id, adminRole);
                        }
                    }
                }
            }

        }
    }
}
