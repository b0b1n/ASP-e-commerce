
using MonPCapplication.Models;
using MonPCapplication.Models.Mes_Produits;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MonPCapplication.Controllers
{
    public class PanierController : Controller
    {
        MonPCEntities model = new MonPCEntities();
        // GET: Panier
        public ActionResult Index()
        {
            return View("monPanier");
        }

        // Pour vérifier si un produit existe dans le panier
        private int existeDeja(int id)
        {
            List<Achat> panier = (List<Achat>)Session["panier"];
            for (int i = 0; i < panier.Count; i++)
            {
                if (panier[i].Product.id == id)
                    return i;
            }
            return 0;
        }

        // Pour supprime un produit après vérifier s'il existe dans le panier
        public ActionResult supprimer(int id)
        {
            List<Achat> panier = (List<Achat>)Session["panier"];
            Achat indx = (Achat)panier.FirstOrDefault(o => o.Product.id == id);
            panier.Remove(indx);
            Session["panier"] = panier;
            return View("monPanier");
        }
        public ActionResult FaireLaCommande(int id)
        {
            PRODUIT pr = model.PRODUITs.Find(id);
            if (Session["panier"] == null)
            {
                List<Achat> panier = new List<Achat>();
                panier.Add(new Achat(pr, 1));
                Session["panier"] = panier;
            }
            else
            {
                List<Achat> panier = (List<Achat>)Session["panier"];
                Achat indx = (Achat)panier.FirstOrDefault(o => o.Product.id == id);
                //int indx = existeDeja(id);
                if (indx == null)
                    panier.Add(new Achat(pr, 1));
                else
                    panier.FirstOrDefault(o => o.Product.id == id).Quantite++;
                Session["panier"] = panier;
            }
            return View("monPanier");
        }
        public ActionResult acheter()
        {
            MonPCEntities model = new MonPCEntities();
            List<Achat> panier = (List<Achat>)Session["panier"];
            for (int i = 0; i < panier.Count; i++)
            {
                CLIENT_PRODUIT ach = new CLIENT_PRODUIT();
                ach.idCLIENT = AccountLogin.id_connecté;
                ach.idPRODUIT = panier[i].Product.id;
                ach.quantité = panier[i].Quantite;

                model.CLIENT_PRODUIT.Add(ach);
            }
            model.SaveChanges();

            return View();
        }
    }
}