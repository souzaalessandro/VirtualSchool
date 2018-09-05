// 

using System.Data.Entity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Owin;
using webEscola.Controllers;

[assembly:OwinStartup(typeof(webEscola.Startup))]
namespace webEscola
{
    public class Startup
    {

        public void Configuration(IAppBuilder builder)
        {

            builder.CreatePerOwinContext<DbContext>(() => new IdentityDbContext<UserApplication>("DefaultConnection"));

            builder.CreatePerOwinContext<IUserStore<UserApplication>>(
                (option, owinContext) =>
                {
                    var dbContext = owinContext.Get<DbContext>();
                    return new UserStore<UserApplication>(dbContext);
                });

            builder.CreatePerOwinContext<UserManager<UserApplication>>(
                (option, owinContext) =>
                {
                    var userStore = owinContext.Get<IUserStore<UserApplication>>();
                    var userManager = new UserManager<UserApplication>(userStore);
                    var userValidator = new UserValidator<UserApplication>(userManager);
                    userValidator.RequireUniqueEmail = true;
                    userManager.UserValidator = userValidator;
                    return userManager;

                });

        }
    }
}