using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ControleDeEstoque.Pages.Validacao
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public string Usuario { get; set; }
        [BindProperty]
        public string Senha { get; set; }
        public ActionResult OnPostAsync()
        {
            string userPadrao = "admin";
            string senhaPadrao = "pass123";

            if (Senha.Equals(senhaPadrao) && Usuario.Equals(userPadrao))
            {
                return RedirectToPage("/Produtos/Index");
            }
            else
            {
                return RedirectToPage("Validacao/Login");
            }

        }
    }
}
