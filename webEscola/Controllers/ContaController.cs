// 

using System;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using webEscola.ViewModel;

namespace webEscola.Controllers
{
    public class ContaController:Controller
    {
        private UserManager<UserApplication> _userManager;
        public UserManager<UserApplication> UserManager
        {
            get
            {
                if (_userManager == null)
                {
                    var owinContext = HttpContext.GetOwinContext();
                    _userManager = owinContext.GetUserManager<UserManager<UserApplication>>();
                }
                return _userManager;
            }
            set { _userManager = value; }
        }
        public ActionResult Registrar()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Registrar(ContaRegistrarViewModel model)
        {
            if (ModelState.IsValid)
            {
                
                var newUser = new UserApplication();
                newUser.NomeCompleto = model.NomeCompleto;
                newUser.Email = model.Email;
                newUser.UserName = model.UserName;

                var user = UserManager.FindByEmail(model.Email);
                var existUser = user != null;
                if (existUser)
                  return RedirectToAction("Index", "Home");

                var result  = await UserManager.CreateAsync(newUser, model.Senha);


                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    AddErrors(result);
                }

            }

            return View();
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error);
            }
        }
    }
}