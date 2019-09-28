using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace UNIFAFIBE.TCC._4Sales.MVC.Models
{
    public class LoginViewModel
    {
        [HiddenInput]
        public string UrlRetorno { get; set; }

        [Required(ErrorMessage = "O campo usuário é obrigatório."), AllowHtml]
        public string Username { get; set; }

        [Required(ErrorMessage = "O campo senha é obrigatório"), AllowHtml]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}