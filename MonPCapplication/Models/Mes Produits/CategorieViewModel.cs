using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MonPCapplication.Models.Mes_Produits
{
    public class CategorieViewModel
    {
        public SelectList ListCatalog { get; set; }
        public CategorieViewModel(SelectList l)
        {
            this.ListCatalog = l;
        }
    }
}