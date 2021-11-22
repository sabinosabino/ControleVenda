using ControleFinanc.Models;
using System.Web.Mvc;
using System.Web.Security;

namespace ControleFinanc.Controllers
{
    public class LoginController : Controller
    {
        /*COMENTÁRIO DE ESTUDO----
         * cada Método precisará ter uma rota para execussão basicamente
         * qualquer método público que você adiciona a uma classe de controlador é exposto como uma ação de controlador automaticamente
         * Não pode ser estático
         * Cada métudo retorna uma ação
         * ViewResult-representa HTML e marcação.
         * EmptyResult-não representa nenhum resultado.
         * RedirectResult-representa um redirecionamento para uma nova URL.
         * JsonResult-representa um resultado JavaScript Object Notation que pode ser usado em um aplicativo AJAX.
         * JavaScriptResult-representa um script JavaScript.
         * ContentResult-representa um resultado de texto.
         * FileContentResult-representa um arquivo para download (com o conteúdo binário).
         * FilePathResult-representa um arquivo para download (com um caminho).
         * FileStreamResult-representa um arquivo para download (com um fluxo de arquivo).
         * Se quiser retornar uma visualização deve usar o método view.
        */
        
        //ESSE PODE SER ACESSADO POR QUALQUER UM
        [AllowAnonymous]
        public ActionResult Login(string ReturnUrl)
        {
            ViewBag.ReturnUrl = ReturnUrl;
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(Login login, string returnUrl)
        {
            //Obtem o estado do modelo associado
            if (!ModelState.IsValid)
            {
                return View(login);
            }

            if (login.Logar())
            {
                //connectou
                //responsável pela segunça
                FormsAuthentication.SetAuthCookie(login.Usuario, login.LembrarMe);

                //informa se a url é local
                if (Url.IsLocalUrl("/Home/index"))
                {
                    return Redirect("/Home/index");
                }
                else 
                {
                    //redireciona para um action
                    RedirectToAction("Index", "Home");
                }
            }
            else
            {

                //falha ao se conectar
                ModelState.AddModelError("", "Login e/ou senha inválidos.");
            }

            return View(login);
        }

        public ActionResult Sair()
        {
            //SAIR DO FORM E LIMPAR O COOKIE
            FormsAuthentication.SignOut();
            return Redirect("/");
        }
    }
}