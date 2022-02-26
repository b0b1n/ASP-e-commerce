using MonPCapplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MonPCapplication.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetProducts()
        {
            MonPCEntities model = new MonPCEntities();
            var products = model.PRODUITs.Select(o => new {
                nomProduit = o.nomProduit,
                prix = o.prix,
                quantité = o.quantité,
                appartient_a = model.CATEGORIEs.FirstOrDefault(s => s.id == o.appartient_a).nomCategorie,
                ajoute_par = model.FOURNISSEURs.FirstOrDefault(s => s.id == o.ajoute_par).username,
                id = o.id
            }).ToList();
            return Json(new { data = products }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AjoutProd()
        {
            PRODUIT pr = new PRODUIT();
            return View(pr);
        }
        [HttpPost]
        public ActionResult AjoutProd(string nomProduit, string Description, HttpPostedFileBase image, float prix, int quantité, int nomCategorie)
        {
            MonPCEntities model = new MonPCEntities();
            PRODUIT pr = new PRODUIT();
            string pic = null;
            if (image != null)
            {
                pic = System.IO.Path.GetFileName(image.FileName);
                string path = System.IO.Path.Combine(Server.MapPath("~/Images"), pic);
                image.SaveAs(path);
            }
            pr.nomProduit = nomProduit;
            pr.Description = Description;
            pr.image = pic;
            pr.prix =(decimal) prix;
            pr.quantité = quantité;
            pr.appartient_a = model.CATEGORIEs.FirstOrDefault(o => o.id == nomCategorie).id;
            pr.ajoute_par = model.FOURNISSEURs.FirstOrDefault(o => o.id == AccountLogin.id_connecté).id;


            model.PRODUITs.Add(pr);
            model.SaveChanges();
            return RedirectToAction("Index","Home");
        }

        public ActionResult supprimerProd(int id)
        {
            MonPCEntities model = new MonPCEntities();
            PRODUIT pr = new PRODUIT();
            pr = model.PRODUITs.FirstOrDefault(o => o.id == id);
            model.PRODUITs.Remove(pr);
            model.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

    }
}