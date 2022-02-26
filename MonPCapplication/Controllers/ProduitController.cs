using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MonPCapplication.Controllers
{
    public class ProduitController : Controller
    {
        // GET: Produit
        public ActionResult Index(int? id)
        {
            if (id != null)
            {
                MonPCEntities model = new MonPCEntities();
                PRODUIT myProduct = model.PRODUITs.FirstOrDefault(o => o.id == id);
                if (myProduct != null)
                    return View("ProductDetail" , myProduct);
                else
                    return View("error");
            }
            else
            {
                return View("error");
            }
        }
    }
}