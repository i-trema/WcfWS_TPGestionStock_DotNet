using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WcfWS_TPGestionStock.Model;

namespace WcfWS_TPGestionStock
{
    [ServiceContract]
    public interface IGestionCategorie
    {
        [OperationContract]
        int AjoutCategorie(Categorie categorie);

        [OperationContract]
        Categorie ModificationCategorie(Categorie categorie);

        [OperationContract]
        bool SuppressionCategorie(int id);

        [OperationContract]
        ICollection<Categorie> GetCategories();

        [OperationContract]
        Categorie RechercherCategoriesById(int id);

        [OperationContract]
        ICollection<Categorie> RechercherCategoriesByMotCle(string nom);

        [OperationContract]
        ICollection<Article> GetArticlesByCategorie(int categorieId);
    }
}
