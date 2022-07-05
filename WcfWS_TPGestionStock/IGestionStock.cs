using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WcfWS_TPGestionStock.Model;

namespace WcfWS_TPGestionStock
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom d'interface "IService1" à la fois dans le code et le fichier de configuration.
    [ServiceContract]
    public interface IGestionStock

    {

        [OperationContract]
        int AjoutArticle(Article article);

        [OperationContract]
        Article ModificationArticle(Article article);

        [OperationContract]
        bool SuppressionArticle(int id);

        [OperationContract]
        IList<Article> GetArticles();

        [OperationContract]
        Article RechercherArticlesById(int id);

        [OperationContract]
        ICollection<Article> RechercherArticlesByMotCle(string mot);



        // TODO: ajoutez vos opérations de service ici
    }


    // Utilisez un contrat de données comme indiqué dans l'exemple ci-après pour ajouter les types composites aux opérations de service.
    
}
