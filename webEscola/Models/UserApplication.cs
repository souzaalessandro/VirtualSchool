// 

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace webEscola.Controllers
{
    public class UserApplication : IdentityUser
    {
        public string NomeCompleto { get; set; }
    }
}