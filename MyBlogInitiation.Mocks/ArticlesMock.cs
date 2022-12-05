using MyBlogInitiation.Models;
using System.Net;
using System.Reflection;
using System.Runtime.CompilerServices;
using static System.Net.Mime.MediaTypeNames;
using System.Text.RegularExpressions;

namespace MyBlogInitiation.Mocks
{
    public  class ArticlesMock
    {
        public static readonly List<ArticleModel> listArticles = new List<ArticleModel>()
        {
            new ArticleModel
                  {
                     // Id=0,
                      Title="Les objets connectes en 2021",
                      Content="2022 bonne année...",
                      Available=true
                  },
            new ArticleModel
                  {
                      //Id=1,
                      Title="Les objets connectes en 2022",
                      Content="2023 mauvaise année...",
                Available=true

                  },
            new ArticleModel
                  {
                      //Id=2,
                      Title="Les objets connectes en 2023",
                      Content="2024 pas mieux...",
                      Available=true
                  },
             new ArticleModel
                  {
                     // Id=0,
                      Title="Les objets connectes en 2024",
                      Content="2032 bonne année...",
                      Available=true
                  },
            new ArticleModel
                  {
                      //Id=1,
                      Title="Les objets connectes en 2025",
                      Content="2033 mauvaise année...",
                Available=true

                  },
            new ArticleModel
                  {
                      //Id=2,
                      Title="Les objets connectes en 2026",
                      Content="2034 pas mieux...",
                      Available=true
                  },




        };


        public static List<ArticleModel> GetMockForBDD()
        {
            var result = new List<ArticleModel>();
          

            foreach (ArticleModel Zob in listArticles)
            {
                var NewArticle = new ArticleModel();

                NewArticle.Title = Zob.Title;
                NewArticle.Content = Zob.Content;
                NewArticle.Available = Zob.Available;   

                result.Add(NewArticle); 
            }
            return result;
        }

       




    }
}

