using System;
using System.Collections.Generic;
using System.Web.Mvc;
using ControleFinanc.Models;

namespace ControleFinanc.Controllers
{
    public class VendasPagamentosController : Controller
    {

        [Authorize]
        public ActionResult Index(string filtrar = "xxxxxxx")
        {
            try
            {
                List<VendasPagamentos> Vendas_ = new VendasPagamentos().Lista();
                ViewBag.VendasPagamentos = Vendas_;
                if (Request.IsAjaxRequest())
                {
                    return PartialView("_PagamentosVendas", Vendas_);
                }
                return View();
            }
            catch (Exception)
            {
                return View();
            }
        }

        
    }
}
