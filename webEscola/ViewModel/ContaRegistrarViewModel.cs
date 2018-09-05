// 

using System.ComponentModel.DataAnnotations;
using System.Security.Permissions;
using System.Web.Mvc;

namespace webEscola.ViewModel
{
    public class ContaRegistrarViewModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        [Display(Name = "Nome completo")]
        public string NomeCompleto { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
    }
}