using ControleFinanc.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace AppWebControl.Controllers
{
    public class GrupoController : Controller
    {
        // o valor do filtrar é passado no form Ajax
        [Authorize]
        public ActionResult Index(string filtrar = "xxxxxxx")
        {
            try
            {
                //SE FOR NO REQUEST CARREGAMENTO
                List<Grupo> gp = new Grupo().Lista(filtrar);
                ViewBag.Grupos = gp;
                if (Request.IsAjaxRequest())
                {
                    return PartialView("_Grupos", gp);
                }
                return View(gp);

            }
            catch (Exception)
            {
                return View(new EmptyResult());
            }

        }

        [HttpGet]
        [Authorize]
        public ActionResult Editar(int id)
        {
            try
            {
                ViewBag.Grupo = new Grupo().GrupoUnico(id);
                return View();
            }
            catch (Exception e)
            {
                TempData["Erro"] = e.Message;
                return View();
            }

        }

        [HttpPost]
        [Authorize]
        public ActionResult Editar(Grupo grupo)
        {
            try
            {
                grupo.Id = int.Parse(Request["Id"].ToString());
                grupo.Nome = Request["Nome"].ToString();
                if (Request["Status"] == "Ativo")
                {
                    grupo.Status = 1;
                }
                if (grupo.Salvar())
                {
                    TempData["Sucesso"] = "Registro Salvo com sucesso!";
                    return Redirect("/Grupo/Editar/" + grupo.Id);
                }
                else
                {
                    TempData["Erro"] = "Erro desconhecido. Contate o Administrador;";
                    return View();
                }
            }
            catch (Exception e)
            {
                TempData["Erro"] = e.Message;
                return View();
            }
        }

        [HttpGet]
        [Authorize]
        public ActionResult Excluir(int id)
        {
            try
            {
                ViewBag.Grupo = new Grupo().GrupoUnico(id);
                return View();
            }
            catch (Exception e)
            {

                TempData["Erro"] = e.Message;
                return View();
            }

        }

        [HttpPost]
        [Authorize]
        public ActionResult Excluir(Grupo grupo)
        {
            try
            {
                grupo.Id = int.Parse(Request["Id"].ToString());

                if (grupo.Excluir())
                {
                    TempData["Sucesso"] = "Registro Excluído com sucesso!";
                    return Redirect("/Grupo/Novo");
                }
                else
                {
                    return View("Erro desconhecido contate Administrador do sistema.");
                }
            }
            catch (Exception e)
            {
                TempData["Erro"] = e.Message;
                return View();
            }
        }
        [Authorize]
        public ActionResult Novo()
        {
            return View();
        }


        [HttpPost]
        [Authorize]
        public ActionResult Novo(Grupo grupo)
        {
            try
            {
                grupo.Nome = Request["Nome"].ToString();
                if (Request["Status"] == "Ativo")
                {
                    grupo.Status = 1;
                }
                if (grupo.Salvar())
                {
                    TempData["Sucesso"] = "Registro Salvo com sucesso!";
                    return View();
                }
                else
                {
                    TempData["Erro"] = "Erro ao tentar execultar";
                    return View();
                }
            }
            catch (Exception e)
            {
                TempData["Erro"] = e.Message;
                return View();
            }
        }

    }
}