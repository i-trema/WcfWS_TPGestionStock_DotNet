using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WcfWS_TPGestionStock.Model
{
    public class Article
    {
        public int Id { get; set; }
        public string Designation { get; set; }
        public int? QteMini { get; set; }

        public double? Prix { get; set; }

        public virtual Categorie Categorie { get; set; }
    }
}