using MonPCapplication.Models.Mes_Produits;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MonPCapplication.Controllers
{
    public class CatalogController : Controller
    {
        // GET: Catalog
        public ActionResult Index()
        {
            MonPCEntities model = new MonPCEntities();
            CategorieViewModel cVM = new CategorieViewModel(new SelectList(model.CATEGORIEs.ToList(), "id", "nomCategorie"));
            //cVM.ListCatalog = new SelectList(model.CATEGORIEs.ToList(), "id", "nomCategorie");
            return View(cVM);
        }

        public ActionResult getPartialProducts(int? CategId)
        {

            MonPCEntities model = new MonPCEntities();
            PartialProductViewModel vm;
            vm = new PartialProductViewModel();
            List<PRODUIT> list = model.PRODUITs.Where(o => o.appartient_a == CategId).ToList();

            vm.ListProduct = list;

            return PartialView(vm);
        }
    }
}