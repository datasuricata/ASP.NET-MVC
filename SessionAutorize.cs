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
//Durante a execução de suas Actions ele sobre escreve a ação validando a sessão do usuário antes de prosseguir.

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
