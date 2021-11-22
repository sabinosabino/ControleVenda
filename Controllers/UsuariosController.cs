using System;
using System.Collections.Generic;
using System.Web.Mvc;
using ControleFinanc.Models;

namespace ControleFinanc.Controllers
{
    public class UsuariosController : Controller
    {
        [Authorize]
        public ActionResult Index(string filtrar = "xxxxxxx")
        {
            try
            {

                //SE FOR NO REQUEST CARREGAMENTO
                List<Usuarios> us = new Usuarios().Lista(filtrar);
                ViewBag.Usuarios = us;
                if (Request.IsAjaxRequest())
                {
                    return PartialView("_Usuarios", us);
                }
                return View(us);
            }
            catch (Exception)
            {
                return View();
            }

        }
        [Authorize]
        public ActionResult Novo()
        {
            try
            {

                //RETONAR UMA VIEWBAG DE UMA SELECTLIST, INFORME OS DADOS, OS CAMPOS QUE QUER CARREGAR E DÊ UM NOME DEPOPIS USARÁ NA VIEW
                ViewBag.Grupos = new Grupo().ListaAtivos("");
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
        public ActionResult Novo(Usuarios usuarios)
        {
            try
            {

                usuarios.Nome = Request["Nome"].ToString();
                usuarios.Email = Request["Email"].ToString();
                usuarios.Usuario = Request["Login"].ToString();
                usuarios.Telefone_1 = Request["Telefone1"].ToString();
                usuarios.Telefone_2 = Request["Telefone2"].ToString();
                usuarios.Grupo = new Grupo().GrupoUnico(int.Parse(Request["IdGrupo"]));
                usuarios.Status = byte.Parse(Request["Status"]);

                if (usuarios.Salvar())
                {
                    TempData["Sucesso"] = "Registro Salvo com sucesso!";
                    ViewBag.Grupos = new Grupo().ListaAtivos("");
                    return View();
                }
                else
                {
                    return View("Erro ao execultar, contate o administrador.");
                }
            }
            catch (Exception e)
            {
                TempData["Erro"] = e.Message;
                return View();
            }
        }
        [Authorize]
        public ActionResult Editar(int id)
        {
            Usuarios us = new Usuarios().UsuarioUnico(id);
            int idGrupo = us.Grupo.Id;
            //CONTEINERS PARA VIEW
            ViewBag.Grupos = new Grupo().ListaAtivos("");
            ViewBag.Usuarios = us;
            ViewBag.NomeGrupo = new Grupo().GrupoUnico(idGrupo).Nome;
            return View();
        }

        [HttpPost]
        [Authorize]
        public ActionResult Editar(Usuarios usuarios)
        {

            try
            {
                usuarios.Id = int.Parse(Request["Id"].ToString());
                usuarios.Nome = Request["Nome"].ToString();
                usuarios.Email = Request["Email"].ToString();
                usuarios.Usuario = Request["Login"].ToString();
                usuarios.Telefone_1 = Request["Telefone1"].ToString();
                usuarios.Telefone_2 = Request["Telefone2"].ToString();
                usuarios.Grupo = new Grupo().GrupoUnico(int.Parse(Request["IdGrupo"]));
                if (Request["Status"] == "Ativo")
                {
                    usuarios.Status = 1;
                }


                if (usuarios.Salvar())
                {
                    TempData["Sucesso"] = "Registro Salvo com sucesso!";
                    ViewBag.Grupos = new Grupo().ListaAtivos("");
                    return Redirect("/Usuarios/Editar/" + usuarios.Id);
                }
                else
                {
                    return View("Erro ao execultar, contate o administrador.");
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
            Usuarios us = new Usuarios().UsuarioUnico(id);
            int idGrupo = us.Grupo.Id;
            //CONTEINERS PARA VIEW
            ViewBag.Usuarios = us;
            ViewBag.NomeGrupo = new Grupo().GrupoUnico(idGrupo).Nome;
            return View();
        }

        [HttpPost]
        [Authorize]
        public ActionResult Excluir(Usuarios usuarios)
        {
            try
            {
                usuarios.Id = int.Parse(Request["Id"].ToString());
                if (usuarios.Excluir())
                {
                    TempData["Sucesso"] = "Registro Excluído com sucesso!";
                    return Redirect("/Usuarios/Novo");
                }
                else
                {
                    return View("Erro ao execultar, contate o administrador.");
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