using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonPCapplication.Models.Mes_Produits
{
    public class Achat
    {
        private PRODUIT product = new PRODUIT();
        public PRODUIT Product { get => product; set => product = value; }

        private int quantite;
        public int Quantite { get => quantite; set => quantite = value; }

        public Achat(PRODUIT product, int quantite)
        {
            this.product = product;
            this.quantite = quantite;
        }


    }
}