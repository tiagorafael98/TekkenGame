using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using TekkenGame.Models;

[assembly: OwinStartupAttribute(typeof(TekkenGame.Startup))]
namespace TekkenGame
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            iniciaAplicacao();
        }
        private void iniciaAplicacao()
        {

            // identifica a base de dados de serviço à aplicação
            ApplicationDbContext db = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));

            // criar a Role 'Admin'
            if (!roleManager.RoleExists("Admin"))
            {
                // não existe a 'role'
                // então, criar essa role
                var role = new IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);
            }

            // criar um utilizador 'Admin'
            var user = new ApplicationUser();
            user.UserName = "admin";
            user.Email = "admin@mail.pt";
            string userPWD = "123_Asd";
            var chkUser = userManager.Create(user, userPWD);
            if (chkUser.Succeeded)
            {
                var result1 = userManager.AddToRole(user.Id, "Admin");
            }


            if (!roleManager.RoleExists("Utilizador"))
            {
                // não existe a 'role'
                // então, criar essa role
                var role = new IdentityRole();
                role.Name = "Utilizador";
                roleManager.Create(role);
            }



            //Adicionar o Utilizador à respetiva Role-Admin
            if (chkUser.Succeeded)
            {
                var result1 = userManager.AddToRole(user.Id, "Admin");
            }
        }
    }
}
