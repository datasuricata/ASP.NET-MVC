using System;
using System.Web;

namespace DataSuricata.Build.IO.Filters
{
    //Efetua validação de sessão a cada ação na controller que o filtro estiver ativo
    public class SessionAutorize : System.Web.Mvc.ActionFilterAttribute, System.Web.Mvc.IActionFilter
    {
        public override void OnActionExecuting(System.Web.Mvc.ActionExecutingContext filtercontext)
        {
            //todo [Validando Sessão] - ActionExecuting - Filter Active
            if (HttpContext.Current.Session["User_Token"] == null)
            {   
                filtercontext.Result = new System.Web.Mvc.RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary
                {
                    {"Controller", "Usuario"},
                    {"Action", "Login" }
                });
            }
            base.OnActionExecuting(filtercontext);
        }
    }
}


//Função do Código:
//Durante a execução de suas Actions ele vai sobre escrever a ação, validando a sessão do usuário antes de prosseguir.
//Veja que aplicamos somente uma condição, que é se o usuário possui o token de sessão.
//Customize de acordo com a sua nescessidade, mas não esqueça que a validação vai rodar do lado do servidor, muitas condicionais podem gerar carga pesada em sua hospedagem física. 

//Exemplo de Aplicação:

//Crie uma pasta chamada "Filters" em seu projeto seguido de sua classe, no nosso caso ficou como "SessionAutorize.cs"
//Aditione na sua Base Controller, ou somente nas controladoras que deseja aplicar o filtro.

// namespace MinhaAplicacao.Controllers
// {
//     [Filters.SessionAutorize]
//     public class DashboardController : BaseController
//     { 
//     }
// }
