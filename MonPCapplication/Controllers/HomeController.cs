using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MonPCapplication.Models.Mes_Produits;

namespace MonPCapplication.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            MonPCEntities model = new MonPCEntities();
            MyProduct Laptops = new MyProduct();

            Laptops.dict = new Dictionary<string, List<PRODUIT>>();
            foreach(var cat in model.CATEGORIEs)
            {
                string nomCat = cat.nomCategorie;
                Laptops.dict.Add(nomCat, model.PRODUITs.Where(o => o.appartient_a == cat.id).Take(3).ToList());
            }

            Laptops.list_des_produits = model.PRODUITs.ToList();
            return View(Laptops);
        }
        public ActionResult About()
        {
            return View();
        }
        public ActionResult ContactUs()
        {
            return View();
        }
    }
}