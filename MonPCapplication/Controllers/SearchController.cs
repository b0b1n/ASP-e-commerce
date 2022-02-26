using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MonPCapplication.Models.Mes_Produits;

namespace MonPCapplication.Controllers
{
    public class SearchController : Controller
    {
        // GET: Search
        public ActionResult Index()

        {
            PartialProductViewModel vm = new PartialProductViewModel();
            vm.ListProduct = new List<PRODUIT>();
            return View(vm);
        }
        [HttpGet]
        public ActionResult Index(string myProd)
        {
            MonPCEntities model = new MonPCEntities();
            PartialProductViewModel vm = new PartialProductViewModel();
            vm.ListProduct = new List<PRODUIT>();
            vm.ListProduct = model.PRODUITs.Where(o => o.nomProduit.Contains(myProd) || o.Description.Contains(myProd)).ToList();

            return View(vm);
        }
    }
}