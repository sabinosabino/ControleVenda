using System;
using System.Collections.Generic;
using System.Web.Mvc;
using ControleFinanc.Models;

namespace AppWebControl.Controllers
{
    public class ClientesController : Controller
    {

        [Authorize]
        public ActionResult Index(string filtrar = "xxxxxxx")
        {
            try
            {
                //SE FOR NO REQUEST CARREGAMENTO
                List<Clientes> Clientes_ = new Clientes().Lista(filtrar);
                ViewBag.Clientes = Clientes_;
                if (Request.IsAjaxRequest())
                {
                    return PartialView("_Clientes", Clientes_);
                }
                return View();
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
                ViewBag.Estados = new Estados().Lista("");
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
        public ActionResult Novo(Clientes Clientes_)
        {
            try
            {
                Clientes_.Nome = Request["Nome"].ToString();
                Clientes_.Tipo = Request["Tipo"].ToString();
                Clientes_.Apelido = Request["Apelido"].ToString();
                Clientes_.Endereco = Request["Endereco"].ToString();
                Clientes_.Bairro = Request["Bairro"].ToString();
                Clientes_.Cidade = Request["Cidade"].ToString();
                Clientes_.Uf = Request["Estado"].ToString();
                Clientes_.Cep = Request["Cep"].ToString();
                Clientes_.Telefone_1 = Request["Telefone_1"].ToString();
                Clientes_.Telefone_2 = Request["Telefone_2"].ToString();
                Clientes_.Email = Request["Email"].ToString();
                Clientes_.Rg = Request["Rg"].ToString();
                Clientes_.Cpf_cnpj = Request["cpf_cnpj"].ToString();
                Clientes_.SspLocal = Request["SspLocal"].ToString();


                if (Clientes_.Salvar())
                {
                    TempData["Sucesso"] = "Registro Salvo com sucesso!";
                    return Redirect("/Clientes/Novo");
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
            Clientes Clientes_ = new Clientes().Unitario(id);
            ViewBag.Estados = new Estados().Lista("");
            ViewBag.Cliente = Clientes_;
            return View();
        }

        [HttpPost]
        [Authorize]
        public ActionResult Editar(Clientes Clientes_)
        {
            try
            {
                Clientes_.Id = int.Parse(Request["Id"].ToString());
                Clientes_.Nome = Request["Nome"].ToString();
                Clientes_.Tipo = Request["Tipo"].ToString();
                Clientes_.Apelido = Request["Apelido"].ToString();
                Clientes_.Endereco = Request["Endereco"].ToString();
                Clientes_.Bairro = Request["Bairro"].ToString();
                Clientes_.Cidade = Request["Cidade"].ToString();
                Clientes_.Uf = Request["Estado"].ToString();
                Clientes_.Cep = Request["Cep"].ToString();
                Clientes_.Telefone_1 = Request["Telefone_1"].ToString();
                Clientes_.Telefone_2 = Request["Telefone_2"].ToString();
                Clientes_.Email = Request["Email"].ToString();
                Clientes_.Rg = Request["Rg"].ToString();
                Clientes_.Cpf_cnpj = Request["cpf_cnpj"].ToString();
                Clientes_.SspLocal = Request["SspLocal"].ToString();

                if (Clientes_.Salvar())
                {
                    TempData["Sucesso"] = "Registro Salvo com sucesso!";
                    return Redirect("/Clientes/Editar/" + Clientes_.Id);
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
            Clientes Clientes_ = new Clientes().Unitario(id);
            ViewBag.Estados = new Estados().Lista("");
            ViewBag.Cliente = Clientes_;
            return View();
        }

        [HttpPost]
        [Authorize]
        public ActionResult Excluir(Clientes Clientes_)
        {
            try
            {
                Clientes_.Id = int.Parse(Request["Id"].ToString());
                if (Clientes_.Excluir())
                {
                    TempData["Sucesso"] = "Registro Salvo com sucesso!";
                    return Redirect("/Clientes/Novo");
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
