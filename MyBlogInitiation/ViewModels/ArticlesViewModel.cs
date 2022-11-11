using MyBlogInitiation.Models;

namespace MyBlogInitiation.ViewModels
{
    // La classe pour donner a la vue
    public class ArticlesViewModel
    {
        public List<ArticleModel> Articles { get; set; }
    }

}
 



// classe identique a ma BDD
    //------ Déplacé dans myblogInitiation.Model ---------

   /* public class ArticleModel
    {
       public int Id { get; set; }
       public string Title { get; set; }   
       public  string Content { get; set; }
    }
}
   */