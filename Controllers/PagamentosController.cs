using System;
using System.Collections.Generic;
using System.Web.Mvc;
using ControleFinanc.Models;
using System.Globalization;

namespace ControleFinanc.Controllers
{
    public class PagamentosController : Controller
    {

        [Authorize]
        public ActionResult Index(string filtrar = "xxxxxxx")
        {
            try
            {
                List<Vendas> Vendas_ = new Vendas().Lista(0);
                ViewBag.Vendas = Vendas_;
                if (Request.IsAjaxRequest())
                {
                    return PartialView("_Pagamentos", Vendas_);
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
                ViewBag.Clientes = new Clientes().Lista("");
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
        public ActionResult Novo(Vendas Vendas_)
        {
            try
            {
                Vendas_.idCliente = new Clientes().Unitario(int.Parse(Request["Cliente"].ToString()));
                Vendas_.data_Venda = DateTime.ParseExact(Request["data_Venda"].ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                Vendas_.valor_venda = 0;
                Vendas_.valor_pago = decimal.Parse(Request["valor_venda"].ToString().Replace(',', '.'));
                Vendas_.detalhe_pagamento = Request["detalhes_Venda"].ToString();
                Vendas_.valor_venda = 0;
                Vendas_.tipo = 0;

                if (Vendas_.Salvar())
                {
                    TempData["Sucesso"] = "Registro Salvo com sucesso!";
                    ViewBag.Clientes = new Clientes().Lista("");
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
            Vendas Vendas_ = new Vendas().Unitario(id);
            ViewBag.Clientes = new Clientes().Lista("");
            ViewBag.Venda = Vendas_;
            return View();
        }

        [HttpPost]
        [Authorize]
        public ActionResult Editar(Vendas Vendas_)
        {
            try
            {
                Vendas_.Id = int.Parse(Request["Id"].ToString());
                Vendas_.idCliente = new Clientes().Unitario(int.Parse(Request["Cliente"].ToString()));
                Vendas_.data_Venda = DateTime.ParseExact(Request["data_Venda"].ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                Vendas_.valor_venda = 0;
                Vendas_.valor_pago = decimal.Parse(Request["valor_venda"].ToString().Replace(',', '.'));
                Vendas_.detalhe_pagamento = Request["detalhes_Venda"].ToString();
                Vendas_.tipo = 0;

                if (Vendas_.Salvar())
                {
                    TempData["Sucesso"] = "Registro Salvo com sucesso!";
                    return Redirect("/Pagamentos/Editar/" + Vendas_.Id);
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
            Vendas Vendas_ = new Vendas().Unitario(id);
            ViewBag.Clientes = new Clientes().Lista("");
            ViewBag.Venda = Vendas_;
            return View();
        }

        [HttpPost]
        [Authorize]
        public ActionResult Excluir(Vendas Vendas_)
        {
            try
            {
                Vendas_.Id = int.Parse(Request["Id"].ToString());
                if (Vendas_.Excluir())
                {
                    TempData["Sucesso"] = "Registro Salvo com sucesso!";
                    return Redirect("/Pagamentos/Novo");
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
