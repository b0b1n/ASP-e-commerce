using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonPCapplication.Models.Mes_Produits
{
    public class MyProduct
    {
        public Dictionary<string, List<PRODUIT>> dict { get; set; }
        public List<PRODUIT> list_des_produits { get; set; }

    }
}