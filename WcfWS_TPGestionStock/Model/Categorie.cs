using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WcfWS_TPGestionStock.Model
{
    public class Categorie
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Info { get; set; }

        //public IList<Article> Articles { get; set; }
    }
}