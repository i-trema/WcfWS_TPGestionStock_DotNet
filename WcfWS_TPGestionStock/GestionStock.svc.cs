using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WcfWS_TPGestionStock.Model;

namespace WcfWS_TPGestionStock
{
    /// <summary>
    /// /// Throw new WebFaultException(httpStatusCode.NotFound)
    /// </summary>
    /// 

    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "Service1" dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez Service1.svc ou Service1.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public class GestionStock : IGestionStock, IDisposable, IGestionCategorie
    {
        DbGestionContext db = new DbGestionContext();
        

        public void Dispose()
        {
            db.Dispose();
        }

        public int AjoutArticle(Article article)
        {
            Categorie categorieALier = db.Categories.Find(article.Categorie.Id);
            if (categorieALier != null)
            {
                article.Categorie = categorieALier;
            }
            db.Articles.Add(article);
            return db.SaveChanges();
        }
        public ICollection<Article> GetArticles()
        {

            var res = db.Articles.Include(x=>x.Categorie).ToList();
            return res;
        }

        public Article ModificationArticle(Article article)
        {
            Article articleAModifier = db.Articles.Find(article.Id);
            if (articleAModifier != null)
            {

                if (article.QteMini != null) articleAModifier.QteMini = article.QteMini;
                if (article.Prix != null) articleAModifier.Prix = article.Prix;
                if (article.Categorie != null) articleAModifier.Categorie = article.Categorie;
                if (!string.IsNullOrEmpty(article.Designation)) articleAModifier.Designation = article.Designation;

                int i = db.SaveChanges();
                if (i > 0) return articleAModifier;
            }
            return null;
        }


        public Article RechercherArticlesById(int id)
        {
            return db.Articles.Find(id);
        }

        public ICollection<Article> RechercherArticlesByMotCle(string mot)
        {
            return (from elt in db.Articles
                    where elt.Designation.Contains(mot)
                    select elt).ToList();
        }

        public bool SuppressionArticle(int id)
        {
            Article articleASupprimer = db.Articles.Find(id);
            if (articleASupprimer == null) return false;
        
            db.Articles.Remove(articleASupprimer);
            return db.SaveChanges()>0;
        }

        public int AjoutCategorie(Categorie categorie)
        {
            db.Categories.Add(categorie);
            return db.SaveChanges();
        }

        public Categorie ModificationCategorie(Categorie categorie)
        {
            Categorie categorieAModifier = db.Categories.Find(categorie.Id);
            if (categorieAModifier != null)
            {

                if (!string.IsNullOrEmpty(categorie.Nom)) categorieAModifier.Nom = categorie.Nom;
                if (!string.IsNullOrEmpty(categorie.Info)) categorieAModifier.Info = categorie.Info;


                int i = db.SaveChanges();
                if (i > 0) return categorieAModifier;
            }
            return null;
        }

        public bool SuppressionCategorie(int id)
        {
            Categorie categorieASupprimer = db.Categories.Find(id);
            if(categorieASupprimer == null) return false;

            db.Categories.Remove(categorieASupprimer);
            return db.SaveChanges() > 0;
        }

        public ICollection<Categorie> GetCategories()
        {
            var result = db.Categories.Include(x=>x.Articles).ToList();
            return result;
        }

        public Categorie RechercherCategoriesById(int id)
        {
            return db.Categories.Find(id);
        }

        public ICollection<Categorie> RechercherCategoriesByMotCle(string nom)
        {
            return (from elt in db.Categories
                    where elt.Nom.Contains(nom)
                    select elt).ToList();
        }

        public ICollection<Article> GetArticlesByCategorie(Categorie categorie)
        {
            return (from elt in db.Articles
                    where elt.Categorie.Equals(categorie)
                    select elt).ToList();
        }
    }
}
