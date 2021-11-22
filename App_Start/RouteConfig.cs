using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ControleFinanc
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Salvar_usuarios",
                url: "Usuarios/Novo",
                defaults: new { controller = "Usuarios", action = "Novo"}
            );

            routes.MapRoute(
                name: "Editar_Grupo",
                url: "Grupo/Editar/{id}",
                defaults: new { controller = "Grupo", action = "Editar", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Editar_Usuario",
                url: "Usuario/Editar/{id}",
                defaults: new { controller = "Usuarios", action = "Editar", id = UrlParameter.Optional }
            );


            routes.MapRoute(
                name: "Editar_Rota",
                url: "Rota/Editar/{id}",
                defaults: new { controller = "Rotas", action = "Editar", id = UrlParameter.Optional }
            );


            routes.MapRoute(
                name: "Editar_Diaria",
                url: "Diaria/Editar/{id}",
                defaults: new { controller = "Diaria", action = "Editar", id = UrlParameter.Optional }
            );


            routes.MapRoute(
                name: "Excluir_Grupo",
                url: "Grupo/Excluir/{id}",
                defaults: new { controller = "Grupo", action = "Excluir", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Excluir_Diaria",
                url: "Diaria/Excluir/{id}",
                defaults: new { controller = "Diaria", action = "Excluir", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Excluir_Usuarios",
                url: "Usuarios/Excluir/{id}",
                defaults: new { controller = "Usuarios", action = "Excluir", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Excluir_Rotas",
                url: "Rotas/Excluir/{id}",
                defaults: new { controller = "Rotas", action = "Excluir", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
